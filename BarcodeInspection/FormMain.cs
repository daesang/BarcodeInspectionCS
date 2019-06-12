using BarcodeInspection.Common;
using BarcodeInspection.Models;
using BarcodeInspection.Services;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BarcodeInspection
{
    public partial class FormMain : Form
    {
        private int childFormNumber = 0;

        public FormMain()
        {
            InitializeComponent();
        }

        private void ShowNewForm(object sender, EventArgs e)
        {
            Form childForm = new Form();
            childForm.MdiParent = this;
            childForm.Text = "Window " + childFormNumber++;
            childForm.Show();
        }

        private void toolStripBtnSearch_Click(object sender, EventArgs e)
        {
            this.toolStripBtnSearch.Enabled = false;

            Task task = Task.Factory.StartNew(() => {
                this.Invoke((Action)async delegate {
                    await RunTopButton(CommonTopButton.SEARCH);
                    this.toolStripBtnSearch.Enabled = true;
                });
            });
        }

      
        public async Task RunTopButton(CommonTopButton commonTopButton)
        {
            object frmChild = this.ActiveMdiChild;

            if ((frmChild != null))
            {
                try
                {
                    if (frmChild is ITopButton)
                    {
                        switch (commonTopButton)
                        {
                            case CommonTopButton.SEARCH:
                                await (frmChild as ITopButton).Search();
                                break;
                            case CommonTopButton.SAVE:
                                await (frmChild as ITopButton).Save();
                                break;
                            case CommonTopButton.CONFIRM:
                                await (frmChild as ITopButton).Confirm();
                                break;
                            case CommonTopButton.DOWNLAOD:
                                (frmChild as ITopButton).Download();
                                break;
                            case CommonTopButton.UPLOAD:
                                (frmChild as ITopButton).Upload();
                                break;
                            case CommonTopButton.PRINT:
                                (frmChild as ITopButton).Print();
                                break;
                            case CommonTopButton.CLOSE:
                                (frmChild as ITopButton).Close();
                                break;
                            case CommonTopButton.CLEAR:
                                (frmChild as ITopButton).Clear();
                                break;
                            case CommonTopButton.DELETE:
                                await (frmChild as ITopButton).Delete();
                                break;

                            default:
                                break;
                        }
                    }
                }
                catch (Exception EX)
                {
                    MessageBox.Show(EX.ToString());
                }
            }
        }

        private void FormMain_MdiChildActivate(object sender, EventArgs e)
        {
            Form activeChild = (Form)this.ActiveMdiChild;

            if (activeChild == null)
            {
                tabControl.Visible = false;
            }
            else
            {
                if (this.ActiveMdiChild.Tag == null)
                {
                    // Add a tabPage to tabControl with child form caption
                    TabPage tp = new TabPage(this.ActiveMdiChild.Text);
                    tp.Tag = this.ActiveMdiChild;
                    tp.Parent = tabControl;
                    tabControl.SelectedTab = tp;

                    this.ActiveMdiChild.Tag = tp;
                    this.ActiveMdiChild.FormClosed += new FormClosedEventHandler(ActiveMdiChild_FormClosed);
                }
                else
                {
                    tabControl.SelectedTab = (TabPage)this.ActiveMdiChild.Tag;
                }

                if (!tabControl.Visible)
                    tabControl.Visible = true;
            }

        }

        void ActiveMdiChild_FormClosed(object sender, FormClosedEventArgs e)
        {
            ((sender as Form).Tag as TabPage).Dispose();
        }

        private void tabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((tabControl.SelectedTab != null) && (tabControl.SelectedTab.Tag != null))
                (tabControl.SelectedTab.Tag as Form).Select();
        }

        private void FormMain_KeyDown(object sender, KeyEventArgs e)
        {
            //Debug.WriteLine(e.KeyCode);
            //Debug.WriteLine(e.KeyData); //더 상세함
            //Debug.WriteLine(e.Modifiers); 

            if (e.KeyCode == Keys.F2 || e.KeyCode == Keys.F3 || e.KeyCode == Keys.F4 || e.KeyCode == Keys.F7 || e.KeyCode == Keys.F8 || e.KeyCode == Keys.F9 || e.KeyCode == Keys.F12)
            {
                switch (e.KeyCode)
                {
                    case Keys.F2: //Search
                        e.Handled = true;
                        toolStripBtnSearch.PerformClick();
                        break;
                    case Keys.F3: //Save
                        e.Handled = true;
                        toolStripBtnConfirm.PerformClick();
                        break;
                    case Keys.F5: //Download
                        e.Handled = true;
                        toolStripBtnDownload.PerformClick();
                        break;
                    case Keys.F6: //Upload
                        e.Handled = true;
                        toolStripBtnUpload.PerformClick();
                        break;
                    case Keys.F7: //Print
                        e.Handled = true;
                        toolStripBtnPrint.PerformClick();
                        break;
                    case Keys.F8: //Clear
                        e.Handled = true;
                        toolStripBtnClear.PerformClick();
                        break;
                    case Keys.F9: //Close
                        e.Handled = true;
                        toolStripBtnClose.PerformClick();
                        break;
                    case Keys.F12: //Confirm
                        e.Handled = true;
                        toolStripBtnConfirm.PerformClick();
                        break;
                    default:
                        break;
                }
            }
        }

        private void LOBSC010ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            subNewMdiChildren(new LOBSC010(), "엑셀 업로드");
        }

        public void subNewMdiChildren(Form childForm, string frmText)
        {
            //if (Login._login_menu_opt.ToString() == "S") //싱글창 조건일 경우
            //{
            // 같은 메뉴가 이미 떠 있으면 띄우지 않는다.
            foreach (Form ChildFormList in this.MdiChildren)
            {
                if (ChildFormList.Name == childForm.Name)
                {
                    ChildFormList.Activate();
                    return;
                }
            }
            //}

            Form newChildFrm = childForm;

            newChildFrm.Text = childForm.Name + "-" + frmText;
            newChildFrm.MdiParent = this;
            newChildFrm.WindowState = FormWindowState.Maximized;
            //newChildFrm.StartPosition = FormStartPosition.WindowsDefaultLocation;
            newChildFrm.Show();
        }

        private void toolStripBtnUpload_Click(object sender, EventArgs e)
        {
            this.toolStripBtnUpload.Enabled = false;

            Task task = Task.Factory.StartNew(() =>
            {
                this.Invoke((Action)async delegate
                {
                    await RunTopButton(CommonTopButton.UPLOAD);
                    this.toolStripBtnUpload.Enabled = true;
                });
            });
        }

        private void toolStripBtnClose_Click(object sender, EventArgs e)
        {
            this.toolStripBtnClose.Enabled = false;

            Task task = Task.Factory.StartNew(() =>
            {
                this.Invoke((Action)async delegate
                {
                    await RunTopButton(CommonTopButton.CLOSE);
                    this.toolStripBtnClose.Enabled = true;
                });
            });
        }

        private void toolStripBtnClear_Click(object sender, EventArgs e)
        {
            this.toolStripBtnClear.Enabled = false;

            Task task = Task.Factory.StartNew(() =>
            {
                this.Invoke((Action)async delegate
                {
                    await RunTopButton(CommonTopButton.CLEAR);
                    this.toolStripBtnClear.Enabled = true;
                });
            });
        }

        private void toolStripBtnSave_Click(object sender, EventArgs e)
        {
            this.toolStripBtnSave.Enabled = false;

            Task task = Task.Factory.StartNew(() => {
                this.Invoke((Action)async delegate {
                    await RunTopButton(CommonTopButton.SAVE);
                    this.toolStripBtnSave.Enabled = true;
                });
            });
        }


        private void FormMain_Load(object sender, EventArgs e)
        {
            this.Text = "Ver. " + System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString();

            this.tabControl.Visible = false;

            new LoginView().ShowDialog();
            
            //var form = new LoginView();
            //form.ShowDialog();
        }

        private void toolStripBtnConfirm_Click(object sender, EventArgs e)
        {
            this.toolStripBtnConfirm.Enabled = false;

            Task task = Task.Factory.StartNew(() => {
                this.Invoke((Action)async delegate {
                    await RunTopButton(CommonTopButton.CONFIRM);
                    this.toolStripBtnConfirm.Enabled = true;
                });
            });
        }

        private void LOBSC020ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            subNewMdiChildren(new LOBSC020(), "스캔 처리현황");
        }

        private void toolStripBtnDownload_Click(object sender, EventArgs e)
        {
            this.toolStripBtnDownload.Enabled = false;

            Task task = Task.Factory.StartNew(() => {
                this.Invoke((Action)async delegate {
                    await RunTopButton(CommonTopButton.DOWNLAOD);
                    this.toolStripBtnDownload.Enabled = true;
                });
            });
        }

        private void toolStripBtnDelete_Click(object sender, EventArgs e)
        {
            this.toolStripBtnDelete.Enabled = false;

            Task task = Task.Factory.StartNew(() => {
                this.Invoke((Action)async delegate {
                    await RunTopButton(CommonTopButton.DELETE);
                    this.toolStripBtnDelete.Enabled = true;
                });
            });
        }
    }
}
