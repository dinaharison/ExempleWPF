using DistributeurBillet.ClientSystem;
using DistributeurBillet.DBConnection;
using System.Collections.ObjectModel;

namespace ExempleWPF.Model
{
    public class ClientManager
    {
        private static ObservableCollection<Client> _clients = 
            new ObservableCollection<Client>(DBConnectionClass.RecupererClients());

        public static ObservableCollection<Client> GetClients()
        {
            return _clients;
        }

        public static void AddClient(Client client)
        {
            _clients.Add(client);
        }
    }
}
