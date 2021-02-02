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

        public Boutique()
        {
            InitializeComponent();
        }
        
        public void Article()
        {
            MySqlCommand command = conn.CreateCommand();
            Connection connection = new Connection();
            command.Parameters.AddWithValue("@client", connection.session.client);
            command.CommandText = "SELECT * FROM article INNER JOIN magasin ON magasin.idMagasin = article.idMagasin WHERE magasin.idProprietaire = @client";
                try
                {
                conn.Open();
                MySqlDataReader reader = command.ExecuteReader();
                foreach (int i in reader)
                {
                    string valeur = reader.GetString(0);

                    conn.Close();
                }
            }
            catch
            {
                MessageBox.Show("Connexion echouée");
            }
        }
    }
}
