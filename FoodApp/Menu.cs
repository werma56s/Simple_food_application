using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Timers;
using MySql.Data.MySqlClient;
using System.Collections.Generic;

namespace FoodApp
{
    public partial class menu : UserControl
    {
    
        public static string Set_Name_Of_Product = "";
        public static string Set_Price = "";
        public static int Set_Id = 0;


        public menu()
        {
            InitializeComponent();
            this.DoubleBuffered = true;
        }    

        bool Polacznie( string price, string Name)
        {
            MySqlConnection polaczenie = new MySqlConnection("server=localhost; user=root; database=food; port=3306; pooling=false");
            MySqlDataAdapter komenda = new MySqlDataAdapter("SELECT count(id) FROM product where Name='" + Name + "'", polaczenie);
            try
            {
                Set_Name_Of_Product = Name;
                DataTable dt = new DataTable();
                komenda.Fill(dt);
                if (dt.Rows[0][0].ToString() == "1")
                {

                        komenda= new MySqlDataAdapter("SELECT count(id) FROM product where Price = '" + price + "'", polaczenie);
                        komenda.Fill(dt);
                        if (dt.Rows[0][0].ToString() == "1")
                        {
                           Set_Price = price; 
                           return true;
                        }
                        else
                        {
                            MessageBox.Show("Error.", "Informacja", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return false;
                        }
                    
                }
                else
                {
                    MessageBox.Show("Error2.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }


            }
            catch (Exception ex)
            {
                string byk = string.Format("Problem: \n{0}.", ex.Message);
                MessageBox.Show(byk, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            finally
            {
                if (polaczenie.State == ConnectionState.Open)
                {
                    polaczenie.Close();
                }
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Set_Id++;
            if (Polacznie( "19,40", label_1.Text) == true) { Class1.Addd(19.40,Set_Name_Of_Product, Set_Price); }
            button1.BackColor = Color.DarkGray;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Set_Id++;
            if (Polacznie("30,30",label8.Text) == true) { Class1.Addd(30.30,Set_Name_Of_Product, Set_Price); }
            button2.BackColor = Color.DarkGray;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Set_Id++;
            if (Polacznie( "20,47", label12.Text) == true) { Class1.Addd(20.47,Set_Name_Of_Product, Set_Price); }
            button4.BackColor = Color.DarkGray;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Set_Id++;
            if (Polacznie("22,38", label10.Text) == true) { Class1.Addd(22.38,Set_Name_Of_Product, Set_Price); }
            button3.BackColor = Color.DarkGray;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Set_Id++;
            if (Polacznie("4,50", label16.Text) == true) { Class1.Addd(4.50,Set_Name_Of_Product, Set_Price); }
            button6.BackColor = Color.DarkGray;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Set_Id++;
            if (Polacznie("7,33", label14.Text) == true) { Class1.Addd(7.33,Set_Name_Of_Product, Set_Price); }
            button5.BackColor = Color.DarkGray;
        }
    }
}
