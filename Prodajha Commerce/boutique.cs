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

            command.CommandText = "SELECT email, password, idClient FROM client WHERE email = @email;";
            try
            {
                conn.Open();
                MySqlDataReader reader = command.ExecuteReader();

                command.Parameters.AddWithValue("@boutique", idBoutique);
                command.CommandText = "SELECT email, password, idClient FROM client WHERE email = @boutique;";
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

        private void Profil_Click(object sender, EventArgs e)
        {

        }
    }
}
