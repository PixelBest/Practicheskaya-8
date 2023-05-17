using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practicheskaya_8.Interface
{
    internal interface ICreateAccount<out T>
    {
        T CreateAccount(int summa);
    }
}
