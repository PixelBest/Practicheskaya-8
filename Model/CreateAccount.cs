using Practicheskaya_8.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Practicheskaya_8.Model
{
    internal class CreateDepositAccount : ICreateAccount<DepositAccount>
    {
        public DepositAccount CreateAccount(int summa)
        {
            return new DepositAccount(summa);
        }
    }


    internal class CreateNeDepositAccount : ICreateAccount<NeDepositAccount>
    {
        public NeDepositAccount CreateAccount(int summa)
        {
            return new NeDepositAccount(summa);
        }
    }
}
