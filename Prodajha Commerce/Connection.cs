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
        MySqlConnection conn = new MySqlConnection("database=boutique; server=localhost; port=3306;user id = root; pwd="); //Connection à la base de donnée
        public Connection()
        {
            InitializeComponent();
            textBoxMail.Text = "Adresse Mail";
            textBoxPassword.Text = "Mot de passe";
        }

        protected void button1_Click(object sender, EventArgs e)
        {
            string email = textBoxMail.Text.ToLower(); //récupère le mail passé
            string pwd = textBoxPassword.Text; //récupère le mot de passe passé
            MySqlCommand command = conn.CreateCommand();

            command.Parameters.AddWithValue("@email", email);
            command.CommandText = "SELECT email, password, idClient FROM client WHERE email = @email;";
            try
            {
                conn.Open();
                MySqlDataReader reader = command.ExecuteReader();
                int i = 0;
                while (reader.Read()) //Si on trouve dans la base de donnée un mail correspondant
                {
                    i++;
                    string valeur = reader.GetString(0);
                    if (BCrypt.Net.BCrypt.Verify(pwd, reader.GetString(1))) //Si le hash du mot de passe enregistré est le même que le mot de passe enregistré
                    {
                        string client = reader.GetString(2);
                        Boutique Boutique = new Boutique(client);
                        Boutique.Show(); //Affiche le magasin coorespondant
                        this.Hide();
                    }
                    else // Si les mots de passes ne correspondent pas
                    {
                       MessageBox.Show("Adresse mail ou mot de passe incorrect");
                    }                  
                }
                if(i == 0) //Si on a pas trouvé de mail correspondant
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
            //Si on a rien entré, supprime le texte pour laisser un champ vide
            if (textBoxMail.Text == "Adresse Mail")
                textBoxMail.Text = "";
        }

        private void textBoxMail_Leave(object sender, EventArgs e)
        {
            //Si on a rien entré, remplace le texte par adresse mail
            if (string.IsNullOrWhiteSpace(textBoxMail.Text))
                textBoxMail.Text = "Adresse Mail";
        }


        private void textBoxPassword_Enter(object sender, EventArgs e)
        {
            //Si on a rien entré, supprime le texte pour laisser un champ vide
            if (textBoxPassword.Text == "Mot de passe")
            {
                textBoxPassword.PasswordChar = '*' ; //Fait en sirte qu'on ne voit pas ce qui est écrit
                textBoxPassword.Text = "";
            }
                
        }
        private void textBoxPassword_Leave(object sender, EventArgs e)
        {
            //Si on a rien entré, remplace le texte par Mot de passe et fait en sorte que le texte soit visible
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
                //Si on appuie sur entré et que les 2 champs ont été saisis, appuie sur le bouton se connecter
                if (textBoxPassword.Text != "Mot de passe" || !string.IsNullOrWhiteSpace(textBoxPassword.Text)|| textBoxMail.Text != "Adresse Mail" || !string.IsNullOrWhiteSpace(textBoxMail.Text))
                {
                    button1.PerformClick();
                }
            }
        }
    }
}
