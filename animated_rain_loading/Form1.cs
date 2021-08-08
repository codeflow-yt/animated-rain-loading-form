using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;


namespace animated_rain_loading
{
    public partial class Form1 : Form
    {
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn(
                int left,
                int top,
                int right,
                int bottom,
                int width,
                int height
            );

        int loadingSpeed = 4;
        int loadingPercentage = 0;

        List<RainDrop> rainDrops = new List<RainDrop>();
        Puddle puddle;

        public Form1()
        {
            InitializeComponent();
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 7, 7));
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            rainDrops.Add(new RainDrop { Speed = 4, View = pictureBox3 });
            rainDrops.Add(new RainDrop { Speed = 6, View = pictureBox4 });
            rainDrops.Add(new RainDrop { Speed = 8, View = pictureBox5 });
            rainDrops.Add(new RainDrop { Speed = 3, View = pictureBox6 });
            rainDrops.Add(new RainDrop { Speed = 5, View = pictureBox7 });
            rainDrops.Add(new RainDrop { Speed = 6, View = pictureBox8 });
            rainDrops.Add(new RainDrop { Speed = 7, View = pictureBox9 });
            rainDrops.Add(new RainDrop { Speed = 4, View = pictureBox10 });

            puddle = new Puddle(pictureBox2);
            puddle.Percentage = loadingPercentage;

            timer1.Start();
            timer2.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            foreach (RainDrop rainDrop in rainDrops)
                rainDrop.Move();
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            loadingPercentage += loadingSpeed;
            
            if (loadingPercentage >= 100)
			{
                timer2.Stop();
                loadingPercentage = 100;
            }

            label1.Text = loadingPercentage + " %";

            puddle.Percentage = loadingPercentage;
        }
    }
}
