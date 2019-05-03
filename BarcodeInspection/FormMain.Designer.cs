namespace BarcodeInspection
{
    partial class FormMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.ToolStripMenuItemOutbound = new System.Windows.Forms.ToolStripMenuItem();
            this.LOBSC010ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.LOBSC020ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.toolStripBtnSearch = new System.Windows.Forms.ToolStripButton();
            this.toolStripBtnSave = new System.Windows.Forms.ToolStripButton();
            this.toolStripBtnConfirm = new System.Windows.Forms.ToolStripButton();
            this.toolStripBtnDownload = new System.Windows.Forms.ToolStripButton();
            this.toolStripBtnUpload = new System.Windows.Forms.ToolStripButton();
            this.toolStripBtnPrint = new System.Windows.Forms.ToolStripButton();
            this.toolStripBtnClear = new System.Windows.Forms.ToolStripButton();
            this.toolStripBtnClose = new System.Windows.Forms.ToolStripButton();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.menuStrip.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.toolStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripMenuItemOutbound});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Padding = new System.Windows.Forms.Padding(7, 2, 0, 2);
            this.menuStrip.Size = new System.Drawing.Size(996, 24);
            this.menuStrip.TabIndex = 0;
            this.menuStrip.Text = "MenuStrip";
            // 
            // ToolStripMenuItemOutbound
            // 
            this.ToolStripMenuItemOutbound.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.LOBSC010ToolStripMenuItem,
            this.LOBSC020ToolStripMenuItem});
            this.ToolStripMenuItemOutbound.Name = "ToolStripMenuItemOutbound";
            this.ToolStripMenuItemOutbound.Size = new System.Drawing.Size(67, 20);
            this.ToolStripMenuItemOutbound.Text = "출고관리";
            // 
            // LOBSC010ToolStripMenuItem
            // 
            this.LOBSC010ToolStripMenuItem.Name = "LOBSC010ToolStripMenuItem";
            this.LOBSC010ToolStripMenuItem.Size = new System.Drawing.Size(220, 22);
            this.LOBSC010ToolStripMenuItem.Text = "[LOBSC010] 엑셀 업로드";
            this.LOBSC010ToolStripMenuItem.Click += new System.EventHandler(this.LOBSC010ToolStripMenuItem_Click);
            // 
            // LOBSC020ToolStripMenuItem
            // 
            this.LOBSC020ToolStripMenuItem.Name = "LOBSC020ToolStripMenuItem";
            this.LOBSC020ToolStripMenuItem.Size = new System.Drawing.Size(220, 22);
            this.LOBSC020ToolStripMenuItem.Text = "[LOBSC020] 스캔 처리현황";
            this.LOBSC020ToolStripMenuItem.Click += new System.EventHandler(this.LOBSC020ToolStripMenuItem_Click);
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel});
            this.statusStrip.Location = new System.Drawing.Point(0, 684);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Padding = new System.Windows.Forms.Padding(1, 0, 16, 0);
            this.statusStrip.Size = new System.Drawing.Size(996, 22);
            this.statusStrip.TabIndex = 2;
            this.statusStrip.Text = "StatusStrip";
            // 
            // toolStripStatusLabel
            // 
            this.toolStripStatusLabel.Name = "toolStripStatusLabel";
            this.toolStripStatusLabel.Size = new System.Drawing.Size(40, 17);
            this.toolStripStatusLabel.Text = "Status";
            // 
            // toolStrip
            // 
            this.toolStrip.AutoSize = false;
            this.toolStrip.ImageScalingSize = new System.Drawing.Size(40, 40);
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripBtnSearch,
            this.toolStripBtnSave,
            this.toolStripBtnConfirm,
            this.toolStripBtnDownload,
            this.toolStripBtnUpload,
            this.toolStripBtnPrint,
            this.toolStripBtnClear,
            this.toolStripBtnClose});
            this.toolStrip.Location = new System.Drawing.Point(0, 24);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.Padding = new System.Windows.Forms.Padding(0);
            this.toolStrip.Size = new System.Drawing.Size(996, 45);
            this.toolStrip.TabIndex = 4;
            this.toolStrip.Text = "ToolStrip";
            // 
            // toolStripBtnSearch
            // 
            this.toolStripBtnSearch.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.toolStripBtnSearch.Font = new System.Drawing.Font("Malgun Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.toolStripBtnSearch.Image = ((System.Drawing.Image)(resources.GetObject("toolStripBtnSearch.Image")));
            this.toolStripBtnSearch.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripBtnSearch.Name = "toolStripBtnSearch";
            this.toolStripBtnSearch.Size = new System.Drawing.Size(99, 42);
            this.toolStripBtnSearch.Text = "조회(F2)";
            this.toolStripBtnSearch.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.toolStripBtnSearch.Click += new System.EventHandler(this.toolStripBtnSearch_Click);
            // 
            // toolStripBtnSave
            // 
            this.toolStripBtnSave.Font = new System.Drawing.Font("Malgun Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.toolStripBtnSave.Image = ((System.Drawing.Image)(resources.GetObject("toolStripBtnSave.Image")));
            this.toolStripBtnSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripBtnSave.Name = "toolStripBtnSave";
            this.toolStripBtnSave.Size = new System.Drawing.Size(99, 42);
            this.toolStripBtnSave.Text = "저장(F3)";
            this.toolStripBtnSave.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.toolStripBtnSave.Click += new System.EventHandler(this.toolStripBtnSave_Click);
            // 
            // toolStripBtnConfirm
            // 
            this.toolStripBtnConfirm.Font = new System.Drawing.Font("Malgun Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.toolStripBtnConfirm.Image = ((System.Drawing.Image)(resources.GetObject("toolStripBtnConfirm.Image")));
            this.toolStripBtnConfirm.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripBtnConfirm.Name = "toolStripBtnConfirm";
            this.toolStripBtnConfirm.Size = new System.Drawing.Size(106, 42);
            this.toolStripBtnConfirm.Text = "확정(F12)";
            this.toolStripBtnConfirm.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.toolStripBtnConfirm.Click += new System.EventHandler(this.toolStripBtnConfirm_Click);
            // 
            // toolStripBtnDownload
            // 
            this.toolStripBtnDownload.Font = new System.Drawing.Font("Malgun Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.toolStripBtnDownload.Image = ((System.Drawing.Image)(resources.GetObject("toolStripBtnDownload.Image")));
            this.toolStripBtnDownload.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripBtnDownload.Name = "toolStripBtnDownload";
            this.toolStripBtnDownload.Size = new System.Drawing.Size(125, 42);
            this.toolStripBtnDownload.Text = "다운로드(F5)";
            this.toolStripBtnDownload.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.toolStripBtnDownload.Click += new System.EventHandler(this.toolStripBtnDownload_Click);
            // 
            // toolStripBtnUpload
            // 
            this.toolStripBtnUpload.Font = new System.Drawing.Font("Malgun Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.toolStripBtnUpload.Image = ((System.Drawing.Image)(resources.GetObject("toolStripBtnUpload.Image")));
            this.toolStripBtnUpload.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripBtnUpload.Name = "toolStripBtnUpload";
            this.toolStripBtnUpload.Size = new System.Drawing.Size(112, 42);
            this.toolStripBtnUpload.Text = "업로드(F6)";
            this.toolStripBtnUpload.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.toolStripBtnUpload.Click += new System.EventHandler(this.toolStripBtnUpload_Click);
            // 
            // toolStripBtnPrint
            // 
            this.toolStripBtnPrint.Font = new System.Drawing.Font("Malgun Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.toolStripBtnPrint.Image = ((System.Drawing.Image)(resources.GetObject("toolStripBtnPrint.Image")));
            this.toolStripBtnPrint.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripBtnPrint.Name = "toolStripBtnPrint";
            this.toolStripBtnPrint.Size = new System.Drawing.Size(99, 42);
            this.toolStripBtnPrint.Text = "출력(F7)";
            // 
            // toolStripBtnClear
            // 
            this.toolStripBtnClear.Font = new System.Drawing.Font("Malgun Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.toolStripBtnClear.Image = ((System.Drawing.Image)(resources.GetObject("toolStripBtnClear.Image")));
            this.toolStripBtnClear.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripBtnClear.Name = "toolStripBtnClear";
            this.toolStripBtnClear.Size = new System.Drawing.Size(103, 42);
            this.toolStripBtnClear.Text = "Clear(F8)";
            this.toolStripBtnClear.Click += new System.EventHandler(this.toolStripBtnClear_Click);
            // 
            // toolStripBtnClose
            // 
            this.toolStripBtnClose.Font = new System.Drawing.Font("Malgun Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.toolStripBtnClose.Image = ((System.Drawing.Image)(resources.GetObject("toolStripBtnClose.Image")));
            this.toolStripBtnClose.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripBtnClose.Name = "toolStripBtnClose";
            this.toolStripBtnClose.Size = new System.Drawing.Size(99, 42);
            this.toolStripBtnClose.Text = "닫기(F9)";
            this.toolStripBtnClose.Click += new System.EventHandler(this.toolStripBtnClose_Click);
            // 
            // tabControl
            // 
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Top;
            this.tabControl.Location = new System.Drawing.Point(0, 69);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(996, 23);
            this.tabControl.TabIndex = 9;
            this.tabControl.SelectedIndexChanged += new System.EventHandler(this.tabControl_SelectedIndexChanged);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(996, 706);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.toolStrip);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.menuStrip);
            this.IsMdiContainer = true;
            this.KeyPreview = true;
            this.MainMenuStrip = this.menuStrip;
            this.Name = "FormMain";
            this.Text = "FormMain";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.MdiChildActivate += new System.EventHandler(this.FormMain_MdiChildActivate);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FormMain_KeyDown);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion


        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemOutbound;
        private System.Windows.Forms.ToolStripMenuItem LOBSC010ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem LOBSC020ToolStripMenuItem;
        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.ToolStripButton toolStripBtnSearch;
        private System.Windows.Forms.ToolStripButton toolStripBtnConfirm;
        private System.Windows.Forms.ToolStripButton toolStripBtnDownload;
        private System.Windows.Forms.ToolStripButton toolStripBtnPrint;
        private System.Windows.Forms.ToolStripButton toolStripBtnClose;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.ToolStripButton toolStripBtnUpload;
        private System.Windows.Forms.ToolStripButton toolStripBtnClear;
        private System.Windows.Forms.ToolStripButton toolStripBtnSave;
    }
}



