using System.Collections.Generic;
using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;

namespace MinimalADB
{
    public partial class Form1 : Form
    {
        string filePath = string.Empty;

        public Form1()
        {
            InitializeComponent();
            System.Diagnostics.Process process = new System.Diagnostics.Process();
            System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
            startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            startInfo.FileName = "cmd.exe";
            startInfo.Arguments = "/c adb devices";
            startInfo.RedirectStandardOutput = true;
            startInfo.UseShellExecute = false;
            process.StartInfo = startInfo;
            process.Start();

            string output = process.StandardOutput.ReadToEnd(); process.WaitForExit();

            process.Close();



            textBox1.Text = output;
            textBox2.Text = "Select the file...";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            /* System.Diagnostics.Process process = new System.Diagnostics.Process();
             System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
             startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Normal;
             startInfo.FileName = "cmd-here.exe";
             startInfo.Arguments = "adb devices";
             startInfo.UseShellExecute = false;
             process.StartInfo = startInfo;
             process.Start();*/


            System.Diagnostics.Process process = new System.Diagnostics.Process();
            System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
            startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Normal;
            startInfo.FileName = "cmd.exe";
            startInfo.Arguments = "/c adb devices";
            startInfo.RedirectStandardOutput = true;
            startInfo.UseShellExecute = false;
            process.StartInfo = startInfo;
            process.Start();

            string output = process.StandardOutput.ReadToEnd(); process.WaitForExit();
            process.Close();
            textBox1.Text = output;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var fileContent = string.Empty;
            

            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = "c:\\";
                openFileDialog.Filter = "Rom image (*.img)|*.img|Rom zip (*.zip)|*.zip|All files (*.*)|*.*";
                openFileDialog.FilterIndex = 2;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    //Get the path of specified file
                    filePath = openFileDialog.FileName;

                    /*//Read the contents of the file into a stream
                    var fileStream = openFileDialog.OpenFile();

                    using (StreamReader reader = new StreamReader(fileStream))
                    {
                        fileContent = reader.ReadToEnd();
                    }*/
                }
            }

            /*MessageBox.Show("File: " + filePath, "File selected.",  MessageBoxButtons.OK);*/
            textBox2.Text = filePath;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process process = new System.Diagnostics.Process();
            System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
            startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            startInfo.FileName = "cmd.exe";
            startInfo.Arguments = "/c adb sideload \""+filePath+"\"" ;
            startInfo.RedirectStandardOutput = true;
            startInfo.UseShellExecute = false;
            startInfo.RedirectStandardError = true;
            process.StartInfo = startInfo;
            process.Start();

            string output = process.StandardOutput.ReadToEnd(); process.WaitForExit();
            string err = process.StandardError.ReadToEnd();

            process.Close();

            textBox1.Text = textBox1.Text + output;
            textBox1.Text = textBox1.Text + err;
        }




        private void button4_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process process = new System.Diagnostics.Process();
            System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
            startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            startInfo.FileName = "cmd.exe";
            startInfo.Arguments = "/c " + textBox3.Text;
            startInfo.RedirectStandardOutput = true;
            startInfo.UseShellExecute = false;
            startInfo.RedirectStandardError = true;
            process.StartInfo = startInfo;
            process.Start();

            string output = process.StandardOutput.ReadToEnd(); process.WaitForExit();
            string err = process.StandardError.ReadToEnd();

            process.Close();

            textBox3.Text = "";

            textBox1.Text = textBox1.Text + err;

            textBox1.Text = textBox1.Text + output;
        }
    }
}
