namespace BarcodeInspection
{
    partial class LOBSC020
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle16 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle17 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle18 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle19 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle20 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle21 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle22 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cboCustomer = new System.Windows.Forms.ComboBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.slipno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.compky = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.wareky = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rqshpd = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dlwrky = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dlwrnm = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ruteky = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rutenm = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lbbrcd = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dlvycd = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dlvynm = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.prodcd = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.prodnm = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ordqty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pickingTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pickingUser = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.shipTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.shipUser = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Font = new System.Drawing.Font("Gulim", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker1.Location = new System.Drawing.Point(112, 7);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(114, 26);
            this.dateTimePicker1.TabIndex = 17;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Gulim", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label2.Location = new System.Drawing.Point(12, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 16);
            this.label2.TabIndex = 16;
            this.label2.Text = "납품 요청일";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Gulim", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.Location = new System.Drawing.Point(267, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 16);
            this.label1.TabIndex = 15;
            this.label1.Text = "고객사";
            // 
            // cboCustomer
            // 
            this.cboCustomer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCustomer.Font = new System.Drawing.Font("Gulim", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.cboCustomer.FormattingEnabled = true;
            this.cboCustomer.Location = new System.Drawing.Point(334, 9);
            this.cboCustomer.Name = "cboCustomer";
            this.cboCustomer.Size = new System.Drawing.Size(175, 24);
            this.cboCustomer.TabIndex = 14;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.slipno,
            this.compky,
            this.wareky,
            this.rqshpd,
            this.dlwrky,
            this.dlwrnm,
            this.ruteky,
            this.rutenm,
            this.lbbrcd,
            this.dlvycd,
            this.dlvynm,
            this.prodcd,
            this.prodnm,
            this.ordqty,
            this.pickingTime,
            this.pickingUser,
            this.shipTime,
            this.shipUser});
            this.dataGridView1.Location = new System.Drawing.Point(12, 39);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(1074, 627);
            this.dataGridView1.TabIndex = 18;
            this.dataGridView1.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dataGridView1_RowPostPaint);
            // 
            // slipno
            // 
            this.slipno.DataPropertyName = "slipno";
            this.slipno.HeaderText = "전표번호";
            this.slipno.Name = "slipno";
            this.slipno.ReadOnly = true;
            // 
            // compky
            // 
            this.compky.DataPropertyName = "compky";
            this.compky.HeaderText = "compky";
            this.compky.Name = "compky";
            this.compky.ReadOnly = true;
            this.compky.Visible = false;
            // 
            // wareky
            // 
            this.wareky.DataPropertyName = "wareky";
            this.wareky.HeaderText = "wareky";
            this.wareky.Name = "wareky";
            this.wareky.ReadOnly = true;
            this.wareky.Visible = false;
            // 
            // rqshpd
            // 
            this.rqshpd.DataPropertyName = "rqshpd";
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle12.Format = "yyyy-MM-dd";
            this.rqshpd.DefaultCellStyle = dataGridViewCellStyle12;
            this.rqshpd.HeaderText = "납품요청일";
            this.rqshpd.Name = "rqshpd";
            this.rqshpd.ReadOnly = true;
            // 
            // dlwrky
            // 
            this.dlwrky.DataPropertyName = "dlwrky";
            dataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dlwrky.DefaultCellStyle = dataGridViewCellStyle13;
            this.dlwrky.HeaderText = "납품센터코드";
            this.dlwrky.Name = "dlwrky";
            this.dlwrky.ReadOnly = true;
            // 
            // dlwrnm
            // 
            this.dlwrnm.DataPropertyName = "dlwrnm";
            dataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dlwrnm.DefaultCellStyle = dataGridViewCellStyle14;
            this.dlwrnm.HeaderText = "납품센터명";
            this.dlwrnm.Name = "dlwrnm";
            this.dlwrnm.ReadOnly = true;
            // 
            // ruteky
            // 
            this.ruteky.DataPropertyName = "ruteky";
            dataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.ruteky.DefaultCellStyle = dataGridViewCellStyle15;
            this.ruteky.HeaderText = "배차코드";
            this.ruteky.Name = "ruteky";
            this.ruteky.ReadOnly = true;
            // 
            // rutenm
            // 
            this.rutenm.DataPropertyName = "rutenm";
            dataGridViewCellStyle16.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.rutenm.DefaultCellStyle = dataGridViewCellStyle16;
            this.rutenm.HeaderText = "배차명";
            this.rutenm.Name = "rutenm";
            this.rutenm.ReadOnly = true;
            // 
            // lbbrcd
            // 
            this.lbbrcd.DataPropertyName = "lbbrcd";
            dataGridViewCellStyle17.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.lbbrcd.DefaultCellStyle = dataGridViewCellStyle17;
            this.lbbrcd.HeaderText = "라벨바코드";
            this.lbbrcd.Name = "lbbrcd";
            this.lbbrcd.ReadOnly = true;
            this.lbbrcd.Width = 180;
            // 
            // dlvycd
            // 
            this.dlvycd.DataPropertyName = "dlvycd";
            dataGridViewCellStyle18.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dlvycd.DefaultCellStyle = dataGridViewCellStyle18;
            this.dlvycd.HeaderText = "매출처코드";
            this.dlvycd.Name = "dlvycd";
            this.dlvycd.ReadOnly = true;
            // 
            // dlvynm
            // 
            this.dlvynm.DataPropertyName = "dlvynm";
            dataGridViewCellStyle19.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dlvynm.DefaultCellStyle = dataGridViewCellStyle19;
            this.dlvynm.HeaderText = "매출처명";
            this.dlvynm.Name = "dlvynm";
            this.dlvynm.ReadOnly = true;
            this.dlvynm.Width = 120;
            // 
            // prodcd
            // 
            this.prodcd.DataPropertyName = "prodcd";
            dataGridViewCellStyle20.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.prodcd.DefaultCellStyle = dataGridViewCellStyle20;
            this.prodcd.HeaderText = "상품코드";
            this.prodcd.Name = "prodcd";
            this.prodcd.ReadOnly = true;
            // 
            // prodnm
            // 
            this.prodnm.DataPropertyName = "prodnm";
            dataGridViewCellStyle21.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle21.NullValue = null;
            this.prodnm.DefaultCellStyle = dataGridViewCellStyle21;
            this.prodnm.HeaderText = "상품명";
            this.prodnm.Name = "prodnm";
            this.prodnm.ReadOnly = true;
            this.prodnm.Width = 150;
            // 
            // ordqty
            // 
            this.ordqty.DataPropertyName = "ordqty";
            dataGridViewCellStyle22.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.ordqty.DefaultCellStyle = dataGridViewCellStyle22;
            this.ordqty.HeaderText = "수량";
            this.ordqty.Name = "ordqty";
            this.ordqty.ReadOnly = true;
            // 
            // pickingTime
            // 
            this.pickingTime.DataPropertyName = "pickingTime";
            this.pickingTime.HeaderText = "피킹시간";
            this.pickingTime.Name = "pickingTime";
            this.pickingTime.ReadOnly = true;
            // 
            // pickingUser
            // 
            this.pickingUser.DataPropertyName = "pickingUser";
            this.pickingUser.HeaderText = "피킹작업자";
            this.pickingUser.Name = "pickingUser";
            this.pickingUser.ReadOnly = true;
            // 
            // shipTime
            // 
            this.shipTime.DataPropertyName = "shipTime";
            this.shipTime.HeaderText = "출차시간";
            this.shipTime.Name = "shipTime";
            this.shipTime.ReadOnly = true;
            // 
            // shipUser
            // 
            this.shipUser.DataPropertyName = "shipUser";
            this.shipUser.HeaderText = "출차작업자";
            this.shipUser.Name = "shipUser";
            this.shipUser.ReadOnly = true;
            // 
            // LOBSC020
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1098, 678);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cboCustomer);
            this.Name = "LOBSC020";
            this.Text = "LOBSC020";
            this.Load += new System.EventHandler(this.LOBSC020_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboCustomer;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn slipno;
        private System.Windows.Forms.DataGridViewTextBoxColumn compky;
        private System.Windows.Forms.DataGridViewTextBoxColumn wareky;
        private System.Windows.Forms.DataGridViewTextBoxColumn rqshpd;
        private System.Windows.Forms.DataGridViewTextBoxColumn dlwrky;
        private System.Windows.Forms.DataGridViewTextBoxColumn dlwrnm;
        private System.Windows.Forms.DataGridViewTextBoxColumn ruteky;
        private System.Windows.Forms.DataGridViewTextBoxColumn rutenm;
        private System.Windows.Forms.DataGridViewTextBoxColumn lbbrcd;
        private System.Windows.Forms.DataGridViewTextBoxColumn dlvycd;
        private System.Windows.Forms.DataGridViewTextBoxColumn dlvynm;
        private System.Windows.Forms.DataGridViewTextBoxColumn prodcd;
        private System.Windows.Forms.DataGridViewTextBoxColumn prodnm;
        private System.Windows.Forms.DataGridViewTextBoxColumn ordqty;
        private System.Windows.Forms.DataGridViewTextBoxColumn pickingTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn pickingUser;
        private System.Windows.Forms.DataGridViewTextBoxColumn shipTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn shipUser;
    }
}