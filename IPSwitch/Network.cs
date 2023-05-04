using System;

namespace IPSwitch
{
    public class Network
    {
        private String nic;//网卡
        private String name;//网络名称
        private String id;//网卡编号
        private String ip;//ip地址
        private String mask;//子网掩码
        private String gateway;//网关
        private String dns1;//首选DNS
        private String dns2;//备选DNS

        public string Nic { get => nic; set => nic = value; }
        public string Name { get => name; set => name = value; }
        public string Id { get => id; set => id = value; }
        public string Ip { get => ip; set => ip = value; }
        public string Mask { get => mask; set => mask = value; }
        public string Gateway { get => gateway; set => gateway = value; }
        public string Dns1 { get => dns1; set => dns1 = value; }
        public string Dns2 { get => dns2; set => dns2 = value; }
    }
}
