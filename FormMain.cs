using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HostsEditor
{
    public partial class FormMain : Form
    {
        public static ListView ListView { get; set; }
        public static Hosts Hosts { get; set; }

        public FormMain()
        {
            InitializeComponent();

            ListView = listView_Main;

            Hosts = new Hosts();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Hosts.Read();

            foreach (var host in Hosts.HostEntries)
            {              
                ListView.Items.Add(host.GetListViewItem());
            }

            
        }


        private void LoadHostFile()
        {

        }
    }
}
