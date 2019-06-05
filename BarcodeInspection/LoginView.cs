using BarcodeInspection.Models;
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
    public partial class LoginView : Form, ILoginView
    {
        LoginPresenter _presenter;

        //public string Compky => this.txtCompky.Text.Trim();

        //public string Wareky => this.cboWarehouse.SelectedValue.ToString();

        //public string Userid => this.txtUserId.Text.Trim();

        //public string Passwd => this.txtPassword.Text.Trim();

        public string Compky { get => this.txtCompky.Text.Trim(); }
        public string Wareky { get => this.cboWarehouse.SelectedValue.ToString(); }
        public string Userid { get => this.txtUserId.Text.Trim(); }
        public string Passwd { get => this.txtPassword.Text.Trim(); }

        public LoginView()
        {
            InitializeComponent();
        }

        private void Login_Load(object sender, EventArgs e)
        {
            _presenter = new LoginPresenter(this);


            this.cboWarehouse.ValueMember = "Wareky";
            this.cboWarehouse.DisplayMember = "Warenm";

            Task task = Task.Run(async () =>
            {
                this.cboWarehouse.DataSource = await this._presenter.SearchWarehouse();
            });

            task.Wait();

            if (!string.IsNullOrEmpty(Microsoft.Win32.Registry.GetValue("HKEY_CURRENT_USER\\Software\\BarcodeInspection", "Compky", string.Empty).ToString()))
            {
                this.txtCompky.Text = Microsoft.Win32.Registry.GetValue("HKEY_CURRENT_USER\\Software\\BarcodeInspection", "Compky", string.Empty).ToString();
            }

            if (!string.IsNullOrEmpty(Microsoft.Win32.Registry.GetValue("HKEY_CURRENT_USER\\Software\\BarcodeInspection", "Wareky", string.Empty).ToString()))
            {
                GlobalSetting.Instance.Wareky = Microsoft.Win32.Registry.GetValue("HKEY_CURRENT_USER\\Software\\BarcodeInspection", "Wareky", string.Empty).ToString();
                cboWarehouse.SelectedValue = GlobalSetting.Instance.Wareky;
            }

            if (!string.IsNullOrEmpty(Microsoft.Win32.Registry.GetValue("HKEY_CURRENT_USER\\Software\\BarcodeInspection", "Userid", string.Empty).ToString()))
            {
                this.txtUserId.Text = Microsoft.Win32.Registry.GetValue("HKEY_CURRENT_USER\\Software\\BarcodeInspection", "Userid", string.Empty).ToString();
            }
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            this._presenter.Login();
        }

        private async void txtCompky_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                cboWarehouse.DataSource = await this._presenter.SearchWarehouse();
            }
        }

        private void cboWarehouse_SelectedIndexChanged(object sender, EventArgs e)
        {
            Microsoft.Win32.Registry.SetValue("HKEY_CURRENT_USER\\Software\\BarcodeInspection", "Wareky", this.cboWarehouse.SelectedValue.ToString());
            GlobalSetting.Instance.Wareky = this.cboWarehouse.SelectedValue.ToString();
        }

        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                buttonOK.PerformClick();
            }
        }
    }
}