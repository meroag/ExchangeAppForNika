using System;
using System.Drawing;
using System.IO;

using System.Windows.Forms;

namespace ExchangeApp
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            loadFile();
        }

        private void btnChangeBackGround_Click(object sender, EventArgs e)
        {
            OpenFileDialog of = new OpenFileDialog();
            of.Multiselect = false;
            of.Filter = "Pics (*.jpg)|*.jpg";
            if (of.ShowDialog() == DialogResult.OK)
            {
                var img = Image.FromFile(of.FileName);
                img.Save("back.jpg");
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var buttonNumber = Convert.ToInt32((sender as Button).Name[6].ToString());
            saveInfo(buttonNumber);
        }

        private void saveInfo( int i)
        {
            var n = Controls["number" + i].Text;
            var t = Controls["text" + i].Text;
            var f = File.OpenWrite(i + ".txt");
            try
            {
                var writter = new StreamWriter(f);
                writter.WriteLine(n);
                writter.WriteLine(t);
                writter.Flush();
                writter.Close();
                f.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show("კლიენტის განახლების პროცესშია გთოხვთ ცადოთ თავიდან");
            }
        }

        private void loadFile()
        {
            for (int i = 1; i <= 8; i++)
            {
                if (File.Exists(i + ".txt"))
                {
                    var f = File.OpenText(i + ".txt");
                    Controls["number" + i].Text = f.ReadLine();
                    Controls["text" + i].Text = f.ReadLine();
                    f.Close();
                }
            }
        }
    }
}
