using System;
using System.IO;
using System.Windows.Forms;
using System.Collections.Generic;

namespace IPSwitch
{
    public partial class ConfMannagerForm : Form
    {
        private static string xmlFileName = "conf.xml";
        private string xmlPath;
        private string adPath;
        private List<Option> lo;

        public ConfMannagerForm()
        {
            InitializeComponent();
            string apppath = Path.GetDirectoryName(Application.ExecutablePath);
            xmlPath = apppath + "\\" + xmlFileName;
            adPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            xmlPath = String.Format("{0}\\{1}\\{2}", adPath, Application.ProductName, xmlFileName);
            displayAllConfig();
            textBox1.Text = xmlPath;
        }

        private void displayAllConfig()
        {
            lo = XmlUtil.GetOption(xmlPath);
            this.dgvConfInfo.DataSource = lo;
        }

        private void ConfMannagerForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            MainForm.confMannagerForm = null;
        }
    }
}
