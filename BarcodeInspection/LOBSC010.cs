﻿using ExcelDataReader;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OfficeOpenXml;
using System.Diagnostics;
using BarcodeInspection.Helper;
using BarcodeInspection.Common;
using BarcodeInspection.Presenters;
using BarcodeInspection.Views;

namespace BarcodeInspection
{
    public partial class LOBSC010 : Form, ILOBSC010View, ITopButton
    {
        LOBSC010Presenter _presenter;

        public DateTime Rqshpd { get { return this.dateTimePicker1.Value;} }

        public string Customer { get { return cboCustomer.SelectedValue.ToString(); } }

        public bool IsConfirm => this.radioButtonConfirm.Checked?true:false;

        public DataTable ExcelDataTable => this._excelDataTable;

        public DataGridView ExcelDataGridView => this.dataGridView1;

        public string Wavecd => this.cboWave.SelectedValue.ToString();

        private DataTable _excelDataTable = new DataTable();

        public LOBSC010()
        {
            InitializeComponent();
        }

        private void LOBSC010_Load(object sender, EventArgs e)
        {
            _presenter = new LOBSC010Presenter(this);

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

            this.cboCustomer.DataSource=dt;
            this.cboCustomer.ValueMember="Code";
            this.cboCustomer.DisplayMember="Name";
            this.cboCustomer.SelectedIndex=0;

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

            this.cboWave.DataSource=dt2;
            this.cboWave.ValueMember="Code";
            this.cboWave.DisplayMember="Name";
            this.cboWave.SelectedIndex=0;

            this.WindowState = FormWindowState.Maximized;
        }


        void ITopButton.Upload()
        {
            //DataTable dt = new DataTable();

            string fileName = string.Empty;

            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
            openFileDialog1.Filter = "Excel Files (*.xlsx;*.xls)|*.xlsx;*.xls";
            openFileDialog1.Title = "Select a Cursor Excel";

            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                fileName = openFileDialog1.FileName;

            }
            else
            {
                return;
            }

            //Console.WriteLine(fileName);

            if(string.IsNullOrEmpty(fileName))
            {
                return;
            }

            //1차라벨
            //Console.WriteLine(fileName.Substring(fileName.Length - 9, 4));
            string tmp = string.Empty;
            try
            {
                //삼성웰스토리만 해당함.
                if (cboCustomer.SelectedIndex == 0 || cboCustomer.SelectedIndex == 1)
                {
                    if (fileName.Length >= 9)
                    {
                        tmp = fileName.Substring(fileName.Length - 9, 4);

                        if (tmp.StartsWith("1차"))
                        {
                            this.cboWave.SelectedIndex = 1;
                        }
                        else if (tmp.StartsWith("2차"))
                        {
                            this.cboWave.SelectedIndex = 2;
                        }
                        else if (tmp.StartsWith("3차"))
                        {
                            this.cboWave.SelectedIndex = 3;
                        }
                        else
                        {
                            this.cboWave.SelectedIndex = 1;
                        }
                    }
                }
                else
                {
                    if(this.cboWave.SelectedIndex == 0 )
                    {
                        this.cboWave.SelectedIndex = 1;
                    }
                }
            }
            catch(Exception e)
            {

            }



            try
            {
                using (FileStream stream = File.Open(openFileDialog1.FileName, FileMode.Open, FileAccess.Read))
                {
                    using (IExcelDataReader excelReader = ExcelReaderFactory.CreateReader(stream))
                    {
                        _excelDataTable = excelReader.AsDataSet(
                                                    new ExcelDataSetConfiguration()
                                                    {
                                                        ConfigureDataTable = (_) => new ExcelDataTableConfiguration()
                                                        {
                                                            UseHeaderRow = true
                                                        }
                                                    }
                            ).Tables[0];
                    }
                }

                if (_excelDataTable != null || _excelDataTable.Rows.Count > 0)
                {
                    this.dataGridView1.DataSource = _presenter.ExcelUpload();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Excel File Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
            finally
            {

            }
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
            //if header width lower then string width then resize
            //if (grid.RowHeadersWidth < textSize.Width + 40)
            //{
            //    grid.RowHeadersWidth = textSize.Width + 40;
            //}
            var headerBounds = new Rectangle(e.RowBounds.Left, e.RowBounds.Top, grid.RowHeadersWidth, e.RowBounds.Height);
            e.Graphics.DrawString(rowIdx, this.Font, SystemBrushes.ControlText, headerBounds, centerFormat);
        }

        async Task ITopButton.Search()
        {
            await _presenter.Search();
        }

        async Task ITopButton.Save()
        {
            if (radioButtonConfirm.Checked)
            {
                MessageBox.Show("확정상태에서는 저장 할 수 없습니다.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (this.dataGridView1.DataSource != null && ((DataTable)this.dataGridView1.DataSource).Rows.Count > 1)
            {
                await _presenter.Save();
            }
        }

        void ITopButton.Download()
        {
            if(this.dataGridView1.Rows.Count <= 0)
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
            
        }

        void ITopButton.Close()
        {
            this.Close();
        }

        void ITopButton.Clear()
        {
            _presenter.Clear();
        }

        async Task ITopButton.Confirm()
        {
            Console.WriteLine("test");

            
            if(radioButtonConfirm.Checked)
            {
                MessageBox.Show("확정상태에서는 확정 할 수 없습니다.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            await _presenter.Confirm();
        }

        async Task ITopButton.Delete()
        {
            //if (radioButtonConfirm.Checked)
            //{
            //    MessageBox.Show("확정상태에서는 삭제 할 수 없습니다.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    return;
            //}

            await _presenter.Delete();
        }
    }
}
