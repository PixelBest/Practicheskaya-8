using Practicheskaya_8.DataBase;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practicheskaya_8.Model
{
    public class Bank
    {
        private string name;
        public ObservableCollection<BankTable> listClients;
        public ObservableCollection<AccountTable> accounts;
        public BankEntities bankEntities = new BankEntities();
        public AccountEntities accountEntities = new AccountEntities();

        public string Name 
        {
            get => name;
            set => name = value;
        }

        public Bank(string name)
        {
            Name = name;
            listClients = new ObservableCollection<BankTable>(bankEntities.BankTable);
            accounts = new ObservableCollection<AccountTable>(accountEntities.AccountTable);
        }
    }
}
