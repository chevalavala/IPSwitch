using System;
using System.IO;
using System.Drawing;
using System.Threading;
using System.Diagnostics;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace IPSwitch
{
    public partial class MainForm : Form
    {
        public static NetworkAdapterMannager networkAdapterMannager;
        public static ConfMannagerForm confMannagerForm;
        private static string xmlFileName = "conf.xml";
        private string xmlPath;
        private string adPath;
        private List<Icon> iconList = new List<Icon>();
        private List<Option> options = new List<Option>();
        private int icoInde = 0;
        private int setp = 1;
        private Network selNetwork;     //下拉列表选定网卡
        private Network curNetwork;     //全局选定网卡
        private int selIndex = 0;
        private bool pingStatus = true;
        private bool icoStatus;

        public MainForm()
        {
            networkAdapterMannager = new NetworkAdapterMannager();
            InitializeComponent();
            fullcbNetworkInterface();
            adPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            xmlPath = String.Format("{0}\\{1}\\{2}", adPath, Application.ProductName, xmlFileName);
            InitConf();
            LoadMenu(options);
            iconList.Add(Properties.Resources._0);
            iconList.Add(Properties.Resources._1);
            iconList.Add(Properties.Resources._2);
            netCheckTimer.Start();
            icoCtrlTimer.Start();
            clearMemoryTimer.Start();
        }
        /// <summary>
        /// 配置文件
        /// </summary>
        public void InitConf()
        {
            string dpath = String.Format("{0}\\{1}", adPath, Text);
            if (!Directory.Exists(dpath))
            {
                Directory.CreateDirectory(dpath);
            }
            if (!File.Exists(xmlPath))
            {
                FileStream fs = new FileStream(xmlPath, FileMode.CreateNew, FileAccess.ReadWrite);
                StreamWriter sw = new StreamWriter(fs);
                string[] content = {
                    "<?xml version=\"1.0\" encoding=\"utf-8\"?>",
                    "<config>",
                    "\t<option Type=\"IP\" Name=\"示例1\" Value=\"192.168.0.10\" />",
                    "\t<option Type=\"Gateway\" Name=\"示例1\" Value=\"192.168.0.1\" />",
                    "</config>"
                };
                foreach (var c in content)
                {
                    sw.WriteLine(c);
                }
                sw.Flush();
                sw.Close();
            }
            options = XmlUtil.GetOption(xmlPath);
        }
        /// <summary>
        /// 加载二级菜单
        /// </summary>
        private void LoadMenu(List<Option> ol)
        {
            //清空原有二级菜单
            IPSwitchToolStripMenuItem.DropDownItems.Clear();
            GetwaySwitchToolStripMenuItem.DropDownItems.Clear();
            foreach (var op in ol)
            {
                if (op.Type == "IP")
                {
                    AddContextMenu(op.Name, IPSwitchToolStripMenuItem.DropDownItems, new EventHandler(MenuClicked));
                }
                else if (op.Type == "Gateway")
                {
                    AddContextMenu(op.Name, GetwaySwitchToolStripMenuItem.DropDownItems, new EventHandler(MenuClicked));
                }
            }
        }
        /// <summary>
        /// 添加子菜单
        /// </summary>
        /// <param name="text">要显示的文字</param>
        /// <param name="cms">要添加到的子菜单集合</param>
        /// <param name="callback">点击时触发的事件</param>
        /// <returns>生成的子菜单，如果为分隔条则返回null</returns>
        internal ToolStripMenuItem AddContextMenu(string text, ToolStripItemCollection cms, EventHandler callback)
        {
            if (!string.IsNullOrEmpty(text))
            {
                ToolStripMenuItem tsmi = new ToolStripMenuItem(text);
                tsmi.Tag = text + "TAG";
                if (callback != null) tsmi.Click += callback;
                cms.Add(tsmi);
                return tsmi;
            }
            return null;
        }
        void MenuClicked(object sender, EventArgs e)
        {
            //二级菜单单击事件
            string id = networkAdapterMannager.AllNIC1[cbNetworkInterface.Text];
            string[] ip = new string[] { selNetwork.Ip };
            string[] gateway = new string[] { selNetwork.Gateway };
            string[] mask = new string[] { selNetwork.Mask };
            string[] dns = new string[] { selNetwork.Dns1, selNetwork.Dns2 };
            foreach (var option in options)
            {
                if (option.Name == ((ToolStripMenuItem)sender).Text)
                {
                    if (option.Type == "IP")
                    {
                        ip = new string[] { option.Value };
                    }
                    else if(option.Type == "Gateway")
                    {
                        gateway = new string[] { option.Value };
                    }
                    break;
                }
            }
            networkAdapterMannager.SetNetwork(id, ip, mask, gateway, dns);
            InitConf();
            fullcbNetworkInterface();
            NetPingTest();
        }
        /// <summary>
        /// 显示Network信息到界面
        /// </summary>
        /// <param name="ntk">Network对象</param>
        private void displayNetworkInfo(Network ntk)
        {
            tbNetworkInterfaceID.Text = ntk.Id;
            tbName.Text = ntk.Name;
            tbIp.Text = ntk.Ip;
            tbMask.Text = ntk.Mask;
            tbGateway.Text = ntk.Gateway;
            tbDNS01.Text = ntk.Dns1;
            tbDNS02.Text = ntk.Dns2;
        }
        /// <summary>
        /// 选定网卡下拉列表
        /// </summary>
        private void cbNetworkInterface_SelectedIndexChanged(object sender, EventArgs e)
        {
            Network ntk = networkAdapterMannager.GetNICInfoByCaption(cbNetworkInterface.Text);
            selNetwork = ntk;
            selIndex = cbNetworkInterface.SelectedIndex;
            displayNetworkInfo(ntk);
        }
        /// <summary>
        /// 重置网卡下拉列表
        /// </summary>
        public void fullcbNetworkInterface()
        {
            cbNetworkInterface.Items.Clear();
            networkAdapterMannager.Init();
            foreach (var item in networkAdapterMannager.AllNIC1)
            {
                cbNetworkInterface.Items.Add(item.Key);
            }
            if (cbNetworkInterface.Items.Count>0)
            {
                cbNetworkInterface.SelectedIndex = selIndex;
            }
        }
        private void notifyIcon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Visible = true;
            ShowInTaskbar = true;
            WindowState = FormWindowState.Normal;
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            WindowState = FormWindowState.Minimized;
            ShowInTaskbar = false;
            e.Cancel = true;
        }

        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.GetCurrentProcess().Kill();
        }

        private void OptionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (confMannagerForm == null)
            {
                confMannagerForm = new ConfMannagerForm();
                confMannagerForm.Closed += ConfMannagerForm_Closed;
                confMannagerForm.ShowDialog(this);
            }
            else
            {
                confMannagerForm.Activate();
            }
            InitConf();
            LoadMenu(options);
        }

        private void ConfMannagerForm_Closed(object sender, EventArgs e)
        {
            InitConf();
            LoadMenu(options);
        }
        /// <summary>
        /// 使用ping测试网络是否畅通
        /// </summary>
        private void NetPingTest()
        {
            var timeout = TimeSpan.FromMilliseconds(1000);
            var ping = new System.Net.NetworkInformation.Ping();
            var res = ping.Send("1.1.1.1", (int)timeout.TotalMilliseconds);
            if (res.Status == System.Net.NetworkInformation.IPStatus.Success)
            {
                //true
                pingStatus = true;
            }
            else
            {
                //false
                pingStatus = false;
            }
        }
        /// <summary>
        /// ico轮播定时器
        /// </summary>
        private void icoTimer_Tick(object sender, EventArgs e)
        {
            icoInde += setp;
            if (icoInde == 3)
            {
                setp = -1;
                icoInde = 1;
            }
            if (icoInde == -1)
            {
                setp = 1;
                icoInde = 1;
            }
            notifyIcon.Icon = iconList[icoInde];

        }
        /// <summary>
        /// 网络检查定时器
        /// </summary>
        private void netCheckTimer_Tick(object sender, EventArgs e)
        {
            //后台线程 测试网络,修改pingStatus
            Thread thread = new Thread(NetPingTest);
            thread.IsBackground = true;
            thread.Start();
        }

        private void icoCtrlTimer_Tick(object sender, EventArgs e)
        {
            //根据pingStatus 判断是否开始轮播ico
            if (pingStatus)
            {
                if(icoStatus)
                {
                    notifyIcon.Icon = iconList[1];
                    icoTimer.Stop();
                    icoStatus = false;
                }
            }
            else
            {
                if(!icoStatus)
                {
                    icoTimer.Start();
                    icoStatus = true;
                }
            }
        }

        private void notifyIcon_MouseMove(object sender, MouseEventArgs e)
        {
            networkAdapterMannager.Refresh();
            if (selNetwork != null)
            {
                curNetwork = networkAdapterMannager.GetNICInfoByCaption(selNetwork.Name);
                selNetwork = curNetwork;
                displayNetworkInfo(selNetwork);
                //设置任务栏图标text
                notifyIcon.Text = "网关：" + curNetwork.Gateway;
                this.IPSwitchToolStripMenuItem.Enabled = true;
                this.GetwaySwitchToolStripMenuItem.Enabled = true;
            }
            else 
            {
                notifyIcon.Text = "IPSwitch v550";
                this.IPSwitchToolStripMenuItem.Enabled = false;
                this.GetwaySwitchToolStripMenuItem.Enabled = false;
            }
        }
        #region 内存回收
        [DllImport("kernel32.dll", EntryPoint = "SetProcessWorkingSetSize")]
        private static extern int SetProcessWorkingSetSize(IntPtr process, int minSize, int maxSize);
        /// <summary>
        /// 释放内存
        /// </summary>
        private static void ClearMemory()
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();
            if (Environment.OSVersion.Platform == PlatformID.Win32NT)
            {
                SetProcessWorkingSetSize(System.Diagnostics.Process.GetCurrentProcess().Handle, -1, -1);
            }
        }
        #endregion

        private void clearMemoryTimer_Tick(object sender, EventArgs e)
        {
            ClearMemory();
        }
    }
}
