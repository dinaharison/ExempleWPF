using ExempleWPF.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ExempleWPF.ViewModel
{
    public class ComptePageViewModel : BaseViewModel
    {
        private ObservableCollection<CompteEpargne> _comptesEpargne;
        private MainWindowViewModel _mainWIndow;
        public MainWindowViewModel MainWIndow { get => _mainWIndow; set => _mainWIndow = value; }
        public ObservableCollection<CompteEpargne> ComptesEparnge
        {
            get => _comptesEpargne ; 
            set
            {
                _comptesEpargne = value;
                OnPropertyChanged(nameof(ComptesEparnge));
            }
        }

        public ComptePageViewModel()
        {
            _comptesEpargne = CompteManager.GetCompteEpargne();
        }
    }
}
