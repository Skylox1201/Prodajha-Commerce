using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Net;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Prodajha_Commerce
{
    public partial class ArticleView : Form
    {
        MySqlConnection conn = new MySqlConnection("database=boutique; server=localhost; port=3306;user id = root; pwd=");
        Session client = new Session();
        Article ArticleModif = new Article();

        public ArticleView(string user, string article = null)
        {
            client.setClient(user);
            InitializeComponent();
            get_categories();
            if (article != null && article != "")
            {
                ArticleModif.setArticle(article);
                MySqlCommand cmd = conn.CreateCommand();
                Supprimer.Visible = true;
                Supprimer.Enabled = true;

                cmd.Parameters.AddWithValue("@client", user);
                cmd.Parameters.AddWithValue("@article", article);
                cmd.CommandText = "SELECT article.nom, article.prix, article.quantite, article.description, article.image, categorie.nom FROM article INNER JOIN magasin ON magasin.idMagasin = article.idMagasin INNER JOIN categorie ON article.idCategorie = categorie.idCategorie WHERE magasin.idProprietaire = @client AND article.idArticle = @article";
                try
                {
                    conn.Open();
                    MySqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        ArticleName.Text = reader.GetString(0);
                        ArticlePrix.Value = reader.GetDecimal(1);
                        ArticleQuantite.Value = reader.GetInt32(2);
                        ArticleDescription.Text = reader.GetString(3);
                        ArticleLienImage.Text = reader.GetString(4);
                        ArticleImage.Load(ArticleLienImage.Text);
                        ArticleCategorie.SelectedItem = reader.GetString(5);
                    }
                    conn.Close();
                }
                catch (MySqlException ex)
                {
                    Console.WriteLine(ex);
                }
            }
            else
            {
                Supprimer.Visible = false;
                Supprimer.Enabled = false;
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void delete_article()
        {
            if(Supprimer.Enabled == true)
            {
                string article = ArticleModif.getArticle();
                MySqlCommand command = conn.CreateCommand();

                command.Parameters.AddWithValue("@idArt", article);

                command.CommandText = "CALL delete_article(@idArt)";

                try
                {
                    conn.Open();
                    command.ExecuteNonQuery();
                    conn.Close();
                    this.Close();

                }
                catch (InvalidOperationException ex)
                {
                    Console.WriteLine(ex);
                }
            }
        }

        private void ArticleView_FormClosed(object sender, FormClosedEventArgs e)
        {
            string user = client.getClient();
            Boutique Boutique = new Boutique(user);
            Boutique.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string article_name = ArticleName.Text;
            decimal article_price = ArticlePrix.Value;
            decimal article_quantity = ArticleQuantite.Value;
            string article_description = ArticleDescription.Text;
            string article_categorie = get_idCat(ArticleCategorie.Text);
            string article_lien_image = ArticleLienImage.Text;

            if (article_name == null || article_name == "" || article_categorie == null || article_categorie == "" || article_lien_image == null || article_lien_image == "")
            {
                MessageBox.Show("Veuillez remplir tout les champs");

            }
            else
            {
                if (article_exist(ArticleModif.getArticle()))
                {

                    MySqlCommand command = conn.CreateCommand();
                    command.Parameters.AddWithValue("@name", article_name);
                    command.Parameters.AddWithValue("@idArt", ArticleModif.getArticle());
                    command.Parameters.AddWithValue("@price", article_price);
                    command.Parameters.AddWithValue("@quantity", article_quantity);
                    command.Parameters.AddWithValue("@description", article_description);
                    command.Parameters.AddWithValue("@idCat", article_categorie);
                    command.Parameters.AddWithValue("@image", article_lien_image);
                    command.CommandText = "UPDATE article SET nom = @name, description = @description, prix = @price, quantite = @quantity, idCategorie = @idCat, image = @image WHERE idArticle = @idArt";
                    try
                    {
                        conn.Open();
                        command.ExecuteNonQuery();
                        conn.Close();
                        this.Close();

                    }
                    catch (InvalidOperationException ex)
                    {
                        Console.WriteLine(ex);
                    }
                }
                else
                {
                    Session User = new Session();
                    string idMagasin = get_idMagasin(client.getClient());
                    MySqlCommand command = conn.CreateCommand();

                    command.Parameters.AddWithValue("@name", article_name);
                    command.Parameters.AddWithValue("@price", article_price);
                    command.Parameters.AddWithValue("@quantity", article_quantity);
                    command.Parameters.AddWithValue("@description", article_description);
                    command.Parameters.AddWithValue("@idCat", article_categorie);
                    command.Parameters.AddWithValue("@idMagasin", idMagasin);
                    command.Parameters.AddWithValue("@image", article_lien_image);

                    command.CommandText = "INSERT INTO article (idCategorie, idMagasin, nom, description, prix, quantite, image) VALUES (@idcat, @idMagasin, @name, @description, @price, @quantity, @image)";

                    try
                    {
                        conn.Open();
                        command.ExecuteNonQuery();
                        conn.Close();
                        this.Close();

                    }
                    catch (InvalidOperationException ex)
                    {
                        Console.WriteLine(ex);
                    }
                }
            }
        }

        private bool article_exist(string idArt)
        {
            MySqlCommand command = conn.CreateCommand();

            command.Parameters.AddWithValue("@idArt", idArt);
            command.Parameters.AddWithValue("@idC", client.getClient());
            command.CommandText = "SELECT * FROM article INNER JOIN magasin ON article.idMagasin = magasin.idMagasin WHERE article.idArticle = @idArt AND magasin.idProprietaire = @idC;";
            int i = 0;
            try
            {
                conn.Open();
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    i++;
                }
                conn.Close();
                if (i == 0){
                    return false;
                }
                else
                {
                    return true;
                }
                
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine(ex);
                return false;
            }
        }

        private void get_categories()
        {
            MySqlCommand command = conn.CreateCommand();
            command.CommandText = "SELECT nom FROM categorie";
            try
            {
                conn.Open();
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    ArticleCategorie.Items.Add(reader.GetString(0));
                }
                conn.Close();
            }catch (InvalidOperationException ex)
            {
                Console.WriteLine(ex);
            }
        }
        private string get_idCat(string nom)
        {
            MySqlCommand command = conn.CreateCommand();
            command.Parameters.AddWithValue("@nom", nom);
            command.CommandText = "SELECT idCategorie FROM categorie WHERE nom = @nom";
            conn.Open();
            Categorie Categorie = new Categorie();
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                Categorie.setCategorie(reader.GetString(0));
            }
            conn.Close();
            return Categorie.getCategorie();
        }

        private string get_idMagasin(string id_user)
        {
            MySqlCommand command = conn.CreateCommand();
            command.Parameters.AddWithValue("@idUser", id_user);
            command.CommandText = "SELECT idMagasin FROM magasin WHERE idProprietaire = @idUser";
            conn.Open();
            Magasin Magasin = new Magasin();
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                Magasin.setMagasin(reader.GetString(0));
            }
            conn.Close();
            return Magasin.getMagasin();
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            try
            {
                ArticleImage.Load(ArticleLienImage.Text);
            }
            catch
            {
                MessageBox.Show("image non trouvée");
            }
        }

        private void ArticleLienImage_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {
                ArticleName.Focus();
            }
        }

        private void ArticleName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {
                ArticleQuantite.Focus();
            }
        }

        private void ArticleQuantite_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {
                ArticlePrix.Focus();
            }
        }

        private void Supprimer_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Voulez vous vraiment supprimer définitivement cet article ?", "Supprimer article", MessageBoxButtons.YesNo);
            if(result == DialogResult.Yes)
            {
                delete_article();
            }
        }
    }
}
