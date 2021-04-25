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
        private void f1() // f1 sınıfı olusturdum.
        {
            XDocument deneme = XDocument.Load(linq);  

            string fileName = @"C:\Users\ahmet\source\repos\ntpvizeodev\ntpvizeodev\ntp.txt";// olusturulacak dosyanın konumunu belirler.

            FileInfo fi = new FileInfo(fileName); 
            FileStream fs = new FileStream(fileName, FileMode.OpenOrCreate, FileAccess.Write); //dosyayı olusturup düzenleyip yazmayı saglıyor.

            fs.Close();

            for (int i = 2; i < 50; i++)
            {
                string haber = deneme.Descendants("title").ElementAt(i).Value; // haber başlıklarını çeker.
                dataGridView1.Rows.Add(haber);       // tabloya verileri eklemeyi saglar
                string writeText = haber;            
                File.AppendAllText(fileName, Environment.NewLine + writeText);// txt dosyasına yazı yazdırır.
            }
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e) 
        {

        }

        private void button1_Click(object sender, EventArgs e) // buton 1 e tıklandıgında // sil butonu
        {
            string fileName = @"C:\Users\ahmet\source\repos\ntpvizeodev\ntpvizeodev\ntp.txt"; // dosyayı cagırır.

            File.Delete(fileName); // txt dosyasını siler,

            dataGridView1.Rows.Clear();// tabloyu siler.
        }

        private void button2_Click(object sender, EventArgs e) // goruntulenme butonu
        {
            f1(); // f1 sınıfını cagırır.
        }

        private void button3_Click(object sender, EventArgs e) // guncelleme butonu 
        {
            string fileName = @"C:\Users\ahmet\source\repos\ntpvizeodev\ntpvizeodev\ntp.txt"; //dosyamız.
            File.Delete(fileName); // txt dosyaysını siler
            dataGridView1.Rows.Clear(); // tablodaki verileri siler.
            f1(); // f1 sınıfını cagırır.
        }
    }
}
