using DistributeurBillet.ClientSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExempleWPF.Model
{
    public class Compte
    {
        private string _numCompte;
        private Client _client;
        private double _solde;
        private double _taux;

        public string NumCompte { get => _numCompte; set => _numCompte = value; }
        public Client Client { get => _client; set => _client = value; }
        public double Solde { get => _solde; set => _solde = value; }
        public double Taux { get => _taux; set => _taux = value; }
        public Compte(string numCompte, Client client, double solde, double taux)
        {
            _numCompte = numCompte;
            _client = client;
            _solde = solde;
            _taux = taux;
        }
        public override bool Equals(object? obj)
        {
            return obj is Compte compte &&
                   NumCompte == compte.NumCompte &&
                   EqualityComparer<Client>.Default.Equals(Client, compte.Client) &&
                   Solde == compte.Solde &&
                   Taux == compte.Taux;
        }
        public override int GetHashCode()
        {
            return HashCode.Combine(NumCompte, Client, Solde, Taux);
        }
    }

    public class CompteCourant : Compte
    {
        private string _idCourant;
        public string IdCourant { get => _idCourant; set => _idCourant = value; }
        public CompteCourant(string idCourant,string numCompte, Client client, double solde, double taux) : base(numCompte, client, solde, taux)
        {
            _idCourant = idCourant;
        }
    }

    public class CompteEpargne : Compte
    {
        private string _idEpargne;
        public string IdEpargne { get => _idEpargne; set => _idEpargne = value; }
        public CompteEpargne(string idEpargne,string numCompte, Client client, double solde, double taux) : base(numCompte, client, solde, taux)
        {
            _idEpargne = idEpargne;
        }
    }

    public class ComptePremium : Compte
    {
        private string _idPremium;
        public ComptePremium(string idPremium,string numCompte, Client client, double solde, double taux) : base(numCompte, client, solde, taux)
        {
            _idPremium = idPremium;
        }
        public string IdPremium { get => _idPremium; set => _idPremium = value;}
    }
}
