using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using BCrypt.Net;

namespace Prodajha_Commerce
{
    public partial class Connection : Form
    {
        MySqlConnection conn = new MySqlConnection("database=boutique; server=localhost; port=3306;user id = root; pwd=");
        public Connection()
        {
            InitializeComponent();
            textBoxMail.Text = "Adresse Mail";
            textBoxPassword.Text = "Mot de passe";
        }

        protected void button1_Click(object sender, EventArgs e)
        {
            string email = textBoxMail.Text.ToLower();
            string pwd = textBoxPassword.Text;
            MySqlCommand command = conn.CreateCommand();

            command.Parameters.AddWithValue("@email", email);
            command.CommandText = "SELECT email, password, idClient FROM client WHERE email = @email;";
            try
            {
                conn.Open();
                MySqlDataReader reader = command.ExecuteReader();
                int i = 0;
                while (reader.Read())
                {
                    i++;
                    string valeur = reader.GetString(0);
                    if (BCrypt.Net.BCrypt.Verify(pwd, reader.GetString(1)))
                    {
                        string client = reader.GetString(2);
                        Boutique Boutique = new Boutique(client);
                        Boutique.Show();
                        this.Hide();
                    }
                    else
                    {
                       MessageBox.Show("Adresse mail ou mot de passe incorrect");
                    }                  
                }
                if(i == 0)
                {
                    MessageBox.Show("Adresse mail ou mot de passe incorrect");
                }
                conn.Close();
            }
            catch(MySqlException ex)
            {
                Console.WriteLine(ex);
            }

        }

        private void textBoxMail_Enter(object sender, EventArgs e)
        {
            if (textBoxMail.Text == "Adresse Mail")
                textBoxMail.Text = "";
        }

        private void textBoxMail_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBoxMail.Text))
                textBoxMail.Text = "Adresse Mail";
        }

        private void textBoxPassword_Enter(object sender, EventArgs e)
        {
            if (textBoxPassword.Text == "Mot de passe")
            {
                textBoxPassword.PasswordChar = '*' ;
                textBoxPassword.Text = "";
            }
                
        }
        private void textBoxPassword_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBoxPassword.Text))
            {
                textBoxPassword.Text = "Mot de passe";
                textBoxPassword.PasswordChar = '\0' ;
            }
        }

        private void textBoxPassword_KeyDown(object sender, KeyEventArgs e)
        {    
            if (e.KeyCode == Keys.Return)
            {
                if (textBoxPassword.Text != "Mot de passe" || !string.IsNullOrWhiteSpace(textBoxPassword.Text)
                    || textBoxMail.Text != "Adresse Mail" || !string.IsNullOrWhiteSpace(textBoxMail.Text))
                {
                    button1.PerformClick();
                }
            }
        }
    }
}
