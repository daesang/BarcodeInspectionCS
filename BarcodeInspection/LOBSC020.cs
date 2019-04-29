using BarcodeInspection.Common;
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
            row["Code"] = "1001";
            row["Name"] = "삼성웰스토리";
            dt.Rows.Add(row);
            row = dt.NewRow();
            row["Code"] = "1002";
            row["Name"] = "신세계";
            dt.Rows.Add(row);

            row = dt.NewRow();
            row["Code"] = "1003";
            row["Name"] = "CJ후레쉬웨이";
            dt.Rows.Add(row);

            row = dt.NewRow();
            row["Code"] = "1004";
            row["Name"] = "동원홈푸드";
            dt.Rows.Add(row);

            this.cboCustomer.DataSource = dt;
            this.cboCustomer.ValueMember = "Code";
            this.cboCustomer.DisplayMember = "Name";
            this.cboCustomer.SelectedIndex = 0;

            this.WindowState = FormWindowState.Maximized;
        }

        void ITopButton.Clear()
        {
            _presenter.Clear(this.dataGridView1);
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
            throw new NotImplementedException();
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
            await _presenter.Search(dataGridView1, dateTimePicker1.Value, cboCustomer.SelectedValue.ToString());
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
    }
}
