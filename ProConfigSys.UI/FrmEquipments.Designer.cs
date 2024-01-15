namespace BaseFramework.ProConfigSys
{
    partial class FrmEquipments
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmEquipments));
            this.btn_Save = new System.Windows.Forms.Button();
            this.txt_EquipmentName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblProjectName = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cmb_EType = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cmb_PType = new System.Windows.Forms.ComboBox();
            this.gb_Internet = new System.Windows.Forms.GroupBox();
            this.txt_PortNo = new System.Windows.Forms.TextBox();
            this.txt_IPAddress = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.gb_Com = new System.Windows.Forms.GroupBox();
            this.cmb_StopBit = new System.Windows.Forms.ComboBox();
            this.cmb_ParityBit = new System.Windows.Forms.ComboBox();
            this.cmb_DataBit = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.cmb_BaudRate = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.cmb_SerialNo = new System.Windows.Forms.ComboBox();
            this.gb_OPC = new System.Windows.Forms.GroupBox();
            this.txt_OPCServerName = new System.Windows.Forms.TextBox();
            this.txt_OPCNodeName = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.txt_Commons = new System.Windows.Forms.TextBox();
            this.ckb_IsEnable = new System.Windows.Forms.CheckBox();
            this.gb_Internet.SuspendLayout();
            this.gb_Com.SuspendLayout();
            this.gb_OPC.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_Save
            // 
            this.btn_Save.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btn_Save.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Save.Image = ((System.Drawing.Image)(resources.GetObject("btn_Save.Image")));
            this.btn_Save.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_Save.Location = new System.Drawing.Point(589, 364);
            this.btn_Save.Name = "btn_Save";
            this.btn_Save.Size = new System.Drawing.Size(122, 28);
            this.btn_Save.TabIndex = 5;
            this.btn_Save.Text = "  增加新设备";
            this.btn_Save.UseVisualStyleBackColor = false;
            this.btn_Save.Click += new System.EventHandler(this.btn_Save_Click);
            // 
            // txt_EquipmentName
            // 
            this.txt_EquipmentName.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txt_EquipmentName.Location = new System.Drawing.Point(466, 5);
            this.txt_EquipmentName.Name = "txt_EquipmentName";
            this.txt_EquipmentName.Size = new System.Drawing.Size(240, 23);
            this.txt_EquipmentName.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(32, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 14);
            this.label1.TabIndex = 3;
            this.label1.Text = "所属项目：";
            // 
            // lblProjectName
            // 
            this.lblProjectName.BackColor = System.Drawing.Color.Gold;
            this.lblProjectName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblProjectName.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblProjectName.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblProjectName.Location = new System.Drawing.Point(120, 5);
            this.lblProjectName.Name = "lblProjectName";
            this.lblProjectName.Size = new System.Drawing.Size(240, 23);
            this.lblProjectName.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(378, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 14);
            this.label3.TabIndex = 3;
            this.label3.Text = "设备名称：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(32, 41);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(82, 14);
            this.label4.TabIndex = 3;
            this.label4.Text = "设备类型：";
            // 
            // cmb_EType
            // 
            this.cmb_EType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_EType.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cmb_EType.FormattingEnabled = true;
            this.cmb_EType.Location = new System.Drawing.Point(120, 37);
            this.cmb_EType.Name = "cmb_EType";
            this.cmb_EType.Size = new System.Drawing.Size(240, 22);
            this.cmb_EType.TabIndex = 1;
            this.cmb_EType.SelectedIndexChanged += new System.EventHandler(this.cmb_EType_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(378, 41);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(82, 14);
            this.label5.TabIndex = 3;
            this.label5.Text = "协议类型：";
            // 
            // cmb_PType
            // 
            this.cmb_PType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_PType.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cmb_PType.FormattingEnabled = true;
            this.cmb_PType.Location = new System.Drawing.Point(466, 37);
            this.cmb_PType.Name = "cmb_PType";
            this.cmb_PType.Size = new System.Drawing.Size(240, 22);
            this.cmb_PType.TabIndex = 2;
            // 
            // gb_Internet
            // 
            this.gb_Internet.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.gb_Internet.Controls.Add(this.txt_PortNo);
            this.gb_Internet.Controls.Add(this.txt_IPAddress);
            this.gb_Internet.Controls.Add(this.label7);
            this.gb_Internet.Controls.Add(this.label6);
            this.gb_Internet.Location = new System.Drawing.Point(7, 74);
            this.gb_Internet.Name = "gb_Internet";
            this.gb_Internet.Size = new System.Drawing.Size(704, 76);
            this.gb_Internet.TabIndex = 3;
            this.gb_Internet.TabStop = false;
            this.gb_Internet.Text = "【以太网配置】";
            // 
            // txt_PortNo
            // 
            this.txt_PortNo.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txt_PortNo.Location = new System.Drawing.Point(459, 21);
            this.txt_PortNo.Name = "txt_PortNo";
            this.txt_PortNo.Size = new System.Drawing.Size(240, 23);
            this.txt_PortNo.TabIndex = 1;
            // 
            // txt_IPAddress
            // 
            this.txt_IPAddress.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txt_IPAddress.Location = new System.Drawing.Point(113, 21);
            this.txt_IPAddress.Name = "txt_IPAddress";
            this.txt_IPAddress.Size = new System.Drawing.Size(240, 23);
            this.txt_IPAddress.TabIndex = 0;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label7.Location = new System.Drawing.Point(386, 25);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(67, 14);
            this.label7.TabIndex = 3;
            this.label7.Text = "端口号：";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.Location = new System.Drawing.Point(39, 25);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(68, 14);
            this.label6.TabIndex = 3;
            this.label6.Text = "IP地址：";
            // 
            // gb_Com
            // 
            this.gb_Com.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.gb_Com.Controls.Add(this.cmb_StopBit);
            this.gb_Com.Controls.Add(this.cmb_ParityBit);
            this.gb_Com.Controls.Add(this.cmb_DataBit);
            this.gb_Com.Controls.Add(this.label10);
            this.gb_Com.Controls.Add(this.label12);
            this.gb_Com.Controls.Add(this.label8);
            this.gb_Com.Controls.Add(this.label11);
            this.gb_Com.Controls.Add(this.cmb_BaudRate);
            this.gb_Com.Controls.Add(this.label9);
            this.gb_Com.Controls.Add(this.cmb_SerialNo);
            this.gb_Com.Location = new System.Drawing.Point(7, 156);
            this.gb_Com.Name = "gb_Com";
            this.gb_Com.Size = new System.Drawing.Size(704, 96);
            this.gb_Com.TabIndex = 8;
            this.gb_Com.TabStop = false;
            this.gb_Com.Text = "【串口配置】";
            // 
            // cmb_StopBit
            // 
            this.cmb_StopBit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_StopBit.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cmb_StopBit.FormattingEnabled = true;
            this.cmb_StopBit.Items.AddRange(new object[] {
            "1",
            "2"});
            this.cmb_StopBit.Location = new System.Drawing.Point(569, 58);
            this.cmb_StopBit.Name = "cmb_StopBit";
            this.cmb_StopBit.Size = new System.Drawing.Size(129, 22);
            this.cmb_StopBit.TabIndex = 4;
            // 
            // cmb_ParityBit
            // 
            this.cmb_ParityBit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_ParityBit.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cmb_ParityBit.FormattingEnabled = true;
            this.cmb_ParityBit.Location = new System.Drawing.Point(337, 58);
            this.cmb_ParityBit.Name = "cmb_ParityBit";
            this.cmb_ParityBit.Size = new System.Drawing.Size(129, 22);
            this.cmb_ParityBit.TabIndex = 3;
            // 
            // cmb_DataBit
            // 
            this.cmb_DataBit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_DataBit.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cmb_DataBit.FormattingEnabled = true;
            this.cmb_DataBit.Items.AddRange(new object[] {
            "8"});
            this.cmb_DataBit.Location = new System.Drawing.Point(113, 58);
            this.cmb_DataBit.Name = "cmb_DataBit";
            this.cmb_DataBit.Size = new System.Drawing.Size(129, 22);
            this.cmb_DataBit.TabIndex = 2;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label10.Location = new System.Drawing.Point(264, 23);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(67, 14);
            this.label10.TabIndex = 3;
            this.label10.Text = "波特率：";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label12.Location = new System.Drawing.Point(496, 62);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(67, 14);
            this.label12.TabIndex = 3;
            this.label12.Text = "停止位：";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label8.Location = new System.Drawing.Point(40, 23);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(67, 14);
            this.label8.TabIndex = 3;
            this.label8.Text = "串口号：";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label11.Location = new System.Drawing.Point(264, 62);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(67, 14);
            this.label11.TabIndex = 3;
            this.label11.Text = "校验位：";
            // 
            // cmb_BaudRate
            // 
            this.cmb_BaudRate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_BaudRate.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cmb_BaudRate.FormattingEnabled = true;
            this.cmb_BaudRate.Items.AddRange(new object[] {
            "9600",
            "11520",
            "19200"});
            this.cmb_BaudRate.Location = new System.Drawing.Point(337, 20);
            this.cmb_BaudRate.Name = "cmb_BaudRate";
            this.cmb_BaudRate.Size = new System.Drawing.Size(129, 22);
            this.cmb_BaudRate.TabIndex = 1;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label9.Location = new System.Drawing.Point(40, 62);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(67, 14);
            this.label9.TabIndex = 3;
            this.label9.Text = "数据位：";
            // 
            // cmb_SerialNo
            // 
            this.cmb_SerialNo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_SerialNo.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cmb_SerialNo.FormattingEnabled = true;
            this.cmb_SerialNo.Location = new System.Drawing.Point(113, 20);
            this.cmb_SerialNo.Name = "cmb_SerialNo";
            this.cmb_SerialNo.Size = new System.Drawing.Size(129, 22);
            this.cmb_SerialNo.TabIndex = 0;
            this.cmb_SerialNo.DropDown += new System.EventHandler(this.cmb_SerialNo_DropDown);
            // 
            // gb_OPC
            // 
            this.gb_OPC.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.gb_OPC.Controls.Add(this.txt_OPCServerName);
            this.gb_OPC.Controls.Add(this.txt_OPCNodeName);
            this.gb_OPC.Controls.Add(this.label13);
            this.gb_OPC.Controls.Add(this.label14);
            this.gb_OPC.Location = new System.Drawing.Point(7, 258);
            this.gb_OPC.Name = "gb_OPC";
            this.gb_OPC.Size = new System.Drawing.Size(704, 76);
            this.gb_OPC.TabIndex = 8;
            this.gb_OPC.TabStop = false;
            this.gb_OPC.Text = "【OPC配置】";
            // 
            // txt_OPCServerName
            // 
            this.txt_OPCServerName.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txt_OPCServerName.Location = new System.Drawing.Point(459, 21);
            this.txt_OPCServerName.Name = "txt_OPCServerName";
            this.txt_OPCServerName.Size = new System.Drawing.Size(240, 23);
            this.txt_OPCServerName.TabIndex = 1;
            // 
            // txt_OPCNodeName
            // 
            this.txt_OPCNodeName.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txt_OPCNodeName.Location = new System.Drawing.Point(113, 21);
            this.txt_OPCNodeName.Name = "txt_OPCNodeName";
            this.txt_OPCNodeName.Size = new System.Drawing.Size(240, 23);
            this.txt_OPCNodeName.TabIndex = 0;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label13.Location = new System.Drawing.Point(386, 25);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(82, 14);
            this.label13.TabIndex = 3;
            this.label13.Text = "服务器名：";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label14.Location = new System.Drawing.Point(25, 25);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(82, 14);
            this.label14.TabIndex = 3;
            this.label14.Text = "节点名称：";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label15.Location = new System.Drawing.Point(62, 341);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(52, 14);
            this.label15.TabIndex = 3;
            this.label15.Text = "备注：";
            // 
            // txt_Commons
            // 
            this.txt_Commons.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txt_Commons.Location = new System.Drawing.Point(120, 338);
            this.txt_Commons.Multiline = true;
            this.txt_Commons.Name = "txt_Commons";
            this.txt_Commons.Size = new System.Drawing.Size(340, 54);
            this.txt_Commons.TabIndex = 4;
            // 
            // ckb_IsEnable
            // 
            this.ckb_IsEnable.AutoSize = true;
            this.ckb_IsEnable.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ckb_IsEnable.Location = new System.Drawing.Point(484, 374);
            this.ckb_IsEnable.Name = "ckb_IsEnable";
            this.ckb_IsEnable.Size = new System.Drawing.Size(86, 18);
            this.ckb_IsEnable.TabIndex = 9;
            this.ckb_IsEnable.Text = "是否启用";
            this.ckb_IsEnable.UseVisualStyleBackColor = true;
            // 
            // FrmEquipments
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(731, 413);
            this.Controls.Add(this.ckb_IsEnable);
            this.Controls.Add(this.gb_Com);
            this.Controls.Add(this.txt_Commons);
            this.Controls.Add(this.gb_OPC);
            this.Controls.Add(this.gb_Internet);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.cmb_PType);
            this.Controls.Add(this.cmb_EType);
            this.Controls.Add(this.lblProjectName);
            this.Controls.Add(this.btn_Save);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txt_EquipmentName);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmEquipments";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "【设备管理】";
            this.gb_Internet.ResumeLayout(false);
            this.gb_Internet.PerformLayout();
            this.gb_Com.ResumeLayout(false);
            this.gb_Com.PerformLayout();
            this.gb_OPC.ResumeLayout(false);
            this.gb_OPC.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_Save;
        private System.Windows.Forms.TextBox txt_EquipmentName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblProjectName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmb_EType;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cmb_PType;
        private System.Windows.Forms.GroupBox gb_Internet;
        private System.Windows.Forms.TextBox txt_PortNo;
        private System.Windows.Forms.TextBox txt_IPAddress;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox gb_Com;
        private System.Windows.Forms.ComboBox cmb_DataBit;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cmb_SerialNo;
        private System.Windows.Forms.ComboBox cmb_StopBit;
        private System.Windows.Forms.ComboBox cmb_ParityBit;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox cmb_BaudRate;
        private System.Windows.Forms.GroupBox gb_OPC;
        private System.Windows.Forms.TextBox txt_OPCServerName;
        private System.Windows.Forms.TextBox txt_OPCNodeName;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox txt_Commons;
        private System.Windows.Forms.CheckBox ckb_IsEnable;
    }
}