using Practicheskaya_8.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace Practicheskaya_8.Model
{
    internal class Consultant : IConsultant     //класс консультанта
    {
        public delegate void Notice(string message);
        public event Notice Notify;

        public Bank Bank { get; set; }

        public Consultant(Bank bank)
        {
            Bank = bank;
        }

        public virtual string GetClientData(int index) //консултант получает все данные
        {
            string data = $"Имя клиента {Bank.listClients[index].Name}, фамилия {Bank.listClients[index].Surname}, отчество {Bank.listClients[index].Otchestvo}, телефон {Bank.listClients[index].Phone}, серия номер паспорта ******************";
            return data;
        }

        public virtual void ChangePhone(int id, string newPhone)       //консультант меняет телефон
        {
            Bank.listClients[id].Phone = newPhone;
            Bank.listClients[id].DateTimeChange = DateTime.Now.ToString();
            Bank.listClients[id].WhatDataChanged = "Телефон";
            Bank.listClients[id].WhoChanged = "Консультантом";
            Bank.bankEntities.SaveChanges();
            Notify.Invoke($"Консультантом изменён телефон у клинета с id {id + 1}");
        }

    }
}
