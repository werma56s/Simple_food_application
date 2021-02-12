using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Security.Cryptography;

namespace FoodApp
{
    public partial class Register : UserControl
    {
        public Register()
        {
            InitializeComponent();
        }
        public static string GetMd5Hash(MD5 md5Hash, string input)
        {

            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

            StringBuilder sBuilder = new StringBuilder();

            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            return sBuilder.ToString();
        }
        void Rejestracja()
        {
            MySqlConnection polaczenie = new MySqlConnection("server=localhost; user=root; database=food; port=3306; pooling=false");
            MySqlCommand komenda = polaczenie.CreateCommand();
            MySqlCommand komenda1 = polaczenie.CreateCommand();
            try
            {

                if (polaczenie.State == ConnectionState.Closed)
                {
                    polaczenie.Open();
                    
                    string haslo = PasswordBox.Text;

                    using (MD5 hash = MD5.Create())
                    {
                        haslo = GetMd5Hash(hash, haslo);
                    }

                    komenda1.CommandText = string.Format("SELECT count(id) FROM data where Login='" + LoginBox.Text + "'");
                    int wartosc = Convert.ToInt32(komenda1.ExecuteScalar());
                    if (wartosc == 1)
                    {
                        MessageBox.Show(String.Format("Login: {0}, already exists.", LoginBox.Text), "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        komenda.CommandText = string.Format("INSERT INTO data(Login,Password,Resort,Street,NumerHouse) VALUES('{0}','{1}','{2}','{3}','{4}')", LoginBox.Text, haslo, ResortBox.Text, StreetBox.Text, HostNumberBox.Text);
                        if (komenda.ExecuteNonQuery() == 1)
                        {
                            MessageBox.Show("You have logged successfuly. Now you can Login!", "Informacja", MessageBoxButtons.OK, MessageBoxIcon.Information);                 
                        }
                        else
                        {
                            MessageBox.Show("Login Error.", "Informacja", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    HostNumberBox.Clear(); StreetBox.Clear(); ResortBox.Clear(); LoginBox.Clear(); PasswordBox.Clear(); LoginBox.Focus();

                }

            }
            catch (Exception ex)
            {
                string byk = string.Format("Problem register with user: \n{0}.", ex.Message);
                MessageBox.Show(byk, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            finally
            {
                if (polaczenie.State == ConnectionState.Open)
                {
                    polaczenie.Close();
                }
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            if (LoginBox.Text.Equals("") || ResortBox.Text.Equals("") || PasswordBox.Text.Equals("") || StreetBox.Text.Equals("") || HostNumberBox.Text.Equals(""))
            {
                MessageBox.Show("Yours data are empty.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (LoginBox.TextLength < 4)
            {
                MessageBox.Show("Login must be have 4 characters", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (PasswordBox.TextLength < 4)
            {
                MessageBox.Show("Password must have 4 characters", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                Rejestracja();
            }
        }
    }
}
