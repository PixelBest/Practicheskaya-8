using Practicheskaya_8.DataBase;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practicheskaya_8.Model
{
    public class Bank     //класс банка
    {
        private string name;
        public ObservableCollection<BankTable> listClients;     //главная коллекция клиентов 
        public ObservableCollection<AccountTable> accounts;     //главная коллекция счетов клиентов
        public BankEntities bankEntities = new BankEntities();      //связь с таблицей клиента в бд
        public AccountEntities accountEntities = new AccountEntities();      //связь с таблицей счета клиента в бд

        public string Name 
        {
            get => name;
            set => name = value;
        }

        public Bank(string name)
        {
            Name = name;
            listClients = new ObservableCollection<BankTable>(bankEntities.BankTable);      //запись всех данных в список из бд
            accounts = new ObservableCollection<AccountTable>(accountEntities.AccountTable);
        }
    }
}
