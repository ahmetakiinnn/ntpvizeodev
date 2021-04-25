using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using System.IO;
using System.Windows.Forms;

namespace ntpvizeodev
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public const string linq = "https://www.milliyet.com.tr/rss/rssnew/gundemrss.xml";

        private void Form1_Load(object sender, EventArgs e)
        {
           

        }
        private void f1()
        {
            XDocument deneme = XDocument.Load(linq); 

            string fileName = @"C:\Users\ahmet\source\repos\ntpvizeodev\ntpvizeodev\ntp.txt";

            FileInfo fi = new FileInfo(fileName);
            FileStream fs = new FileStream(fileName, FileMode.OpenOrCreate, FileAccess.Write);

            fs.Close();

            for (int i = 2; i < 50; i++)
            {
                string haber = deneme.Descendants("title").ElementAt(i).Value;
                dataGridView1.Rows.Add(haber);
                string writeText = haber;
                File.AppendAllText(fileName, Environment.NewLine + writeText);
            }
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string fileName = @"C:\Users\ahmet\source\repos\ntpvizeodev\ntpvizeodev\ntp.txt";
            File.Delete(fileName);
            dataGridView1.Rows.Clear();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            f1();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string fileName = @"C:\Users\ahmet\source\repos\ntpvizeodev\ntpvizeodev\ntp.txt";
            File.Delete(fileName);
            dataGridView1.Rows.Clear();
            f1();
        }
    }
}
