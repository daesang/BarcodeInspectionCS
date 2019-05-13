using BarcodeInspection.Common;
using BarcodeInspection.Helper;
using BarcodeInspection.Presenters;
using BarcodeInspection.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BarcodeInspection
{
    public partial class LOBSC020 : Form, ILOBSC020View, ITopButton
    {
        LOBSC020Presenter _presenter;

        public DateTime Rqshpd => this.dateTimePicker1.Value;

        public string Customer => cboCustomer.SelectedValue.ToString();

        public DataGridView ExcelDataGridView => this.dataGridView1;

        public string Wavecd => this.cboWave.SelectedValue.ToString();

        public LOBSC020()
        {
            InitializeComponent();
        }

        private void LOBSC020_Load(object sender, EventArgs e)
        {
            _presenter = new LOBSC020Presenter(this);

            foreach (DataGridViewColumn item in this.dataGridView1.Columns)
            {
                item.HeaderCell.Style.Alignment = DataGridViewContentAlignment.BottomCenter;
                //col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                //col.HeaderCell.Style.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Pixel);
            }

            DataTable dt = new DataTable();
            DataRow row = null;
            dt.Columns.Add(new DataColumn("Code", typeof(string)));
            dt.Columns.Add(new DataColumn("Name", typeof(string)));

            row = dt.NewRow();
            row["Code"] = "1010";
            row["Name"] = "삼성웰스토리-평택";
            dt.Rows.Add(row);

            row = dt.NewRow();
            row["Code"] = "1011";
            row["Name"] = "삼성웰스토리-용인";
            dt.Rows.Add(row);

            row = dt.NewRow();
            row["Code"] = "1020";
            row["Name"] = "신세계";
            dt.Rows.Add(row);

            row = dt.NewRow();
            row["Code"] = "1030";
            row["Name"] = "CJ프레시웨이";
            dt.Rows.Add(row);

            row = dt.NewRow();
            row["Code"] = "1040";
            row["Name"] = "동원홈푸드";
            dt.Rows.Add(row);

            this.cboCustomer.DataSource = dt;
            this.cboCustomer.ValueMember = "Code";
            this.cboCustomer.DisplayMember = "Name";
            this.cboCustomer.SelectedIndex = 0;

            DataTable dt2 = new DataTable();
            DataRow row2 = null;
            dt2.Columns.Add(new DataColumn("Code", typeof(string)));
            dt2.Columns.Add(new DataColumn("Name", typeof(string)));

            row2 = dt2.NewRow();
            row2["Code"] = "0";
            row2["Name"] = "전체";
            dt2.Rows.Add(row2);

            row2 = dt2.NewRow();
            row2["Code"] = "1";
            row2["Name"] = "1차(Wave)";
            dt2.Rows.Add(row2);

            row2 = dt2.NewRow();
            row2["Code"] = "2";
            row2["Name"] = "2차(Wave)";
            dt2.Rows.Add(row2);

            row2 = dt2.NewRow();
            row2["Code"] = "3";
            row2["Name"] = "3차(Wave)";
            dt2.Rows.Add(row2);
            
            this.cboWave.DataSource = dt2;
            this.cboWave.ValueMember = "Code";
            this.cboWave.DisplayMember = "Name";
            this.cboWave.SelectedIndex = 0;

            this.WindowState = FormWindowState.Maximized;
        }

        void ITopButton.Clear()
        {
            _presenter.Clear();
        }

        void ITopButton.Close()
        {
            this.Close();
        }

        Task ITopButton.Confirm()
        {
            throw new NotImplementedException();
        }

        void ITopButton.Download()
        {
            if (this.dataGridView1.Rows.Count <= 0)
            {
                return;
            }

            try
            {
                this.Cursor = Cursors.WaitCursor;

                SaveFileDialog saveFileDialog = new SaveFileDialog();
                //saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
                //saveFileDialog.InitialDirectory = saveFileDialog.InitialDirectory = "{Desktop}";
                saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
                saveFileDialog.Filter = "Excel File(*.xlsx)|*.xlsx";

                if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
                {
                    ExcelDownload.GenerateExcel((DataTable)this.dataGridView1.DataSource, saveFileDialog.FileName, "Data");

                    MessageBox.Show(string.Format("File name '{0}' generated successfully.", saveFileDialog.FileName), "File generated successfully!", MessageBoxButtons.OK, MessageBoxIcon.None);
                }

                this.Cursor = Cursors.Default;
            }
            catch (Exception ex)
            {
                this.Cursor = Cursors.Default;
                MessageBox.Show(ex.Message, "Error - btnExcel_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
            }
        }
        

        void ITopButton.Print()
        {
            throw new NotImplementedException();
        }

        Task ITopButton.Save()
        {
            throw new NotImplementedException();
        }

        async Task ITopButton.Search()
        {
            await _presenter.Search();
        }

        void ITopButton.Upload()
        {
            throw new NotImplementedException();
        }

        private void dataGridView1_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            var grid = sender as DataGridView;
            var rowIdx = (e.RowIndex + 1).ToString();

            var centerFormat = new StringFormat()
            {
                // right alignment might actually make more sense for numbers
                Alignment = StringAlignment.Center,

                LineAlignment = StringAlignment.Center
            };
            //get the size of the string
            Size textSize = TextRenderer.MeasureText(rowIdx, this.Font);
            var headerBounds = new Rectangle(e.RowBounds.Left, e.RowBounds.Top, grid.RowHeadersWidth, e.RowBounds.Height);
            e.Graphics.DrawString(rowIdx, this.Font, SystemBrushes.ControlText, headerBounds, centerFormat);
        }

        async Task ITopButton.Delete()
        {
            throw new NotImplementedException();
        }
    }
}
