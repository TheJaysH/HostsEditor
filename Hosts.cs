using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HostsEditor
{
    public class Hosts
    {
        public static readonly string HostHead = Properties.Resources.Hosts_Blank;
        public string HostFilePath = @"C:\Windows\System32\drivers\etc\hosts";

        public List<HostEntry> HostEntries { get; set; }


        public Hosts()
        {
            HostEntries = new List<HostEntry>();
        }

        public bool Read()
        {
            try
            {
                var hostFile = File.ReadAllLines(HostFilePath);
                var hostHead = HostHead.Split(new char[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);

                foreach (var line in hostFile)
                {
                    if (hostHead.Contains(line) || string.IsNullOrEmpty(line)) continue;
                    var entry = new HostEntry(line);
                    HostEntries.Add(entry);
                }

                return HostEntries.Count > 0;
            }
            catch (Exception)
            {
                throw;
            }
           
        }

        public void Write()
        {
            var newFile = new StringBuilder();

            newFile.Append(Properties.Resources.Hosts_Blank);
            newFile.AppendLine();

            foreach (var host in HostEntries)
            {
                newFile.Append(host);
            }



        }

    }

    public class HostEntry
    {
        private string Line { get; set; }
        public string IpAddress { get; set; }
        public string UrlAddress { get; set; }
        public bool Enabled { get; set; } 

        public HostEntry(string line)
        {
            var parts = line.Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);

            IpAddress = parts[0];
            UrlAddress = parts[1];
            Line = line;
            Enabled = !Line.StartsWith("#");           
        }

        public override string ToString()
        {
            return $"{(Enabled ? "" : "#")}{IpAddress}\t\t{UrlAddress}\r\n";
        }

    }
}
