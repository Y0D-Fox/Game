using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;

namespace Game
{
    public partial class Spider_Game : Form

    {
        int timerlive=0;
        Bitmap bmp = new Bitmap(816, 475);
        Random rnd = new Random();
        int i = 4;
        int click;
        public Spider_Game()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
    //не рабочая кнопка
            timer1.Enabled = true;

           

        }

        private void button2_Click(object sender, EventArgs e)
        {
        label3.Text = "0";

            Properties.Settings.Default.point=0;
            pictureBox1.Visible = false;
            pictureBox2.Visible = false;
            pictureBox3.Visible = false;
            timer1.Enabled = true;

            //timer5.Enabled = true;

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            click++; 
            Properties.Settings.Default.point++;
            label3.Text = Convert.ToString(Properties.Settings.Default.point);
            pictureBox1 .Visible = false;
            timer3.Enabled = true;
            timer5.Enabled = true;
        }

        public void Spider_Game_Load(object sender, EventArgs e)
        {
            timer5.Interval = 1000;
            label3.Text = Convert.ToString(Properties.Settings.Default.point);
            for (int y = 0; y < 475; y++)
            {
                for (int x = 0; x < 816; x++)
                {
                 

                }
            }
            timer4.Enabled = true;
          
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

            i--;
            label2.Text = i.ToString();

            if (i == 0)
            {
                label2.Text = "Дави их";
                pictureBox1.Visible = true;
                timer5.Enabled = true;
                timer1.Stop();
            }
            else if (i < 0)
            {
                i = 4;
            }
            timer2.Enabled = true;
           
        }
        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
          
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            MouseEventArgs me = (MouseEventArgs)e;
            Point cursor = me.Location;
            if (cursor.X - 1 >= 0 && cursor.X + 1 <= 500 && cursor.Y - 1 >= 0 && cursor.Y + 1 <= 400);
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
         
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            int x = rnd.Next(20, 500);
            int y = rnd.Next(50, 400);
            int x1 = rnd.Next(30, 495);
            int y1 = rnd.Next(25, 365);
            int x2 = rnd.Next(41, 450);
            int y2 = rnd.Next(27, 395);
            pictureBox1.Top = y;
            pictureBox1.Left = x; 
            pictureBox2.Top = y1;
            pictureBox2.Left = x1;
            pictureBox3.Top = y2;
            pictureBox3.Left = x2;
        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            if (pictureBox1.Visible==false){ 
            pictureBox1.Visible = false;
            Task.Delay(10000);
            pictureBox1.Visible = true; }
          
        }

        private void timer4_Tick(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.point == 15)
            {
                pictureBox2.Visible = true;
                timer6.Enabled = true;
            }
            else if (Properties.Settings.Default.point == 30)
            {
                pictureBox3.Visible = true;
                timer7.Enabled = true;
            }
            else if (Properties.Settings.Default.point == 60)
            {
                timer1.Enabled = false;
                timer2.Enabled = false;
                pictureBox1.Visible = false;
                pictureBox2.Visible = false;
                pictureBox3.Visible = false;
                timer5.Enabled = false;
                timer3.Enabled = false;
                timer6.Enabled = false;
                timer7.Enabled = false;
                DialogResult dialogResult = MessageBox.Show("Поздравляю вы выйграли", "Ура!!!", MessageBoxButtons.OK);
                if (dialogResult == DialogResult.OK)
                {
                    Close();
                }
            }

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            timer5.Enabled = true; 
            click++; 
            Properties.Settings.Default.point++;
            label3.Text = Convert.ToString(Properties.Settings.Default.point);
            pictureBox2.Visible = false;

            timer6.Enabled = true;
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            timer5.Enabled = true;
            click++; 
            Properties.Settings.Default.point++;
            label3.Text = Convert.ToString(Properties.Settings.Default.point);
            pictureBox3.Visible = false;

            timer7.Enabled = true;
        }

        private void pictureBox3_MouseMove(object sender, MouseEventArgs e)
        {
            MouseEventArgs me = (MouseEventArgs)e;
            Point cursor = me.Location;
            if (cursor.X - 1 >= 0 && cursor.X + 1 <= 500 && cursor.Y - 1 >= 0 && cursor.Y + 1 <= 400) ;
        }

        private void pictureBox2_MouseMove(object sender, MouseEventArgs e)
        {
            MouseEventArgs me = (MouseEventArgs)e;
            Point cursor = me.Location;
            if (cursor.X - 1 >= 0 && cursor.X + 1 <= 500 && cursor.Y - 1 >= 0 && cursor.Y + 1 <= 400);
        }

        private void timer6_Tick(object sender, EventArgs e)
        {
            if (pictureBox2.Visible == false)
            {
                pictureBox2.Visible = false;
                Task.Delay(10000);
                pictureBox2.Visible = true;
            }
        }

        private void timer7_Tick(object sender, EventArgs e)
        {
            if (pictureBox3.Visible == false)
            {
                pictureBox3.Visible = false;
                Task.Delay(10000);
                pictureBox3.Visible = true;
            }
        }

        private void timer5_Tick(object sender, EventArgs e)
        {
            timerlive++;
            label5.Text = timerlive.ToString();
            timer5.Start();
            if (timerlive == 10 && click >= 3)
            {
                    click = 0;
                    timerlive = 0;
                    label5.Text = timerlive.ToString("0");
            }
           if (click <= 3 && timerlive == 10)
           { timer1.Stop();
              timer2.Stop();
                timer5.Stop(); 
                DialogResult dialogResult = MessageBox.Show("Игра окончена", "Вы проиграли >:|", MessageBoxButtons.OK);
                if (dialogResult == DialogResult.OK)
                {
                    Close();
                }
               
            }
        }

        private void timer8_Tick(object sender, EventArgs e)
        {
           
        }
    }
}