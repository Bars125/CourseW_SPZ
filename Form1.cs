using System;
//using System.Collections.Generic;
//using System.ComponentModel;
//using System.Data;
using System.Drawing;
//using System.Linq;
//using System.Text;
//using System.Threading;
using System.Windows.Forms;
using System.Diagnostics;

namespace WinForms_COURSE25
{
    public partial class Form1 : Form
    {
        Process[] processes = Process.GetProcesses();
        public Form1()
        {
            InitializeComponent();
            listBox1.MouseDoubleClick += new MouseEventHandler(listBox1_DoubleClick);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            label1.Text = "";
            listBox1.Items.Clear();
            foreach (Process process in processes)
            {
                listBox1.Items.Add(process.Id + "\t" + process.ProcessName);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            label1.Text = "";
            if (listBox1.SelectedIndex != -1)
            {
                try
                {
                    listIndextoID().Kill();
                    //clearing listbox
                    listBox1.Items.RemoveAt(listBox1.SelectedIndex);
                }
                catch
                {
                    alarmingFunc("ACCESS DENIED");
                }
            }
        }

        private Process listIndextoID()
        {
            int proctempID = listBox1.SelectedIndex; // take index from listbox
            Process process1 = processes[proctempID]; // find the process in array using index
            Process process2 = Process.GetProcessById(process1.Id); // initialize Process var with shosen process
            return process2;
        }

        private void alarmingFunc(string AlarmText)
        {
            label1.Visible = true;
            label1.Text = AlarmText;
            label1.ForeColor = Color.Red;
            label1.Font = new Font("Verdana", 18);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void listBox1_DoubleClick(object sender, MouseEventArgs e)
        {
            label1.Text = "";
            if (listBox1.SelectedItem != null)
            {
                try
                {
                    Process process3 = listIndextoID();
                    listBox1.Items.Clear();
                    listBox1.Items.Add("ProcessName: " + process3.ProcessName);
                    listBox1.Items.Add("ID: " + process3.Id);
                    listBox1.Items.Add("BasePriority: " + process3.BasePriority);
                    listBox1.Items.Add("StartTime: " + process3.StartTime);
                    listBox1.Items.Add("Threads' Number : " + process3.Threads.Count);
                }
                catch
                {
                    alarmingFunc("UNAVALIABLE PROPERTIES");
                }
            }
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            label1.Text = "";
            if (listBox1.SelectedIndex != -1)
            {
                Process processfortread = listIndextoID();
                ProcessThreadCollection threadlist = processfortread.Threads;
                string tempSMSBox = "";

                foreach (ProcessThread theThread in threadlist)
                {
                    tempSMSBox += "ID: " + theThread.Id + " " + " BasePriority: "
                        + theThread.BasePriority + " " + " State: " + theThread.ThreadState + "\n";
                }
                MessageBox.Show(tempSMSBox, "Treads");

            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            label1.Text = "";
            textBox1.Visible = true;
            button5.Visible = true;
            try
            {
                if (textBox1.Text.Length != 0)
                {
                    Process.Start(new ProcessStartInfo(textBox1.Text));
                }
            }
            catch
            {
                alarmingFunc("Wrong/Invalid path.\n");
            }           
        }

        private void button5_Click(object sender, EventArgs e)
        {
            label1.Text = "";
            textBox1.Clear();
        }
    }
}
