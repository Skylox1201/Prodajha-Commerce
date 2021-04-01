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
            //si on modifie un articel déjà présent
            if (article != null && article != "")
            {
                ArticleModif.setArticle(article); //on enregistre l'id de l'article de sorte à l'utiliser plus tard
                MySqlCommand cmd = conn.CreateCommand();
                //affichage du bouton supprimer
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
                        //On place les éléments de la page dans les inputs
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
            else //Si on veut créer un nouvel article
            {
                //On fait disparaitre le bouton supprimer
                Supprimer.Visible = false;
                Supprimer.Enabled = false;
            }
        }

        //retour a la page boutique
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //supprimer l'article modifié
        private void delete_article()
        {
            if(Supprimer.Enabled == true)
            {
                string article = ArticleModif.getArticle(); //on récupère l'id de l'article que l'on modifie
                MySqlCommand command = conn.CreateCommand(); //innitialisation de la commande

                command.Parameters.AddWithValue("@idArt", article); //ajout du paramêtre idArticle

                command.CommandText = "CALL delete_article(@idArt)";//Requête sql

                try
                {
                    conn.Open();
                    //on supprime l'article de la base de donnée
                    command.ExecuteNonQuery();
                    conn.Close();
                    //retour à la fenêtre boutique
                    this.Close();

                }
                catch (InvalidOperationException ex)
                {
                    Console.WriteLine(ex);
                }
            }
        }

        //Lorsque la fenêtre est fermée, retourn à la fenêtre boutique
        private void ArticleView_FormClosed(object sender, FormClosedEventArgs e)
        {
            string user = client.getClient();
            Boutique Boutique = new Boutique(user);
            Boutique.Show();
        }

        //Enregistrement des donnée rentrée
        private void button1_Click(object sender, EventArgs e)
        {
            //on récupère les informations entrées
            string article_name = ArticleName.Text;
            decimal article_price = ArticlePrix.Value;
            decimal article_quantity = ArticleQuantite.Value;
            string article_description = ArticleDescription.Text;
            string article_categorie = get_idCat(ArticleCategorie.Text); //On récupère l'id de la catégorie sélectionnée
            string article_lien_image = ArticleLienImage.Text;
            if (article_name == null || article_name == "" || article_categorie == null || article_categorie == "" || article_lien_image == null || article_lien_image == "") //si des champs sont vides
            {
                MessageBox.Show("Veuillez remplir tout les champs");

            }
            else
            {
                if (article_exist(ArticleModif.getArticle())) //si on modifie un article existant
                {

                    MySqlCommand command = conn.CreateCommand(); //initialisation de la commande
                    //ajout des paramètres
                    command.Parameters.AddWithValue("@name", article_name);
                    command.Parameters.AddWithValue("@idArt", ArticleModif.getArticle());
                    command.Parameters.AddWithValue("@price", article_price);
                    command.Parameters.AddWithValue("@quantity", article_quantity);
                    command.Parameters.AddWithValue("@description", article_description);
                    command.Parameters.AddWithValue("@idCat", article_categorie);
                    command.Parameters.AddWithValue("@image", article_lien_image);
                    //requête sql
                    command.CommandText = "UPDATE article SET nom = @name, description = @description, prix = @price, quantite = @quantity, idCategorie = @idCat, image = @image WHERE idArticle = @idArt";
                    try
                    {
                        
                        conn.Open();
                        command.ExecuteNonQuery(); //Mise à jour de l'article modifié dans la base de données
                        conn.Close();
                        this.Close(); //retour à la fenêtre boutique

                    }
                    catch (InvalidOperationException ex)
                    {
                        Console.WriteLine(ex);
                    }
                }
                else //Si on créé un nouvel article
                {
                    Session User = new Session();
                    string idMagasin = get_idMagasin(client.getClient()); //On récupère l'id du magasin grâce à l'id de l'utilisateur
                    MySqlCommand command = conn.CreateCommand(); //initialisation de la commande

                    //Ajout des paramêtres
                    command.Parameters.AddWithValue("@name", article_name);
                    command.Parameters.AddWithValue("@price", article_price);
                    command.Parameters.AddWithValue("@quantity", article_quantity);
                    command.Parameters.AddWithValue("@description", article_description);
                    command.Parameters.AddWithValue("@idCat", article_categorie);
                    command.Parameters.AddWithValue("@idMagasin", idMagasin);
                    command.Parameters.AddWithValue("@image", article_lien_image);

                    //Requête sql
                    command.CommandText = "INSERT INTO article (idCategorie, idMagasin, nom, description, prix, quantite, image) VALUES (@idcat, @idMagasin, @name, @description, @price, @quantity, @image)";

                    try
                    {
                        conn.Open();
                        command.ExecuteNonQuery(); //Création de l'article dans la base de données
                        conn.Close();
                        this.Close(); //retour à la fenêtre boutique

                    }
                    catch (InvalidOperationException ex)
                    {
                        Console.WriteLine(ex);
                    }
                }
            }
        }

        //Vérifie si l'article modifié existe
        private bool article_exist(string idArt)
        {
            MySqlCommand command = conn.CreateCommand(); //initialisation de la requête

            //Ajout des paramêtres
            command.Parameters.AddWithValue("@idArt", idArt);
            command.Parameters.AddWithValue("@idC", client.getClient());
            //requête sql
            command.CommandText = "SELECT * FROM article INNER JOIN magasin ON article.idMagasin = magasin.idMagasin WHERE article.idArticle = @idArt AND magasin.idProprietaire = @idC;";
            int i = 0;
            try
            {
                conn.Open();
                MySqlDataReader reader = command.ExecuteReader(); //Lancement de la requête select
                while (reader.Read()) //On vérifie si on a trouvé un article
                {
                    i++;
                }
                conn.Close();
                if (i == 0){ //Si on a trouvé aucun article
                    return false;
                }
                else//Si on a trouvé un article
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

        //récupère tous les noms de catégorie
        private void get_categories()
        {
            MySqlCommand command = conn.CreateCommand(); //initialisation de la requête
            command.CommandText = "SELECT nom FROM categorie"; //requête sql
            try
            {
                conn.Open();
                MySqlDataReader reader = command.ExecuteReader(); //lecture de la requête
                while (reader.Read())
                {
                    ArticleCategorie.Items.Add(reader.GetString(0)); //Ajout au select de la catégorie trouvée
                }
                conn.Close();
            }catch (InvalidOperationException ex)
            {
                Console.WriteLine(ex);
            }
        }

        //récupère l'id de la catégorie selon le nom de la catégorie insérée
        private string get_idCat(string nom)
        {
            MySqlCommand command = conn.CreateCommand(); //initialisation de la requête
            command.Parameters.AddWithValue("@nom", nom); //On ajoute le paramêtre
            command.CommandText = "SELECT idCategorie FROM categorie WHERE nom = @nom"; //requête sql
            conn.Open();
            Categorie Categorie = new Categorie(); //Permet d'enregistrer la catégorie sélectionnée
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                Categorie.setCategorie(reader.GetString(0)); //récupère ce que la requête à trouvé
            }
            conn.Close();
            return Categorie.getCategorie(); //retourne l'id de la catégorie en string
        }

        //récupère l'id du magasin selon l'id de l'utilisateur
        private string get_idMagasin(string id_user)
        {
            MySqlCommand command = conn.CreateCommand(); //initialisation de la commande
            command.Parameters.AddWithValue("@idUser", id_user); //Ajout du paramêtre
            command.CommandText = "SELECT idMagasin FROM magasin WHERE idProprietaire = @idUser"; //Requête sql
            conn.Open();
            Magasin Magasin = new Magasin(); //Permet d'enregistré l'id du magasin
            MySqlDataReader reader = command.ExecuteReader(); //execute le lecteur
            while (reader.Read())
            {
                Magasin.setMagasin(reader.GetString(0));//enregistre l'id du magasin
            }
            conn.Close();
            return Magasin.getMagasin();//retourne l'id du magasin
        }

        //lorsque l'on quitte l'input du lien de l'image, recharge l'image à partir du nouvel url
        private void textBox1_Leave(object sender, EventArgs e)
        {
            try
            {
                ArticleImage.Load(ArticleLienImage.Text); //Recharge l'image
            }
            catch
            {
                MessageBox.Show("image non trouvée"); //Message d'erreur
            }
        }

        //Lorsque l'on appui sur la touche entrée, quitte l'input
        private void ArticleLienImage_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {
                ArticleName.Focus();
            }
        }

        //Lorsque l'on appui sur la touche entrée, quitte l'input
        private void ArticleName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {
                ArticleQuantite.Focus();
            }
        }

        //Lorsque l'on appui sur la touche entrée, quitte l'input
        private void ArticleQuantite_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {
                ArticlePrix.Focus();
            }
        }

        //Lorsque l'on quitte sur le bouton supprimer
        private void Supprimer_Click(object sender, EventArgs e)
        {
            //demande si l'on veut reelement supprimer l'articke
            var result = MessageBox.Show("Voulez vous vraiment supprimer définitivement cet article ?", "Supprimer article", MessageBoxButtons.YesNo);
            if(result == DialogResult.Yes)//si l'on clique sur oui
            {
                delete_article(); //supprime l'article
            }
        }
    }
}
