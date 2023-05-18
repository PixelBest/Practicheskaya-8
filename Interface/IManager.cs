using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practicheskaya_8.Interface
{
    internal interface IManager         //интерфейс менеджера
    {
        string GetClientData(int index);
        void ChangePhone(int id, string newPhone);
        void ChangeName(int index, string name);
        void ChangeSurname(int index, string surname);
        void ChangeOtchestvo(int index, string otchestvo);
        void ChangePasport(int index, string pasport);
        void AddCLient(string name, string surname, string otchestvo, string phone, string pasport);
    }
}
