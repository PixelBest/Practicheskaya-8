using Practicheskaya_8.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Channels;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Practicheskaya_8.Model
{
    internal class AccountSendMoney : ISendMoney<BankAccount<int>>
    {
        public void SendMoney(BankAccount<int> accountFrom, BankAccount<int> accountTo, int summa)      //перевод денег
        {
            accountFrom.Account -= summa;
            accountTo.Account += summa;
        }
    }
}