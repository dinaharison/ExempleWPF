using DistributeurBillet.ClientSystem;
using ExempleWPF.Model;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DistributeurBillet.DBConnection
{
    public static class DBConnectionClass
    {
        private static readonly NpgsqlConnection connection = new(
                "Server=localhost;" +
                "User id=postgres;" +
                "Password=admin;" +
                "Database=Bank;");

        public static void InsertionClient(Client client)
        {
            try
            {
                connection.Open();
                var sql = $"INSERT INTO client(idclient, nom, prenom, tel, adresse)" +
                    $"VALUES('{client.IdClient}'," +
                    $"'{client.Nom}','{client.Prenom}', " +
                    $"'{client.Tel}', '{client.Adresse}')";

                var cmd = new NpgsqlCommand(sql, connection);
                cmd.ExecuteNonQuery();
                connection.Close();
            }
            catch (NpgsqlException ex)
            {
                /*25505 fait référence à une erreur
                 en tentant d'inserer une clé dont la valeur
                existe déja dans la BD*/
                if ("23505".Equals(ex.SqlState))
                {
                    Console.WriteLine("Le client existe déja");
                }
            }
        }
        public static List<Client> RecupererClients()
        {
            connection.Open();
            var sql = "SELECT * FROM client";
            var cmd = new NpgsqlCommand(sql, connection);
            var dataReader = cmd.ExecuteReader();
            List<Client> clients = new();
            while (dataReader.Read())
            {
                clients.Add(new Client(
                    dataReader.GetString(0),
                    dataReader.GetString(1),
                    dataReader.GetString(2),
                    dataReader.GetString(3),
                    dataReader.GetString(4)));
            }
            connection.Close();
            return clients;
        }
        public static void InsertCompte(Compte compte, TypeCompte type)
        {
            InsererCompte(compte);
            switch (type)
            {
                case TypeCompte.EPARGNE: { InsererCompteEpargne((CompteEpargne)compte); break; }
                case TypeCompte.COURANT: { InsererCompteCourant((CompteCourant)compte); break; };
                case TypeCompte.PREMIUM: { InsererComptePremium((ComptePremium)compte); break; };
            }
        }

        public static void InsererCompteEpargne(CompteEpargne compteEpargne)
        {
            var sql = $"INSERT INTO compteeparnge(idepargne,comptenumcompte,solde,taux) VALUES" +
                $"('{compteEpargne.IdEpargne}','{compteEpargne.NumCompte}', " +
                $"'{compteEpargne.Solde}', '{compteEpargne.Taux}')";
            connection.Open();
            var cmd = new NpgsqlCommand(sql, connection);
            cmd.ExecuteNonQuery();
            connection.Close();
        }
        private static void InsererCompte(Compte compte)
        {
            var sql = $"INSERT INTO compte(numcompte,clientidclient) VALUES" +
                $"('{compte.NumCompte}','{compte.Client.IdClient}')";
            connection.Open();
            var cmd = new NpgsqlCommand(sql, connection);
            cmd.ExecuteNonQuery();
            connection.Close();
        }
        public static void InsererCompteCourant(CompteCourant compteCourant)
        {
            var sql = $"INSERT INTO comptecourant(idcourant,comptenumcompte,solde,taux)" +
                $"VALUES('{compteCourant.IdCourant}', '{compteCourant.NumCompte}'," +
                $"'{compteCourant.Solde}','{compteCourant.Taux}')";
            connection.Open();
            var cmd = new NpgsqlCommand(sql, connection);
            cmd.ExecuteNonQuery();
            connection.Close();
        }
        public static void InsererComptePremium(ComptePremium comptePremium)
        {
            var sql = $"INSERT INTO comptepremium(idpremium,comptenumcompte,solde,taux)" +
                $"VALUES('{comptePremium.IdPremium}', '{comptePremium.NumCompte}'," +
                $"'{comptePremium.Solde}','{comptePremium.Taux}')";
            connection.Open();
            var cmd = new NpgsqlCommand(sql, connection);
            cmd.ExecuteNonQuery();
            connection.Close();
        }
        public static List<CompteEpargne> RecupererCompteEpargne()
        {
            List<CompteEpargne> comptes = new();
            var sql = "SELECT compte.numcompte, compte.clientidclient, " +
                " client.nom, client.prenom, client.tel, client.adresse," +
                " compteepargne.idepargne, solde, taux " +
                " FROM compte " +
                " INNER JOIN compteepargne " +
                " ON compte.numcompte = compteepargne.comptenumcompte " +
                " INNER JOIN client" +
                " ON client.idclient = compte.clientidclient";
            connection.Open();
            var cmd = new NpgsqlCommand(sql, connection);
            var dataReader = cmd.ExecuteReader();
            while (dataReader.Read())
            {
                comptes.Add(new CompteEpargne(dataReader.GetString(6),dataReader.GetString(0),
                    new Client(dataReader.GetString(1),dataReader.GetString(2),
                    dataReader.GetString(3),dataReader.GetString(4),dataReader.GetString(5)),
                    dataReader.GetDouble(7),dataReader.GetDouble(8)
                    ));
            }
            connection.Close();
            return comptes;
        }
    }
    public enum TypeCompte
    {
        EPARGNE, PREMIUM, COURANT
    }
}
