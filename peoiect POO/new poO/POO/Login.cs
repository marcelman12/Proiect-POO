using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace POO
{
    public partial class Login : Form
    {
        private const string ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\buzdu\Downloads\new poO\new poO\POO\baza_date.mdf;Integrated Security=True";
        SqlConnection conn = new SqlConnection(ConnectionString);

        public Login()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT Functie FROM [User] WHERE Mail = @Mail AND Parola = @Parola", conn);
                cmd.Parameters.AddWithValue("@Mail", textBox1.Text);
                cmd.Parameters.AddWithValue("@Parola", textBox2.Text);
                SqlDataReader reader = cmd.ExecuteReader();
                string functie;
                if (reader.Read())
                {
                    functie = reader["Functie"].ToString(); if (reader.Read())
                        conn.Close();
                }
                functie = comboBox1.SelectedItem.ToString();
                switch (functie)
                {
                    case "Administrator":
                        this.Hide();
                        HomeAdmin f1 = new HomeAdmin();
                        f1.Show();
                        break;
                    case "Secretariat":
                        this.Hide();
                        HomeSecretar f2 = new HomeSecretar();
                        f2.Show();
                        break;
                    case "Profesor":
                        this.Hide();
                        HomeP f3 = new HomeP();
                        f3.Show();
                        break;
                    case "Student":
                        this.Hide();
                        HomeS f4 = new HomeS();
                        f4.Show();
                        break;
                }
                if (reader.Read())
                {
                    reader.Close();
                    conn.Close();
                    MessageBox.Show("Adresa de email sau parola sunt incorecte!");
                }
                reader.Close();
            }
            catch(Exception ex)
            {

            MessageBox.Show(ex.Message); 
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }
    }
}
