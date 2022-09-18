using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                listBox1.Items.Clear();
                StreamWriter streamWriter = new StreamWriter("pomocnik.txt");
                StreamReader streamReader = new StreamReader(openFileDialog1.FileName);
                int pocetSlov=0;
                char[] separators = { ' ' };
                while (!streamReader.EndOfStream)
                {
                    string line = streamReader.ReadLine();
                    int i = 0;
                    while(i<line.Length)
                    {
                        if (line[i] == ' ' && line[i + 1] == ' ')
                        {
                            string substr1 = line.Substring(0,i);
                            string substr2 = line.Substring(i+1);
                            line = substr1 + substr2;
                        }
                        else ++i;
                    }
                    string[] splitRadek = line.Split(separators, StringSplitOptions.RemoveEmptyEntries);
                    pocetSlov += splitRadek.Length;
                    streamWriter.WriteLine(line);
                }
                streamWriter.WriteLine("Počet slov je: " + pocetSlov);
                streamWriter.Close();
                streamReader.Close();
                File.Delete(openFileDialog1.FileName);
                File.Move("pomocnik.txt", openFileDialog1.FileName);
                streamReader=new StreamReader(openFileDialog1.FileName);
                while(!streamReader.EndOfStream)
                {
                    string line = streamReader.ReadLine();
                    listBox1.Items.Add(line);
                }
            }
        }
    }
}
