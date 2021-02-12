using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FoodApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SidePanle.Height = button1.Height;
            SidePanle.Top = button1.Top;
            about_us1.BringToFront();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SidePanle.Height = button2.Height;
            SidePanle.Top = button2.Top;
            menu1.BringToFront();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SidePanle.Height = button3.Height;
            SidePanle.Top = button3.Top;
            contact1.BringToFront();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            SidePanle.Height = button4.Height;
            SidePanle.Top = button4.Top;
            login1.BringToFront();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            SidePanle.Height = button6.Height;
            SidePanle.Top = button6.Top;
            register1.BringToFront();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            label4.Text =  login.Set_Login;
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            infomation1.BringToFront();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            int i = 0;
            label3.Text = "";
            foreach (string item in Class1.lista)
            {
              label3.Text += i+1 + ". " + item + "\n";
                i++;
            }
        

            label2.Text = "All  " + Class1.suma + "$";

        }

        private void button5_Click(object sender, EventArgs e)
        {
            buyPanel1.BringToFront();
        }

        private void buyPanel1_MouseClick(object sender, MouseEventArgs e)
        {
            about_us1.BringToFront();
        }
    }
}
