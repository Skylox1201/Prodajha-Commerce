using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prodajha_Commerce
{
    class Session
    {
        private string idClient;

        public void setClient(string user)
        {
            this.idClient = user;
        }
        public string getClient()
        {
            return this.idClient;
        }
    }

    class Article
    {
        private string idArticle;
        
        // set and get idart methods
        public void setArticle(string idart)
        {
            this.idArticle = idart;
        }
        public string getArticle()
        {
            return this.idArticle;
        }
    }

    class Categorie
    {
        private string idCat;

        // set and get idCat methods
        public void setCategorie(string idcat)
        {
            this.idCat = idcat;
        }
        public string getCategorie()
        {
            return this.idCat;
        }
    }

    class Magasin
    {
        private string idMagasin;
        private string magasin_name;
        private string adresse1;
        private string adresse2;
        private string city;
        private string region;
        private string code_postal;
        private string phone;


        // set and get idMagasin methods
        public void setMagasin(string idMagasin)
        {
            this.idMagasin = idMagasin;
        }
        public string getMagasin()
        {
            return this.idMagasin;
        }


        // set and get magasin_name methods
        public void setNom(string name)
        {
            this.magasin_name = name;
        }
        public string getNom()
        {
            return this.magasin_name;
        }


        // set and get adresse1 methods
        public void setAdresse1(string adresse1)
        {
            this.adresse1 = adresse1;
        }
        public string getAdresse1()
        {
            return this.adresse1;
        }


        // set and get adresse2 methods
        public void setAdresse2(string adresse2)
        {
            this.adresse2 = adresse2;
        }
        public string getAdresse2()
        {
            return this.adresse2;
        }


        // set and get city methods
        public void setCity(string city)
        {
            this.city = city;
        }
        public string getCity()
        {
            return this.city;
        }


        // set and get region methods
        public void setRegion(string region)
        {
            this.region = region;
        }
        public string getRegion()
        {
            return this.region;
        }


        // set and get code_postal methods
        public void set_code_postal(string code_postal)
        {
            this.code_postal = code_postal;
        }
        public string get_code_postal()
        {
            return this.code_postal;
        }


        // set and get magasin_name methods
        public void setPhone(string phone)
        {
            this.phone = phone;
        }
        public string getPhone()
        {
            return this.phone;
        }
    }
}
