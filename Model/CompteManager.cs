using DistributeurBillet.DBConnection;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExempleWPF.Model
{
   public class CompteManager
    {
        private static ObservableCollection<CompteEpargne> _comptes =
            new ObservableCollection<CompteEpargne>(DBConnectionClass.RecupererCompteEpargne());
        public static ObservableCollection<CompteEpargne> GetCompteEpargne()
        {
            return _comptes;
        }
        public static void AddCompteEpargne(CompteEpargne compte)
        {
            _comptes.Add(compte);
        }
    }
}
