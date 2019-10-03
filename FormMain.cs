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
        public static bool IsLoaded { get; set; }
        public static Hosts Hosts { get; set; }

        public FormMain()
        {
            IsLoaded = false;
            InitializeComponent();
            Hosts = new Hosts();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadHosts();
            IsLoaded = true;
        }
   
        public void LoadHosts()
        {
            Hosts.Read();

            objectListView1.ClearObjects();
            objectListView1.AddObjects(Hosts.HostEntries);
        }

        public void AddNewItem()
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

        private void NewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddNewItem();
        }

        private void NewHostToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddNewItem();
        }

        public void Write()
        {
            if (!IsLoaded) return;

            Hosts.HostEntries = objectListView1.Objects.Cast<HostEntry>().ToList();
            Hosts.Write();
        }

        private void ReloadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IsLoaded = false;
            LoadHosts();
            IsLoaded = true;
        }

        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void ObjectListView1_ItemsChanged(object sender, BrightIdeasSoftware.ItemsChangedEventArgs e)
        {
            Write();
        }
     
        private void ObjectListView1_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            Write();
        }

        private void ObjectListView1_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            Write();
        }

        private void ObjectListView1_CellEditFinished(object sender, BrightIdeasSoftware.CellEditEventArgs e)
        {
            Write();
        }

        private void ObjectListView1_ItemsAdding(object sender, BrightIdeasSoftware.ItemsAddingEventArgs e)
        {
            Write();
        }

        private void ObjectListView1_ItemsRemoving(object sender, BrightIdeasSoftware.ItemsRemovingEventArgs e)
        {
            Write();
        }

        private void DeleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            objectListView1.RemoveObjects(objectListView1.SelectedItems);           
        }

      
    }
}
