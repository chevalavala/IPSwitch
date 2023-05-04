using System;
using System.Management;
using System.Collections.Generic;

namespace IPSwitch
{
    public class NetworkAdapterMannager
    {
        private Dictionary<string, string> AllNIC = new Dictionary<string, string>();
        private List<NetworkAdapter> ntks = new List<NetworkAdapter>();

        public NetworkAdapterMannager()
        {
            this.InitNICItem();
            this.InitNICInfo();
        }
        public Dictionary<string, string> AllNIC1
        {
            get
            {
                return AllNIC;
            }
            set
            {
                AllNIC = value;
            }
        }
        //重新加载
        public void Init()
        {
            this.InitNICItem();
            this.InitNICInfo();
        }
        /// <summary>
        /// 刷新ntks列表
        /// </summary>
        public void Refresh()
        {
            this.InitNICInfo();
        }
        /// <summary>
        /// 初始化下拉列表条目
        /// </summary>
        private void InitNICItem()
        {
            this.AllNIC.Clear();
            ManagementClass wmi = new ManagementClass("Win32_NetworkAdapterConfiguration");
            ManagementObjectCollection moc = wmi.GetInstances();
            foreach (ManagementObject mo in moc)
            {
                if (!(bool)mo["IPEnabled"]) continue;
                this.AllNIC.Add(mo["Description"].ToString(), mo["SettingID"].ToString());
            }
        }
        /// <summary>
        ///  获取网卡信息,更新ntks列表
        /// </summary>
        private void InitNICInfo()
        {
            ntks.Clear();
            ManagementClass wmi = new ManagementClass("Win32_NetworkAdapterConfiguration");
            ManagementObjectCollection moc = wmi.GetInstances();
            foreach (ManagementObject mo in moc)
            {
                if (Convert.ToBoolean(mo["IPEnabled"]) == true)
                {
                    NetworkAdapter ntk = new NetworkAdapter();
                    ntk.Name = mo["Description"].ToString();
                    ntk.Id = mo["SettingID"].ToString();
                    //获取IP
                    if (mo["IPAddress"] as String[] == null)
                    {
                        ntk.Ip = "";
                    }
                    else
                    {
                        ntk.Ip = (mo["IPAddress"] as String[])[0];
                    }
                    //获取子网掩码
                    if (mo["IPSubnet"] as String[] == null)
                    {
                        ntk.Mask = "";
                    }
                    else
                    {
                        ntk.Mask = (mo["IPSubnet"] as String[])[0];
                    }
                    //获取网关
                    if (mo["DefaultIPGateway"] as String[] == null)
                    {
                        ntk.Gateway = "";
                    }
                    else
                    {
                        ntk.Gateway = (mo["DefaultIPGateway"] as String[])[0];
                    }
                    //获取DNS
                    if (mo["DNSServerSearchOrder"] as String[] == null)
                    {
                        ntk.Dns1 = "";
                        ntk.Dns2 = "";
                    }
                    else
                    {
                        ntk.Dns1 = (mo["DNSServerSearchOrder"] as String[])[0];
                        if ((mo["DNSServerSearchOrder"] as String[]).Length == 2)
                        {
                            ntk.Dns2 = (mo["DNSServerSearchOrder"] as String[])[1];
                        }
                        else
                        {
                            ntk.Dns2 = "";
                        }
                    }
                    ntks.Add(ntk);
                }
            }
        }
        /// <summary>
        /// 将Caption转换为ID
        /// </summary>
        /// <param name="caption">网卡Caption</param>
        /// <returns>网卡ID</returns>
        private string Caption2Id(string caption)
        {
            string id = AllNIC1[caption];
            return id;
        }
        /// <summary>
        /// 通过网卡Caption获取网卡信息
        /// </summary>
        /// <param name="caption">网卡Caption</param>
        /// <returns>Network对象</returns>
        public NetworkAdapter GetNICInfoByCaption(string caption)
        {
            string id;
            try
            {
                id = Caption2Id(caption);
            }
            catch
            {
                id = "";
            }
            NetworkAdapter nk = new NetworkAdapter();
            foreach (NetworkAdapter ntk in ntks)
            {
                if (ntk.Id == id)
                {
                    nk = ntk;
                }
            }
            return nk;
        }
        /// <summary>
        /// 设置网卡信息
        /// </summary>
        /// <param name="SettingID"></param>
        /// <param name="ip"></param>
        /// <param name="submask"></param>
        /// <param name="gateway"></param>
        /// <param name="dns"></param>
        public void SetNetwork(string SettingID, string[] ip, string[] submask, string[] gateway, string[] dns)
        {
            ManagementClass wmi = new ManagementClass("Win32_NetworkAdapterConfiguration");
            ManagementObjectCollection moc = wmi.GetInstances();
            ManagementBaseObject inPar = null;
            ManagementBaseObject outPar = null;
            foreach (ManagementObject mo in moc)
            {
                //如果没有启用IP设置的网络设备则跳过
                if (!(bool)mo["IPEnabled"])
                    continue;
                if (mo["SettingID"].ToString() != SettingID)
                    continue;

                //设置IP地址和掩码
                if (ip != null && submask != null)
                {
                    inPar = mo.GetMethodParameters("EnableStatic");
                    inPar["IPAddress"] = ip;
                    inPar["SubnetMask"] = submask;
                    outPar = mo.InvokeMethod("EnableStatic", inPar, null);
                }

                //设置网关地址
                if (gateway != null)
                {
                    inPar = mo.GetMethodParameters("SetGateways");
                    inPar["DefaultIPGateway"] = gateway;
                    outPar = mo.InvokeMethod("SetGateways", inPar, null);
                }

                //设置DNS地址
                if (dns != null)
                {
                    inPar = mo.GetMethodParameters("SetDNSServerSearchOrder");
                    inPar["DNSServerSearchOrder"] = dns;
                    outPar = mo.InvokeMethod("SetDNSServerSearchOrder", inPar, null);
                }
            }
        }
    }
}
