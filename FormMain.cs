using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HostsEditor
{
    public partial class FormMain : Form
    {
        public static Hosts Hosts { get; set; }

        public FormMain()
        {
            InitializeComponent();
            Hosts = new Hosts();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Hosts.Read();
            objectListView1.AddObjects(Hosts.HostEntries);
        }
   

        private void NewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var newEntry = new NewEntry();
            newEntry.ShowDialog();

            if (newEntry.DialogResult != DialogResult.OK) return;

            var newHost = new HostEntry()
            {
                UrlAddress = newEntry.UrlAddress,
                IpAddress = newEntry.IpAddress,
                Enabled = newEntry.IsEnabled
            };

            objectListView1.AddObject(newHost);

            Hosts.HostEntries = objectListView1.Objects.Cast<HostEntry>().ToList();
        }

        private void SaveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Hosts.Write();
        }

        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
