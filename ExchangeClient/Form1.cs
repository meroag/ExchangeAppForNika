using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace ExchangeClient
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            loadFile();
            Timer t = new Timer();
            t.Tick += T_Tick;
            t.Interval = 10 * 1000;
            t.Start();
        }

        private void T_Tick(object sender, EventArgs e)
        {
            try
            {
                loadFile();
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
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
            if (File.Exists("back.jpg"))
                BackgroundImage = Image.FromFile("back.jpg");
        }
    }
}
