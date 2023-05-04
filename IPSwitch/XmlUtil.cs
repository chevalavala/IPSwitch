using System.Xml;
using System.Collections.Generic;

namespace IPSwitch
{
    class XmlUtil
    {
        /// <summary>
        /// 根据Name获取单个节点数据
        /// </summary>
        /// <param name="name">Name属性</param>
        /// <param name="filename">xml文件完整路径</param>
        /// <returns></returns>
        public static Option GetOption(string name, string filename)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(filename);
            XmlNode xnRoot = doc.DocumentElement;
            XmlNodeList xnl = xnRoot.ChildNodes;
            foreach (XmlNode xn in xnl)
            {
                XmlElement xe = (XmlElement)xn;
                if (xe.GetAttribute("Name").ToString()==name)
                {
                    Option so = new Option
                    {
                        Type = xe.GetAttribute("Type").ToString(),
                        Name = xe.GetAttribute("Name").ToString(),
                        Value = xe.GetAttribute("Value").ToString()
                    };
                    return so;
                }
            }
            return null;
        }
        /// <summary>
        /// 获取所有节点数据
        /// </summary>
        /// <param name="filename">xml文件完整路径</param>
        /// <returns></returns>
        public static List<Option> GetOption(string filename)
        {
            List<Option> lo = new List<Option>();
            XmlDocument doc = new XmlDocument();
            doc.Load(filename);
            XmlNode xnRoot = doc.DocumentElement;
            //XmlNode xnClass = xnRoot.SelectSingleNode(class_);
            XmlNodeList xnl = xnRoot.ChildNodes;
            foreach (XmlNode xn in xnl)
            {
                XmlElement xe = (XmlElement)xn;
                Option so = new Option
                {
                    Type = xe.GetAttribute("Type").ToString(),
                    Name = xe.GetAttribute("Name").ToString(),
                    Value = xe.GetAttribute("Value").ToString()
                };
                lo.Add(so);
            }
            return lo;
        }
        /// <summary>
        /// 写入数据
        /// </summary>
        /// <param name="type">选择需要配置的节点mask或者ip</param>
        /// <param name="name">选项名</param>
        /// <param name="val">选项值</param>
        /// <param name="filename">xml文件完整路径</param>
        public static bool AddOption(string type, string name, string val, string filename)
        {
            List<Option> lo = GetOption(filename);
            foreach (Option op in lo)
            {
                if (name == op.Name)
                {
                    return false;
                }
            }
            XmlDocument doc = new XmlDocument();
            doc.Load(filename);
            XmlNode xnRoot = doc.DocumentElement;
            //XmlNode xnClass = xnRoot.SelectSingleNode(class_);
            XmlElement xeOption = doc.CreateElement("option");
            XmlAttribute xAtType = doc.CreateAttribute("Type");
            xAtType.InnerText = type;
            XmlAttribute xAtName = doc.CreateAttribute("Name");
            xAtName.InnerText = name;
            XmlAttribute xAtValue = doc.CreateAttribute("Value");
            xAtValue.InnerText = val;
            xeOption.SetAttributeNode(xAtType);
            xeOption.SetAttributeNode(xAtName);
            xeOption.SetAttributeNode(xAtValue);
            xnRoot.AppendChild(xeOption);
            doc.Save(filename);
            return true;
        }
        /// <summary>
        /// 删除数据
        /// </summary>
        /// <param name="name">选项名</param>
        /// <param name="filename">xml文件完整路径</param>
        public static bool DelOption(string name, string filename)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(filename);
            XmlNode xnRoot = doc.DocumentElement;
            string strPath = string.Format("/config/option[@Name=\"{1}\"]", name);
            XmlElement delXe = (XmlElement)xnRoot.SelectSingleNode(strPath);
            if (delXe == null)
            {
                return false;
            }
            delXe.ParentNode.RemoveChild(delXe);
            doc.Save(filename);
            return true;
        }
        /// <summary>
        /// 修改数据
        /// </summary>
        /// <param name="name">选项名</param>
        /// <param name="val">选项值</param>
        /// <param name="filename">xml文件完整路径</param>
        public static bool SetOption(string name, string val, string filename)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(filename);
            XmlNode xnRoot = doc.DocumentElement;
            string strPath = string.Format("/config/option[@Name=\"{1}\"]", name);
            XmlElement setXe = (XmlElement)xnRoot.SelectSingleNode(strPath);
            if (setXe == null)
            {
                return false;
            }
            setXe.SetAttribute("Value", val);
            doc.Save(filename);
            return true;
        }
    }
}
