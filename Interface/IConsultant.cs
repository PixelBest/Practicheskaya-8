using Practicheskaya_8.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practicheskaya_8.Interface
{
    internal interface IConsultant
    {
        Bank Bank { get; set; }
        string GetClientData(int index);
        void ChangePhone(int index, string newPhone);
    }
}
