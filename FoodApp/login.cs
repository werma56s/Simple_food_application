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
    public partial class login : UserControl
    {
        public login()
        {
            InitializeComponent();
        }
        public static string Set_Login = "";
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
        public static bool VerifyMd5Hash(MD5 md5Hash, string input, string hash)
        {
            string hashOfInput = GetMd5Hash(md5Hash, input);

            StringComparer comparer = StringComparer.OrdinalIgnoreCase;

            if (0 == comparer.Compare(hashOfInput, hash))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        void Polacznie1()
        {
            MySqlConnection polaczenie = new MySqlConnection("server=localhost; user=root; database=food; port=3306; pooling=false");
            MySqlDataAdapter komenda = new MySqlDataAdapter("SELECT count(id) FROM data where Login='" + LoginBox.Text + "'", polaczenie);
            try
            {
                DataTable dt = new DataTable();
                komenda.Fill(dt);
                if (dt.Rows[0][0].ToString() == "1")
                {
                    MD5 hashMd5 = MD5.Create();
                    string haslo = GetMd5Hash(hashMd5, PasswodBox.Text);

                    MySqlDataAdapter komenda1 = new MySqlDataAdapter("SELECT Password FROM data where Login='" + LoginBox.Text + "'", polaczenie);
                    DataTable dt1 = new DataTable();
                    komenda1.Fill(dt1);

                    string haslozBazy = dt1.Rows[0][0].ToString();

                    if (VerifyMd5Hash(hashMd5, PasswodBox.Text, haslozBazy))
                    {
                        Set_Login = "Welcom, " +  LoginBox.Text;
                        MessageBox.Show("Login Succes.", "Congrates", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Hide();
                        Form1 NewPanel = new Form1();
                        NewPanel.Show();
                    }
                    else
                    {
                        MessageBox.Show("Either your Password is incorrect.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        LoginBox.Clear();
                        PasswodBox.Clear();
                    }
                }
                else
                {
                    MessageBox.Show("This Login not Exist.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    LoginBox.Clear();
                    PasswodBox.Clear();
                }



            }
            catch (Exception ex)
            {
                string byk = string.Format("Problem registering user: \n{0}.", ex.Message);
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
            if (LoginBox.Text.Equals(" ") || LoginBox.Text.Equals("") || PasswodBox.Text.Equals(" ") || PasswodBox.Text.Equals(""))
            {
                MessageBox.Show("Login or password is empty, or are the defaults.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                Polacznie1();
            }
        }
    }
}
