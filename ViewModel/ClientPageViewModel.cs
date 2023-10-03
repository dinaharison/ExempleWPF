using DistributeurBillet.ClientSystem;
using DistributeurBillet.DBConnection;
using ExempleWPF.Command;
using ExempleWPF.Model;
using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;

namespace ExempleWPF.ViewModel
{
    public class ClientPageViewModel : BaseViewModel
    {
        private ObservableCollection<Client> _clients;
        private ICommand _ajouterCommand;
        private Client _selectedClient;
        private int _selectedIndex;
        private string _idClient;
        private string _nom;
        private string _prenom;
        private string _tel;
        private string _adresse;

        private MainWindowViewModel _mainWIndow;
        public MainWindowViewModel MainWIndow { get => _mainWIndow; set => _mainWIndow = value; }
        public ObservableCollection<Client> Clients
        {
            get => _clients;
            set
            {
                _clients = value;
                OnPropertyChanged(nameof(Clients));
            }
        }
        public Client SelectedClient
        {
            get => _selectedClient;
            set
            {
                _selectedClient = value;
                IdClient = _selectedClient.IdClient;
                Nom = _selectedClient.Nom;
                Prenom = _selectedClient.Prenom;
                Tel = _selectedClient.Tel;
                Adresse = _selectedClient.Adresse;
                OnPropertyChanged(nameof(SelectedClient));
            }
        }
        public int SelectedIndex
        {
            get => _selectedIndex;
            set
            {
                _selectedIndex = value;
                OnPropertyChanged(nameof(SelectedIndex));
            }
        }
        public string IdClient
        {
            get => _idClient;
            set
            {
                _idClient = value;
                OnPropertyChanged(nameof(IdClient));
            }
        }
        public string Nom
        {
            get => _nom;
            set
            {
                _nom = value;
                OnPropertyChanged(nameof(Nom));
            }

        }
        public string Prenom
        {
            get => _prenom;
            set
            {
                _prenom = value;
                OnPropertyChanged(nameof(Prenom));
            }
        }
        public string Tel
        {
            get => _tel;
            set
            {
                _tel = value;
                OnPropertyChanged(nameof(Tel));
            }
        }
        public string Adresse
        {
            get => _adresse;
            set
            {
                _adresse = value;
                OnPropertyChanged(nameof(Adresse));
            }
        }
        public ICommand AjouterCommand
        {
            get => _ajouterCommand;
            set => _ajouterCommand = value;
        }


        public ClientPageViewModel()
        {
            Clients = ClientManager.GetClients();
            MainWIndow = (MainWindowViewModel) Application.Current.MainWindow.DataContext;
            AjouterCommand = new RelayCommand(ExecuterAjouterCommand, CanExecuteAjouterCommand);
        }
        private bool CanExecuteAjouterCommand(object arg)
        {
            return true;
        }

        private void ExecuterAjouterCommand(object obj)
        {
            //DBConnectionClass.InsertionClient(new Client(IdClient, Nom, Prenom,Tel,Adresse));
            _mainWIndow.SelectedView = new ComptePageViewModel();
            
        }

    }
}
