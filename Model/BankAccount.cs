using Practicheskaya_8.DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practicheskaya_8.Model
{
    internal class BankAccount<T>       //основной класс счёта
    {
        private string id;
        private T account;

        public string Id 
        {
            get => id; 
            set => id = value; 
        }
        public T Account
        {
            get => account;
            set => account = value;
        }

        public BankAccount(T account) => Account = account;
    }


    internal class NeDepositAccount : BankAccount<int>      //класс недопозитного счёта
    {
        public NeDepositAccount(int account) : base(account) { }
    }


    internal class DepositAccount : BankAccount<int>      //класс допозитного счёта
    {
        public DepositAccount(int account) : base(account) { }
    }
}