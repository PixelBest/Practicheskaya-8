using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practicheskaya_8.Interface
{
    interface ISendMoney<in T>      //интерфейс перевода денег
    {
        void SendMoney(T accountFrom, T accountTo, int summa);
    }
}
