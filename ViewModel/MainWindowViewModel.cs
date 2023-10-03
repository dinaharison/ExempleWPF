using ExempleWPF.Command;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ExempleWPF.ViewModel
{
    public class MainWindowViewModel : BaseViewModel
    {
        private BaseViewModel _selectedView;
        private ICommand _pageClientCommand;
        private ICommand _pageCompteCommand;
        public ICommand PageCompteCommand
        {
            get { return _pageCompteCommand; }
            set { _pageCompteCommand = value; }
        }
        public ICommand PageClientCommand
        {
            get { return _pageClientCommand; }
            set { _pageClientCommand = value; }
        }

        public BaseViewModel SelectedView
        {
            get => _selectedView;
            set
            {
                _selectedView = value;
                OnPropertyChanged(nameof(SelectedView));
            }
        }
        public MainWindowViewModel()
        {
            PageClientCommand = new RelayCommand(ExecutePageClientCommand, CanExecutePageClientCommand);
            PageCompteCommand = new RelayCommand(ExecutePageCompteCommand, CanExecutePageCompteCommand);
        }

        private bool CanExecutePageCompteCommand(object arg)
        {
            return true;
        }

        private void ExecutePageCompteCommand(object obj)
        {
            SelectedView = new ComptePageViewModel();
        }

        private bool CanExecutePageClientCommand(object arg)
        {
            return true;
        }

        public void ExecutePageClientCommand(object obj)
        {
            SelectedView = new ClientPageViewModel() ;
        }
    }
}
