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

namespace Anticheat_V1._5__rewritten_
{
    public partial class Form1 : Form
    {
        public static string Path;
        public static string[] blacklist = { "aimbot", "wallhack", "fakelag", "wallhack", "readprocess", "openprocess", "csgo", "counterstrike", };
        public static bool Detected = false;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {

        }

        private void button1_MouseClick(object sender, MouseEventArgs e)
        {
            Path = richTextBox1.Text;
            string line;
            int Detections = 0;

            try
            {
                using (StreamReader sr = new StreamReader(Path))
                {
                    line = sr.ReadLine();

                    while (line != null)
                    {
                        for (int i = 0; i < blacklist.Length; i++)
                        {
                            if (line.Contains(blacklist[i]))
                            {
                                Detected = true;
                                Detections++;
                                break;
                            }

                        }
                        line = sr.ReadLine();
                    }
                    if (Detections == 0)
                        Detected = false;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            if (Detected)
            {
                richTextBox2.ForeColor = System.Drawing.Color.Red;
                richTextBox2.Text = "cheat detected";
            }
            else
            {
                richTextBox2.ForeColor = System.Drawing.Color.Lime;
                richTextBox2.Text = "no cheat detected";
            }
        }
    }
}
