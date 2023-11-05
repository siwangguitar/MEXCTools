namespace MEXCTools
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            splitContainer1 = new SplitContainer();
            btnAddAccount = new Button();
            btnGetAccountInfo = new Button();
            label2 = new Label();
            cmbMEXCAccount = new ComboBox();
            txtLog = new TextBox();
            tabControl1 = new TabControl();
            tabPage1 = new TabPage();
            listView1 = new ListViewEx();
            colSeq = new ColumnHeader();
            colAddress = new ColumnHeader();
            colAmount = new ColumnHeader();
            colInfo = new ColumnHeader();
            cmsLv = new ContextMenuStrip(components);
            tslvImport = new ToolStripMenuItem();
            btnStop = new Button();
            label3 = new Label();
            btnMW = new Button();
            cmbCoins = new ComboBox();
            txtMaxDelay = new TextBox();
            label4 = new Label();
            label6 = new Label();
            cmbNetworks = new ComboBox();
            txtMinDelay = new TextBox();
            label5 = new Label();
            tabPage2 = new TabPage();
            btnCancelTask = new Button();
            txtIp = new TextBox();
            label1 = new Label();
            btnCreateSubAccountApi = new Button();
            cmbSACoins = new ComboBox();
            btnTransferFromSA = new Button();
            btnGetSubAccountInfo = new Button();
            btnListSunAccount = new Button();
            txtSACount = new TextBox();
            label9 = new Label();
            lvSubAccount = new ListViewEx();
            colSASeq = new ColumnHeader();
            colSASubAccount = new ColumnHeader();
            colSAInfo = new ColumnHeader();
            cmsLvSA = new ContextMenuStrip(components);
            tsSACopyTable = new ToolStripMenuItem();
            txtSANameSeq = new TextBox();
            label8 = new Label();
            txtSAName = new TextBox();
            label7 = new Label();
            btnCreateSubAccount = new Button();
            panel1 = new Panel();
            panel2 = new Panel();
            labCountdown = new Label();
            btnclearLv = new Button();
            btnDeselect = new Button();
            btnSelectAll = new Button();
            btnGetSAAddress = new Button();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            cmsLv.SuspendLayout();
            tabPage2.SuspendLayout();
            cmsLvSA.SuspendLayout();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.Location = new Point(0, 0);
            splitContainer1.Name = "splitContainer1";
            splitContainer1.Orientation = Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(btnAddAccount);
            splitContainer1.Panel1.Controls.Add(btnGetAccountInfo);
            splitContainer1.Panel1.Controls.Add(label2);
            splitContainer1.Panel1.Controls.Add(cmbMEXCAccount);
            splitContainer1.Panel1.Controls.Add(txtLog);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(tabControl1);
            splitContainer1.Panel2.Controls.Add(panel1);
            splitContainer1.Size = new Size(855, 619);
            splitContainer1.SplitterDistance = 88;
            splitContainer1.TabIndex = 4;
            // 
            // btnAddAccount
            // 
            btnAddAccount.Location = new Point(10, 58);
            btnAddAccount.Name = "btnAddAccount";
            btnAddAccount.Size = new Size(75, 23);
            btnAddAccount.TabIndex = 20;
            btnAddAccount.Text = "添加";
            btnAddAccount.UseVisualStyleBackColor = true;
            btnAddAccount.Click += btnAddAccount_Click;
            // 
            // btnGetAccountInfo
            // 
            btnGetAccountInfo.Location = new Point(295, 58);
            btnGetAccountInfo.Name = "btnGetAccountInfo";
            btnGetAccountInfo.Size = new Size(75, 23);
            btnGetAccountInfo.TabIndex = 19;
            btnGetAccountInfo.Text = "账户信息";
            btnGetAccountInfo.UseVisualStyleBackColor = true;
            btnGetAccountInfo.Click += btnGetAccountInfo_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 7);
            label2.Name = "label2";
            label2.Size = new Size(47, 17);
            label2.TabIndex = 20;
            label2.Text = "主账户:";
            // 
            // cmbMEXCAccount
            // 
            cmbMEXCAccount.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbMEXCAccount.FormattingEnabled = true;
            cmbMEXCAccount.Location = new Point(10, 27);
            cmbMEXCAccount.Name = "cmbMEXCAccount";
            cmbMEXCAccount.Size = new Size(360, 25);
            cmbMEXCAccount.TabIndex = 19;
            cmbMEXCAccount.SelectedIndexChanged += cmbMEXCAccount_SelectedIndexChanged;
            // 
            // txtLog
            // 
            txtLog.Dock = DockStyle.Right;
            txtLog.Location = new Point(376, 0);
            txtLog.Multiline = true;
            txtLog.Name = "txtLog";
            txtLog.ScrollBars = ScrollBars.Vertical;
            txtLog.Size = new Size(479, 88);
            txtLog.TabIndex = 18;
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Dock = DockStyle.Fill;
            tabControl1.Location = new Point(0, 0);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(855, 496);
            tabControl1.TabIndex = 21;
            tabControl1.Tag = "子账户";
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(listView1);
            tabPage1.Controls.Add(btnStop);
            tabPage1.Controls.Add(label3);
            tabPage1.Controls.Add(btnMW);
            tabPage1.Controls.Add(cmbCoins);
            tabPage1.Controls.Add(txtMaxDelay);
            tabPage1.Controls.Add(label4);
            tabPage1.Controls.Add(label6);
            tabPage1.Controls.Add(cmbNetworks);
            tabPage1.Controls.Add(txtMinDelay);
            tabPage1.Controls.Add(label5);
            tabPage1.Location = new Point(4, 26);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(847, 466);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "提现";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // listView1
            // 
            listView1.CheckBoxes = true;
            listView1.Columns.AddRange(new ColumnHeader[] { colSeq, colAddress, colAmount, colInfo });
            listView1.ContextMenuStrip = cmsLv;
            listView1.Dock = DockStyle.Bottom;
            listView1.FullRowSelect = true;
            listView1.GridLines = true;
            listView1.Location = new Point(3, 74);
            listView1.Name = "listView1";
            listView1.Size = new Size(841, 389);
            listView1.TabIndex = 0;
            listView1.UseCompatibleStateImageBehavior = false;
            listView1.View = View.Details;
            // 
            // colSeq
            // 
            colSeq.Text = "序号";
            // 
            // colAddress
            // 
            colAddress.Text = "地址";
            colAddress.Width = 280;
            // 
            // colAmount
            // 
            colAmount.Text = "数量";
            colAmount.Width = 100;
            // 
            // colInfo
            // 
            colInfo.Text = "信息";
            colInfo.Width = 300;
            // 
            // cmsLv
            // 
            cmsLv.Items.AddRange(new ToolStripItem[] { tslvImport });
            cmsLv.Name = "cmsLv";
            cmsLv.Size = new Size(137, 26);
            // 
            // tslvImport
            // 
            tslvImport.Name = "tslvImport";
            tslvImport.Size = new Size(136, 22);
            tslvImport.Text = "导致新地址";
            tslvImport.Click += tslvImport_Click;
            // 
            // btnStop
            // 
            btnStop.Location = new Point(272, 12);
            btnStop.Name = "btnStop";
            btnStop.Size = new Size(75, 23);
            btnStop.TabIndex = 17;
            btnStop.Text = "停止";
            btnStop.UseVisualStyleBackColor = true;
            btnStop.Click += btnStop_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(6, 17);
            label3.Name = "label3";
            label3.Size = new Size(35, 17);
            label3.TabIndex = 8;
            label3.Text = "币种:";
            // 
            // btnMW
            // 
            btnMW.Location = new Point(272, 41);
            btnMW.Name = "btnMW";
            btnMW.Size = new Size(75, 23);
            btnMW.TabIndex = 16;
            btnMW.Text = "提现";
            btnMW.UseVisualStyleBackColor = true;
            btnMW.Click += btnMW_Click;
            // 
            // cmbCoins
            // 
            cmbCoins.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbCoins.FormattingEnabled = true;
            cmbCoins.Items.AddRange(new object[] { "OKB" });
            cmbCoins.Location = new Point(47, 13);
            cmbCoins.Name = "cmbCoins";
            cmbCoins.Size = new Size(72, 25);
            cmbCoins.TabIndex = 9;
            // 
            // txtMaxDelay
            // 
            txtMaxDelay.Location = new Point(202, 41);
            txtMaxDelay.Name = "txtMaxDelay";
            txtMaxDelay.Size = new Size(64, 23);
            txtMaxDelay.TabIndex = 15;
            txtMaxDelay.Text = "15";
            txtMaxDelay.TextAlign = HorizontalAlignment.Center;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(6, 46);
            label4.Name = "label4";
            label4.Size = new Size(35, 17);
            label4.TabIndex = 10;
            label4.Text = "网络:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(125, 45);
            label6.Name = "label6";
            label6.Size = new Size(71, 17);
            label6.TabIndex = 14;
            label6.Text = "延时最大秒:";
            // 
            // cmbNetworks
            // 
            cmbNetworks.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbNetworks.FormattingEnabled = true;
            cmbNetworks.Items.AddRange(new object[] { "OKT", "BEP20(BSC)" });
            cmbNetworks.Location = new Point(47, 42);
            cmbNetworks.Name = "cmbNetworks";
            cmbNetworks.Size = new Size(72, 25);
            cmbNetworks.TabIndex = 11;
            // 
            // txtMinDelay
            // 
            txtMinDelay.Location = new Point(202, 13);
            txtMinDelay.Name = "txtMinDelay";
            txtMinDelay.Size = new Size(64, 23);
            txtMinDelay.TabIndex = 13;
            txtMinDelay.Text = "5";
            txtMinDelay.TextAlign = HorizontalAlignment.Center;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(125, 17);
            label5.Name = "label5";
            label5.Size = new Size(71, 17);
            label5.TabIndex = 12;
            label5.Text = "延时最小秒:";
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(btnGetSAAddress);
            tabPage2.Controls.Add(btnCancelTask);
            tabPage2.Controls.Add(txtIp);
            tabPage2.Controls.Add(label1);
            tabPage2.Controls.Add(btnCreateSubAccountApi);
            tabPage2.Controls.Add(cmbSACoins);
            tabPage2.Controls.Add(btnTransferFromSA);
            tabPage2.Controls.Add(btnGetSubAccountInfo);
            tabPage2.Controls.Add(btnListSunAccount);
            tabPage2.Controls.Add(txtSACount);
            tabPage2.Controls.Add(label9);
            tabPage2.Controls.Add(lvSubAccount);
            tabPage2.Controls.Add(txtSANameSeq);
            tabPage2.Controls.Add(label8);
            tabPage2.Controls.Add(txtSAName);
            tabPage2.Controls.Add(label7);
            tabPage2.Controls.Add(btnCreateSubAccount);
            tabPage2.Location = new Point(4, 26);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(847, 466);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "子账户";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // btnCancelTask
            // 
            btnCancelTask.Location = new Point(195, 9);
            btnCancelTask.Name = "btnCancelTask";
            btnCancelTask.Size = new Size(75, 23);
            btnCancelTask.TabIndex = 36;
            btnCancelTask.Text = "取消任务";
            btnCancelTask.UseVisualStyleBackColor = true;
            btnCancelTask.Click += btnCancelTask_Click;
            // 
            // txtIp
            // 
            txtIp.Location = new Point(421, 9);
            txtIp.Name = "txtIp";
            txtIp.Size = new Size(250, 23);
            txtIp.TabIndex = 35;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(369, 12);
            label1.Name = "label1";
            label1.Size = new Size(46, 17);
            label1.TabIndex = 34;
            label1.Text = "绑定ip:";
            // 
            // btnCreateSubAccountApi
            // 
            btnCreateSubAccountApi.Location = new Point(596, 38);
            btnCreateSubAccountApi.Name = "btnCreateSubAccountApi";
            btnCreateSubAccountApi.Size = new Size(75, 23);
            btnCreateSubAccountApi.TabIndex = 33;
            btnCreateSubAccountApi.Text = "创建api";
            btnCreateSubAccountApi.UseVisualStyleBackColor = true;
            btnCreateSubAccountApi.Click += btnCreateSubAccountApi_Click;
            // 
            // cmbSACoins
            // 
            cmbSACoins.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbSACoins.FormattingEnabled = true;
            cmbSACoins.Items.AddRange(new object[] { "OKB" });
            cmbSACoins.Location = new Point(94, 9);
            cmbSACoins.Name = "cmbSACoins";
            cmbSACoins.Size = new Size(82, 25);
            cmbSACoins.TabIndex = 32;
            // 
            // btnTransferFromSA
            // 
            btnTransferFromSA.Location = new Point(94, 38);
            btnTransferFromSA.Name = "btnTransferFromSA";
            btnTransferFromSA.Size = new Size(82, 23);
            btnTransferFromSA.TabIndex = 31;
            btnTransferFromSA.Text = "转入主账户";
            btnTransferFromSA.UseVisualStyleBackColor = true;
            btnTransferFromSA.Click += btnTransferFromSA_Click;
            // 
            // btnGetSubAccountInfo
            // 
            btnGetSubAccountInfo.Location = new Point(8, 38);
            btnGetSubAccountInfo.Name = "btnGetSubAccountInfo";
            btnGetSubAccountInfo.Size = new Size(75, 23);
            btnGetSubAccountInfo.TabIndex = 30;
            btnGetSubAccountInfo.Text = "账户信息";
            btnGetSubAccountInfo.UseVisualStyleBackColor = true;
            btnGetSubAccountInfo.Click += btnGetSubAccountInfo_Click;
            // 
            // btnListSunAccount
            // 
            btnListSunAccount.Location = new Point(8, 9);
            btnListSunAccount.Name = "btnListSunAccount";
            btnListSunAccount.Size = new Size(75, 23);
            btnListSunAccount.TabIndex = 29;
            btnListSunAccount.Text = "账户列表";
            btnListSunAccount.UseVisualStyleBackColor = true;
            btnListSunAccount.Click += btnListSunAccount_Click;
            // 
            // txtSACount
            // 
            txtSACount.Location = new Point(799, 64);
            txtSACount.Name = "txtSACount";
            txtSACount.Size = new Size(42, 23);
            txtSACount.TabIndex = 28;
            txtSACount.Text = "30";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(758, 67);
            label9.Name = "label9";
            label9.Size = new Size(35, 17);
            label9.TabIndex = 27;
            label9.Text = "数量:";
            // 
            // lvSubAccount
            // 
            lvSubAccount.CheckBoxes = true;
            lvSubAccount.Columns.AddRange(new ColumnHeader[] { colSASeq, colSASubAccount, colSAInfo });
            lvSubAccount.ContextMenuStrip = cmsLvSA;
            lvSubAccount.Dock = DockStyle.Bottom;
            lvSubAccount.FullRowSelect = true;
            lvSubAccount.GridLines = true;
            lvSubAccount.Location = new Point(3, 94);
            lvSubAccount.Name = "lvSubAccount";
            lvSubAccount.Size = new Size(841, 369);
            lvSubAccount.TabIndex = 26;
            lvSubAccount.UseCompatibleStateImageBehavior = false;
            lvSubAccount.View = View.Details;
            // 
            // colSASeq
            // 
            colSASeq.Text = "序号";
            // 
            // colSASubAccount
            // 
            colSASubAccount.Text = "子账户";
            colSASubAccount.Width = 280;
            // 
            // colSAInfo
            // 
            colSAInfo.Text = "信息";
            colSAInfo.Width = 400;
            // 
            // cmsLvSA
            // 
            cmsLvSA.Items.AddRange(new ToolStripItem[] { tsSACopyTable });
            cmsLvSA.Name = "cmsLvSA";
            cmsLvSA.Size = new Size(145, 26);
            // 
            // tsSACopyTable
            // 
            tsSACopyTable.Name = "tsSACopyTable";
            tsSACopyTable.Size = new Size(144, 22);
            tsSACopyTable.Text = "[复制]选中行";
            tsSACopyTable.Click += tsSACopyTable_Click;
            // 
            // txtSANameSeq
            // 
            txtSANameSeq.Location = new Point(742, 35);
            txtSANameSeq.Name = "txtSANameSeq";
            txtSANameSeq.Size = new Size(100, 23);
            txtSANameSeq.TabIndex = 25;
            txtSANameSeq.Text = "1001";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(677, 38);
            label8.Name = "label8";
            label8.Size = new Size(59, 17);
            label8.TabIndex = 24;
            label8.Text = "开始序号:";
            // 
            // txtSAName
            // 
            txtSAName.Location = new Point(742, 6);
            txtSAName.Name = "txtSAName";
            txtSAName.Size = new Size(100, 23);
            txtSAName.TabIndex = 23;
            txtSAName.Text = "ranshao";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(677, 9);
            label7.Name = "label7";
            label7.Size = new Size(59, 17);
            label7.TabIndex = 22;
            label7.Text = "名字前缀:";
            // 
            // btnCreateSubAccount
            // 
            btnCreateSubAccount.Location = new Point(677, 64);
            btnCreateSubAccount.Name = "btnCreateSubAccount";
            btnCreateSubAccount.Size = new Size(75, 23);
            btnCreateSubAccount.TabIndex = 21;
            btnCreateSubAccount.Text = "创建子账户";
            btnCreateSubAccount.UseVisualStyleBackColor = true;
            btnCreateSubAccount.Click += btnCreateSubAccount_Click;
            // 
            // panel1
            // 
            panel1.Controls.Add(panel2);
            panel1.Controls.Add(btnclearLv);
            panel1.Controls.Add(btnDeselect);
            panel1.Controls.Add(btnSelectAll);
            panel1.Dock = DockStyle.Bottom;
            panel1.Location = new Point(0, 496);
            panel1.Name = "panel1";
            panel1.Size = new Size(855, 31);
            panel1.TabIndex = 1;
            // 
            // panel2
            // 
            panel2.Controls.Add(labCountdown);
            panel2.Dock = DockStyle.Right;
            panel2.Location = new Point(186, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(669, 31);
            panel2.TabIndex = 3;
            // 
            // labCountdown
            // 
            labCountdown.AutoSize = true;
            labCountdown.Location = new Point(55, 7);
            labCountdown.Name = "labCountdown";
            labCountdown.Size = new Size(33, 17);
            labCountdown.TabIndex = 0;
            labCountdown.Text = "time";
            // 
            // btnclearLv
            // 
            btnclearLv.Location = new Point(125, 3);
            btnclearLv.Name = "btnclearLv";
            btnclearLv.Size = new Size(55, 23);
            btnclearLv.TabIndex = 2;
            btnclearLv.Text = "清空";
            btnclearLv.UseVisualStyleBackColor = true;
            btnclearLv.Click += btnclearLv_Click;
            // 
            // btnDeselect
            // 
            btnDeselect.Location = new Point(64, 3);
            btnDeselect.Name = "btnDeselect";
            btnDeselect.Size = new Size(55, 23);
            btnDeselect.TabIndex = 1;
            btnDeselect.Text = "取消";
            btnDeselect.UseVisualStyleBackColor = true;
            btnDeselect.Click += btnDeselect_Click;
            // 
            // btnSelectAll
            // 
            btnSelectAll.Location = new Point(3, 3);
            btnSelectAll.Name = "btnSelectAll";
            btnSelectAll.Size = new Size(55, 23);
            btnSelectAll.TabIndex = 0;
            btnSelectAll.Text = "全选";
            btnSelectAll.UseVisualStyleBackColor = true;
            btnSelectAll.Click += btnSelectAll_Click;
            // 
            // btnGetSAAddress
            // 
            btnGetSAAddress.Location = new Point(8, 65);
            btnGetSAAddress.Name = "btnGetSAAddress";
            btnGetSAAddress.Size = new Size(75, 23);
            btnGetSAAddress.TabIndex = 37;
            btnGetSAAddress.Text = "充值地址";
            btnGetSAAddress.UseVisualStyleBackColor = true;
            btnGetSAAddress.Click += btnGetSAAddress_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(855, 619);
            Controls.Add(splitContainer1);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel1.PerformLayout();
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            tabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            tabPage1.PerformLayout();
            cmsLv.ResumeLayout(false);
            tabPage2.ResumeLayout(false);
            tabPage2.PerformLayout();
            cmsLvSA.ResumeLayout(false);
            panel1.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private SplitContainer splitContainer1;
        private ListViewEx listView1;
        private ColumnHeader colSeq;
        private ColumnHeader colAddress;
        private ColumnHeader colAmount;
        private ColumnHeader colInfo;
        private Button btnStop;
        private Button btnMW;
        private TextBox txtMaxDelay;
        private Label label6;
        private TextBox txtMinDelay;
        private Label label5;
        private ComboBox cmbNetworks;
        private Label label4;
        private ComboBox cmbCoins;
        private Label label3;
        private ContextMenuStrip cmsLv;
        private ToolStripMenuItem tslvImport;
        private Panel panel1;
        private Panel panel2;
        private Label labCountdown;
        private Button btnclearLv;
        private Button btnDeselect;
        private Button btnSelectAll;
        private Button btnGetAccountInfo;
        private TextBox txtLog;
        private TabControl tabControl1;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private Button btnCreateSubAccount;
        private ComboBox cmbSACoins;
        private Button btnTransferFromSA;
        private Button btnGetSubAccountInfo;
        private Button btnListSunAccount;
        private TextBox txtSACount;
        private Label label9;
        private ListViewEx lvSubAccount;
        private ColumnHeader colSASeq;
        private ColumnHeader colSASubAccount;
        private ColumnHeader colSAInfo;
        private TextBox txtSANameSeq;
        private Label label8;
        private TextBox txtSAName;
        private Label label7;
        private ComboBox cmbMEXCAccount;
        private Button btnCreateSubAccountApi;
        private TextBox txtIp;
        private Label label1;
        private Button btnCancelTask;
        private Button btnAddAccount;
        private Label label2;
        private ContextMenuStrip cmsLvSA;
        private ToolStripMenuItem tsSACopyTable;
        private Button btnGetSAAddress;
    }
}