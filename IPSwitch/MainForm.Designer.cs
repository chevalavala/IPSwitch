namespace IPSwitch
{
    partial class MainForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cbNetworkInterface = new System.Windows.Forms.ComboBox();
            this.tbNetworkInterfaceID = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tbDNS02 = new System.Windows.Forms.TextBox();
            this.tbDNS01 = new System.Windows.Forms.TextBox();
            this.tbGateway = new System.Windows.Forms.TextBox();
            this.tbMask = new System.Windows.Forms.TextBox();
            this.tbIp = new System.Windows.Forms.TextBox();
            this.tbName = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.OptionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.IPSwitchToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.GetwaySwitchToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ExitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.icoTimer = new System.Windows.Forms.Timer(this.components);
            this.netCheckTimer = new System.Windows.Forms.Timer(this.components);
            this.icoCtrlTimer = new System.Windows.Forms.Timer(this.components);
            this.clearMemoryTimer = new System.Windows.Forms.Timer(this.components);
            this.groupBox1.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 9F);
            this.label1.Location = new System.Drawing.Point(3, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "网卡名称";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 9F);
            this.label2.Location = new System.Drawing.Point(3, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "网卡编号";
            // 
            // cbNetworkInterface
            // 
            this.cbNetworkInterface.Font = new System.Drawing.Font("宋体", 9F);
            this.cbNetworkInterface.FormatString = "选择网卡";
            this.cbNetworkInterface.FormattingEnabled = true;
            this.cbNetworkInterface.ItemHeight = 12;
            this.cbNetworkInterface.Location = new System.Drawing.Point(76, 10);
            this.cbNetworkInterface.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cbNetworkInterface.Name = "cbNetworkInterface";
            this.cbNetworkInterface.Size = new System.Drawing.Size(194, 20);
            this.cbNetworkInterface.TabIndex = 2;
            this.cbNetworkInterface.SelectedIndexChanged += new System.EventHandler(this.cbNetworkInterface_SelectedIndexChanged);
            // 
            // tbNetworkInterfaceID
            // 
            this.tbNetworkInterfaceID.Enabled = false;
            this.tbNetworkInterfaceID.Font = new System.Drawing.Font("宋体", 9F);
            this.tbNetworkInterfaceID.Location = new System.Drawing.Point(76, 41);
            this.tbNetworkInterfaceID.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tbNetworkInterfaceID.Name = "tbNetworkInterfaceID";
            this.tbNetworkInterfaceID.ReadOnly = true;
            this.tbNetworkInterfaceID.Size = new System.Drawing.Size(194, 21);
            this.tbNetworkInterfaceID.TabIndex = 3;
            this.tbNetworkInterfaceID.TabStop = false;
            this.tbNetworkInterfaceID.WordWrap = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tbDNS02);
            this.groupBox1.Controls.Add(this.tbDNS01);
            this.groupBox1.Controls.Add(this.tbGateway);
            this.groupBox1.Controls.Add(this.tbMask);
            this.groupBox1.Controls.Add(this.tbIp);
            this.groupBox1.Controls.Add(this.tbName);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Font = new System.Drawing.Font("宋体", 9F);
            this.groupBox1.Location = new System.Drawing.Point(9, 82);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(260, 250);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "网卡信息";
            // 
            // tbDNS02
            // 
            this.tbDNS02.Location = new System.Drawing.Point(112, 208);
            this.tbDNS02.Name = "tbDNS02";
            this.tbDNS02.ReadOnly = true;
            this.tbDNS02.Size = new System.Drawing.Size(130, 21);
            this.tbDNS02.TabIndex = 11;
            // 
            // tbDNS01
            // 
            this.tbDNS01.Location = new System.Drawing.Point(112, 173);
            this.tbDNS01.Name = "tbDNS01";
            this.tbDNS01.ReadOnly = true;
            this.tbDNS01.Size = new System.Drawing.Size(130, 21);
            this.tbDNS01.TabIndex = 10;
            // 
            // tbGateway
            // 
            this.tbGateway.Location = new System.Drawing.Point(112, 138);
            this.tbGateway.Name = "tbGateway";
            this.tbGateway.ReadOnly = true;
            this.tbGateway.Size = new System.Drawing.Size(130, 21);
            this.tbGateway.TabIndex = 9;
            // 
            // tbMask
            // 
            this.tbMask.Location = new System.Drawing.Point(112, 103);
            this.tbMask.Name = "tbMask";
            this.tbMask.ReadOnly = true;
            this.tbMask.Size = new System.Drawing.Size(130, 21);
            this.tbMask.TabIndex = 8;
            // 
            // tbIp
            // 
            this.tbIp.Location = new System.Drawing.Point(112, 68);
            this.tbIp.Name = "tbIp";
            this.tbIp.ReadOnly = true;
            this.tbIp.Size = new System.Drawing.Size(130, 21);
            this.tbIp.TabIndex = 7;
            // 
            // tbName
            // 
            this.tbName.Location = new System.Drawing.Point(112, 33);
            this.tbName.Name = "tbName";
            this.tbName.ReadOnly = true;
            this.tbName.Size = new System.Drawing.Size(130, 21);
            this.tbName.TabIndex = 6;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(15, 211);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(47, 12);
            this.label8.TabIndex = 5;
            this.label8.Text = "备用DNS";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(15, 176);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(47, 12);
            this.label7.TabIndex = 4;
            this.label7.Text = "首选DNS";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(15, 141);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 12);
            this.label6.TabIndex = 3;
            this.label6.Text = "默认网关";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(15, 106);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 2;
            this.label5.Text = "子网掩码";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(15, 71);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 12);
            this.label4.TabIndex = 1;
            this.label4.Text = "IP 地址";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 36);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 12);
            this.label3.TabIndex = 0;
            this.label3.Text = "名称";
            // 
            // notifyIcon
            // 
            this.notifyIcon.ContextMenuStrip = this.contextMenuStrip1;
            this.notifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon.Icon")));
            this.notifyIcon.Text = "IPSwitch V5.50";
            this.notifyIcon.Visible = true;
            this.notifyIcon.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon_MouseDoubleClick);
            this.notifyIcon.MouseMove += new System.Windows.Forms.MouseEventHandler(this.notifyIcon_MouseMove);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.DropShadowEnabled = false;
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(0, 0);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.OptionToolStripMenuItem,
            this.IPSwitchToolStripMenuItem,
            this.GetwaySwitchToolStripMenuItem,
            this.ExitToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.ShowImageMargin = false;
            this.contextMenuStrip1.Size = new System.Drawing.Size(100, 92);
            // 
            // OptionToolStripMenuItem
            // 
            this.OptionToolStripMenuItem.Name = "OptionToolStripMenuItem";
            this.OptionToolStripMenuItem.Size = new System.Drawing.Size(99, 22);
            this.OptionToolStripMenuItem.Text = "Option";
            this.OptionToolStripMenuItem.Click += new System.EventHandler(this.OptionToolStripMenuItem_Click);
            // 
            // IPSwitchToolStripMenuItem
            // 
            this.IPSwitchToolStripMenuItem.Name = "IPSwitchToolStripMenuItem";
            this.IPSwitchToolStripMenuItem.Size = new System.Drawing.Size(99, 22);
            this.IPSwitchToolStripMenuItem.Text = "切换IP";
            // 
            // GetwaySwitchToolStripMenuItem
            // 
            this.GetwaySwitchToolStripMenuItem.Name = "GetwaySwitchToolStripMenuItem";
            this.GetwaySwitchToolStripMenuItem.Size = new System.Drawing.Size(99, 22);
            this.GetwaySwitchToolStripMenuItem.Text = "切换网关";
            // 
            // ExitToolStripMenuItem
            // 
            this.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem";
            this.ExitToolStripMenuItem.Size = new System.Drawing.Size(99, 22);
            this.ExitToolStripMenuItem.Text = "退出";
            this.ExitToolStripMenuItem.Click += new System.EventHandler(this.ExitToolStripMenuItem_Click);
            // 
            // icoTimer
            // 
            this.icoTimer.Interval = 400;
            this.icoTimer.Tick += new System.EventHandler(this.icoTimer_Tick);
            // 
            // netCheckTimer
            // 
            this.netCheckTimer.Interval = 10000;
            this.netCheckTimer.Tick += new System.EventHandler(this.netCheckTimer_Tick);
            // 
            // icoCtrlTimer
            // 
            this.icoCtrlTimer.Interval = 1000;
            this.icoCtrlTimer.Tick += new System.EventHandler(this.icoCtrlTimer_Tick);
            // 
            // clearMemoryTimer
            // 
            this.clearMemoryTimer.Interval = 3000;
            this.clearMemoryTimer.Tick += new System.EventHandler(this.clearMemoryTimer_Tick);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(279, 340);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.tbNetworkInterfaceID);
            this.Controls.Add(this.cbNetworkInterface);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.Text = "IPSwitch";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbNetworkInterface;
        private System.Windows.Forms.TextBox tbNetworkInterfaceID;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbDNS02;
        private System.Windows.Forms.TextBox tbDNS01;
        private System.Windows.Forms.TextBox tbGateway;
        private System.Windows.Forms.TextBox tbMask;
        private System.Windows.Forms.TextBox tbIp;
        private System.Windows.Forms.TextBox tbName;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NotifyIcon notifyIcon;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem ExitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem GetwaySwitchToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem IPSwitchToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem OptionToolStripMenuItem;
        private System.Windows.Forms.Timer icoTimer;
        private System.Windows.Forms.Timer netCheckTimer;
        private System.Windows.Forms.Timer icoCtrlTimer;
        private System.Windows.Forms.Timer clearMemoryTimer;
    }
}

