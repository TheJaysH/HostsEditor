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
    public partial class NewEntry : Form
    {
        public  string IpAddress { get; set; }
        public  string UrlAddress { get; set; }
        public  bool IsEnabled { get; set; }

        public NewEntry()
        {
            InitializeComponent();
        }

        private void Button_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void NewEntry_Load(object sender, EventArgs e)
        {
        }

        private void Button_Save_Click(object sender, EventArgs e)
        {
            //TODO: Validate data                

            this.DialogResult = DialogResult.OK;
            IpAddress = ipAddressControl.Text.Replace(" ", string.Empty);
            UrlAddress = textBox1.Text;
            IsEnabled = checkBox1.Checked;
        }
    }
}
