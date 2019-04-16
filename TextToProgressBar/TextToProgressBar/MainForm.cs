using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.IO;
using System.Windows.Forms;

namespace TextToProgressBar
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                label3.Visible = true;
                using (var fileStream = File.OpenRead(openFileDialog1.FileName))
                {
                    //progressBar1.Maximum = (int)fileStream.Length;
                    progressBar1.Maximum = 10000;
                    progressBar1.Value = 0;
                    int fileResult;
                    
                    while ((fileResult = fileStream.ReadByte()) != -1)
                    {
                        Thread.Sleep(5);
                        byte bytevalue = (byte)fileResult;
                        progressBar1.Value= (int)fileStream.Position;
                        label3.Text = progressBar1.Value.ToString()+" byte";
                    }
                    MessageBox.Show("Файл " + openFileDialog1.FileName + " размером " + fileStream.Length + " прочитан!");
                }
            }
            //string filename = @"C:\Users\Aqua\Desktop\шептор.txt";
           
        
            
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show(this, "Exit?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                e.Cancel = true;
            }
        }
    }
}
