using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework;
using MetroFramework.Forms;
using System.Diagnostics;

namespace NetworkDebugger
{
    public partial class Home : MetroForm
    {
        public Home()
        {
            InitializeComponent();

        }
        public string textr;

        private void metroButton1_Click(object sender, EventArgs e)
        {
            backgroundWorkerprocess.DoWork += BackgroundWorkerprocess_DoWork;
            backgroundWorkerprocess.RunWorkerCompleted += BackgroundWorkerprocess_RunWorkerCompleted;
        }

        private void BackgroundWorkerprocess_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            richTextBox1.Text = textr;

            //throw new NotImplementedException();
        }

        private void BackgroundWorkerprocess_DoWork(object sender, DoWorkEventArgs e)
        {
            ProcessStartInfo startInfo = new ProcessStartInfo()
            {
                WindowStyle = ProcessWindowStyle.Hidden,
                UseShellExecute = false,
                RedirectStandardOutput = true,
                CreateNoWindow = true,
                // FileName = comboBox1.Text,
            };
            Process p = new Process();
            p.WaitForExit(2000);

            p.StartInfo.FileName = mainCommands.Text;
            p.StartInfo.Arguments = metroTextBox1.Text + " " + metroComboBox2.Text;
            //throw new NotImplementedException();
            textr= p.StandardOutput.ReadToEnd();
        }

        
        private void mainCommands_SelectedIndexChanged(object sender, EventArgs e)
        {
            metroComboBox2.Visible = true;
            if (mainCommands.Text=="ping")
            {
                metroTextBox1.Visible = true;
                metroComboBox2.Items.Add("-t");
               // metroComboBox2.Items.Add("-t");
                metroComboBox2.Items.Add("-a");
                metroComboBox2.Items.Add("-n count");
                metroComboBox2.Items.Add("-l size");
                metroComboBox2.Items.Add("-f");
                metroComboBox2.Items.Add("-i TTL");
                metroComboBox2.Items.Add("-r count");
                metroComboBox2.Items.Add("-v TOS");
                metroComboBox2.Items.Add("-s count");
                metroComboBox2.Items.Add("-w timeout");
                metroComboBox2.Items.Add("-j host_list");
                metroComboBox2.Items.Add("-k host_list");
                metroComboBox2.Items.Add("destination_host  ");
                metroComboBox2.Items.Add("-S srcaddr");
                metroComboBox2.Items.Add("-4");
                metroComboBox2.Items.Add("-6");
            }//end of ping
            else if(mainCommands.Text== "tracert")
            {
                metroComboBox2.Visible =true;
                {
                    metroTextBox1.Visible = true;
                    metroTextBox1.Text = "IP address/Domain";
                    metroComboBox2.Items.Add("-d");
                    metroComboBox2.Items.Add("-h");
                    metroComboBox2.Items.Add("-w");
                    metroComboBox2.Items.Add("-4");
                    metroComboBox2.Items.Add("-6");
                    metroComboBox2.Items.Add("/? ");
                }
            }//end of tracert
            else if (mainCommands.Text == "netstat")
            {
                metroComboBox2.Visible = true;
                {
                    metroTextBox1.Visible = true;
                    metroComboBox2.Items.Add("-v");
                    metroComboBox2.Items.Add("-n");
                    metroComboBox2.Items.Add("--numeric-hosts");
                    metroComboBox2.Items.Add("--numeric-ports");
                    metroComboBox2.Items.Add("--numeric-users    ");
                    metroComboBox2.Items.Add("-A");
                    metroComboBox2.Items.Add("-c");
                    metroComboBox2.Items.Add("-e");
                    metroComboBox2.Items.Add("-p");
                    metroComboBox2.Items.Add("-o");
                    metroComboBox2.Items.Add("-l");
                    metroComboBox2.Items.Add("-a");
                    metroComboBox2.Items.Add("-f");
                    metroComboBox2.Items.Add("-c");
                    metroComboBox2.Items.Add("-z");
                    metroComboBox2.Items.Add("-n");
                }
            }//end of netstat
        }
    }
}
