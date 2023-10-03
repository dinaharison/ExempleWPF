
namespace DistributeurBillet.ClientSystem
{
    public class Client
    {
        private string _idClient; 
        private string _nom;
        private string _prenom;
        private string _tel;
        private string _adresse;
        public string Adresse
        {
            get { return _adresse; }
            set { _adresse = value; }
        }
        public string Tel
        {
            get { return _tel; }
            set { _tel = value; }
        }
        public string Prenom
        {
            get { return _prenom; }
            set { _prenom = value; }
        }
        public string Nom
        {
            get { return _nom; }
            set { _nom = value; }
        }
        public string IdClient
        {
            get { return _idClient; }
            set { _idClient = value; }
        }

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public Client(string idClient, string nom, string prenom, string tel, string adresse)
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        {
            Adresse = adresse;
            Tel = tel;
            Prenom = prenom;
            Nom = nom;
            IdClient = idClient;
        }

        public override string ToString()
        {
            return $"ID: {IdClient} nom:{Nom} {Prenom} tel:{Tel} adresse:{Adresse}";
        }

    }
}
