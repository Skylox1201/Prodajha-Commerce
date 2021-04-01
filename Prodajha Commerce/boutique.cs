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

namespace Prodajha_Commerce
{
    public partial class Boutique : Form
    {
        MySqlConnection conn = new MySqlConnection("database=boutique; server=localhost; port=3306;user id = root; pwd=");
        Session user = new Session();
        Magasin Magasin = new Magasin();

        public Boutique(string client)
        {
            InitializeComponent();
            ArticleGrid.DataSource = display_Article_Table(client);
            ArticleGrid.Columns["idArticle"].ReadOnly = true;
            user.setClient(client);
            get_magasin(user.getClient());
        }

        public DataTable display_Article_Table(string client) // Fonction pour charger la table SQL "user" 
        {
            MySqlCommand cmd = conn.CreateCommand();
            MySqlDataAdapter mydtadp_user = new MySqlDataAdapter(); // créé un objet pour remplir
            DataTable table_article = new DataTable(); // créé un objet de table de données

            cmd.Parameters.AddWithValue("@client", client);
            cmd.CommandText = "SELECT article.idArticle, article.nom, article.prix, article.quantite, categorie.nom FROM article INNER JOIN magasin ON magasin.idMagasin = article.idMagasin INNER JOIN categorie ON article.idCategorie = categorie.idCategorie WHERE magasin.idProprietaire = @client";
            mydtadp_user.SelectCommand = cmd;
            mydtadp_user.Fill(table_article); // rempli cette table par les données récupéré par la commande SQL

            return table_article; // retourne le tableau
        }

        private void get_magasin(string user)
        {
            MySqlCommand cmd = conn.CreateCommand();

            cmd.Parameters.AddWithValue("@client", user);
            cmd.CommandText = "CALL get_magasin(@client)";
            try
            {
                conn.Open();
                MySqlDataReader reader = cmd.ExecuteReader();
                int i = 0;
                while (reader.Read())
                {
                    i++;

                    Magasin.setNom(reader.GetString(0));
                    Magasin.setAdresse1(reader.GetString(1));
                    Magasin.setAdresse2(reader.GetString(2));
                    Magasin.setCity(reader.GetString(3));
                    Magasin.set_code_postal(reader.GetString(4));
                    Magasin.setRegion(reader.GetString(5));
                    Magasin.setPhone(reader.GetString(6));

                    MagasinNom.Text = Magasin.getNom();
                    Adresse1.Text = Magasin.getAdresse1();
                    Adresse2.Text = Magasin.getAdresse2();
                    Ville.Text = Magasin.getCity();
                    CodePostal.Text = Magasin.get_code_postal();
                    MagasinRegion.Text = Magasin.getRegion();
                    Telephone.Text = Magasin.getRegion();
                }
                if (i == 0)
                {
                    MessageBox.Show("Magasin non trouvé");
                    this.Close();
                    Connection Connection = new Connection();
                    Connection.Show();
                }
                conn.Close();
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex);
            }
        }

        private void ArticleGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int row = e.RowIndex;
            if (row != -1)
            {
                string idart = ArticleGrid[0, row].Value.ToString();
                string idClient = user.getClient();
                ArticleView articleView = new ArticleView(idClient, idart);
                articleView.Show();
                this.Hide();
            }
        }

        private void Boutique_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void CodePostal_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Verify that the pressed key isn't CTRL or any non-numeric digit
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void Telephone_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Verify that the pressed key isn't CTRL or any non-numeric digit
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void Adresse1_Leave(object sender, EventArgs e)
        {
            if (Adresse1.Text != Magasin.getAdresse1())
            {
                MySqlCommand cmd = conn.CreateCommand();

                cmd.Parameters.AddWithValue("@adresse1", Adresse1.Text);
                cmd.Parameters.AddWithValue("@client", user.getClient());
                cmd.CommandText = "CALL save_adresse1(@adresse1, @client)";
                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();

                    Console_magasin.Text = "§ Adresse 1 passer à " + Adresse1.Text + "\r\n" + Console_magasin.Text;
                    Magasin.setAdresse1(Adresse1.Text);
                }
                catch (MySqlException ex)
                {
                    Console.WriteLine(ex);
                }
            }
        }

        private void MagasinNom_Leave(object sender, EventArgs e)
        {
            if (MagasinNom.Text != Magasin.getNom())
            {
                MySqlCommand cmd = conn.CreateCommand();

                cmd.Parameters.AddWithValue("@nom", MagasinNom.Text);
                cmd.Parameters.AddWithValue("@client", user.getClient());
                cmd.CommandText = "CALL save_magasin_nom(@nom, @client)";
                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();

                    Console_magasin.Text = "§ Nom du magasin passer à " + MagasinNom.Text + "\r\n" + Console_magasin.Text;
                    Magasin.setNom(MagasinNom.Text);
                }
                catch (MySqlException ex)
                {
                    Console.WriteLine(ex);
                }
            }
        }

        private void Adresse2_Leave(object sender, EventArgs e)
        {
            if (Adresse2.Text != Magasin.getAdresse2())
            {
                MySqlCommand cmd = conn.CreateCommand();

                cmd.Parameters.AddWithValue("@adresse2", Adresse2.Text);
                cmd.Parameters.AddWithValue("@client", user.getClient());
                cmd.CommandText = "CALL save_adresse2(@adresse2, @client)";
                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();

                    Console_magasin.Text = "§ Adresse 2 passer à " + Adresse2.Text + "\r\n" + Console_magasin.Text;
                    Magasin.setAdresse2(Adresse2.Text);
                }
                catch (MySqlException ex)
                {
                    Console.WriteLine(ex);
                }
            }
        }

        private void MagasinRegion_Leave(object sender, EventArgs e)
        {
            if (MagasinRegion.Text != Magasin.getRegion())
            {
                MySqlCommand cmd = conn.CreateCommand();

                cmd.Parameters.AddWithValue("@region", MagasinRegion.Text);
                cmd.Parameters.AddWithValue("@client", user.getClient());
                cmd.CommandText = "CALL save_region(@region, @client)";
                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();

                    Console_magasin.Text = "§ Région passer à " + MagasinRegion.Text + "\r\n" + Console_magasin.Text;
                    Magasin.setRegion(MagasinRegion.Text);
                }
                catch (MySqlException ex)
                {
                    Console.WriteLine(ex);

                }
            }
        }

        private void Ville_Leave(object sender, EventArgs e)
        {
            if (Ville.Text != Magasin.getCity())
            {
                MySqlCommand cmd = conn.CreateCommand();

                cmd.Parameters.AddWithValue("@ville", Ville.Text);
                cmd.Parameters.AddWithValue("@client", user.getClient());
                cmd.CommandText = "CALL save_ville(@ville, @client)";
                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();

                    Console_magasin.Text = "§ Ville passer à " + Ville.Text + "\r\n" + Console_magasin.Text;
                    Magasin.setCity(Ville.Text);
                }
                catch (MySqlException ex)
                {
                    Console.WriteLine(ex);
                }
            }
        }

        private void CodePostal_Leave(object sender, EventArgs e)
        {
            if (CodePostal.Text != Magasin.get_code_postal())
            {
                MySqlCommand cmd = conn.CreateCommand();

                cmd.Parameters.AddWithValue("@CodePostal", CodePostal.Text);
                cmd.Parameters.AddWithValue("@client", user.getClient());
                cmd.CommandText = "CALL save_codePostal(@CodePostal, @client)";
                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();

                    Console_magasin.Text = "§ Code Postal passer à " + CodePostal.Text + "\r\n" + Console_magasin.Text;
                }
                catch (MySqlException ex)
                {
                    Console.WriteLine(ex);
                }
            }
        }

        private void Telephone_Leave(object sender, EventArgs e)
        {
            if (Telephone.Text != Magasin.getPhone())
            {
                MySqlCommand cmd = conn.CreateCommand();

                cmd.Parameters.AddWithValue("@telephone", Telephone.Text);
                cmd.Parameters.AddWithValue("@client", user.getClient());
                cmd.CommandText = "CALL save_telephone(@telephone, @client)";
                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();

                    Console_magasin.Text = "§ Numéro de téléphone passer à " + Telephone.Text + "\r\n" + Console_magasin.Text;
                }
                catch (MySqlException ex)
                {
                    Console.WriteLine(ex);
                }
            }
        }

        private void MagasinNom_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {
                label1.Focus();
            }
        }

        private void Adresse1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {
                label1.Focus();
            }
        }

        private void Adresse2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {
                label1.Focus();
            }
        }

        private void MagasinRegion_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {
                label1.Focus();
            }
        }

        private void Ville_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {
                label1.Focus();
            }
        }

        private void Telephone_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {
                label1.Focus();
            }
        }
    }
}
