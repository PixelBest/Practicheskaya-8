using Practicheskaya_8.DataBase;
using Practicheskaya_8.Interface;
using Practicheskaya_8.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Practicheskaya_8.Model
{
    internal class Manager : Consultant, IManager     //класс менеджера
    {
        public delegate void Notice1(string message);
        public event Notice1 Notify1;
        public Manager(Bank bank) : base(bank) { }

        public override string GetClientData(int index)     //менеджер получает все данные
        {
            string data = $"Имя клиента {Bank.listClients[index].Name}, фамилия {Bank.listClients[index].Surname}, отчество {Bank.listClients[index].Otchestvo}, телефон {Bank.listClients[index].Phone}, серия номер паспорта {Bank.listClients[index].Pasport}";
            return data;
        }

        public override void ChangePhone(int id, string newPhone)    //менеджер меняет телефон
        {
            Bank.listClients[id].Phone = newPhone;
            Bank.listClients[id].DateTimeChange = DateTime.Now.ToString();
            Bank.listClients[id].WhatDataChanged = "Телефон";
            Bank.listClients[id].WhoChanged = "Менеджером";
            Bank.bankEntities.SaveChanges();
            Notify1.Invoke($"Менеджером изменён телефон у клинета с id {id + 1}");
        }
        public void ChangeName(int index, string name)    //менеджер меняет имя
        {
            Bank.listClients[index].Name = name;
            Bank.listClients[index].DateTimeChange = DateTime.Now.ToString();
            Bank.listClients[index].WhatDataChanged = "Имя";
            Bank.listClients[index].WhoChanged = "Менеджером";
            Bank.bankEntities.SaveChanges();
            Notify1.Invoke($"Менеджером изменено имя у клинета с id {index + 1}");
        }
        public void ChangeSurname(int index, string surname)    //менеджер меняет фамилию
        {
            Bank.listClients[index].Surname = surname;
            Bank.listClients[index].DateTimeChange = DateTime.Now.ToString();
            Bank.listClients[index].WhatDataChanged = "Фамилия";
            Bank.listClients[index].WhoChanged = "Менеджером";
            Bank.bankEntities.SaveChanges();
            Notify1.Invoke($"Менеджером изменена фамилия у клинета с id {index + 1}");
        }
        public void ChangeOtchestvo(int index, string otchestvo)    //менеджер меняет отчество
        {
            Bank.listClients[index].Otchestvo = otchestvo;
            Bank.listClients[index].DateTimeChange = DateTime.Now.ToString();
            Bank.listClients[index].WhatDataChanged = "Отчество";
            Bank.listClients[index].WhoChanged = "Менеджером";
            Bank.bankEntities.SaveChanges();
            Notify1.Invoke($"Менеджером изменено отчество у клинета с id {index + 1}");
        }
        public void ChangePasport(int index, string pasport)    //менеджер меняет паспорт
        {
            Bank.listClients[index].Pasport = pasport;
            Bank.listClients[index].DateTimeChange = DateTime.Now.ToString();
            Bank.listClients[index].WhatDataChanged = "Паспорт";
            Bank.listClients[index].WhoChanged = "Менеджером";
            Bank.bankEntities.SaveChanges();
            Notify1.Invoke($"Менеджером изменён паспорт у клинета с id {index + 1}");
        }
        public void AddCLient(string name, string surname, string otchestvo, string phone, string pasport)    //менеджер добавляет клиента
        {
            Bank.listClients.Add(new DataBase.BankTable(name, surname, otchestvo, phone, pasport) { Id = (MainWindow.bankEntities.BankTable.Count() + 1).ToString()});
            Bank.bankEntities.BankTable.Add(new BankTable(name, surname, otchestvo, phone, pasport) { Id = (MainWindow.bankEntities.BankTable.Count() + 1).ToString() });
            Bank.bankEntities.SaveChanges();
            Bank.accounts.Add(new AccountTable() { Id = (MainWindow.bankEntities.BankTable.Count()).ToString() });
            Bank.accountEntities.AccountTable.Add(new AccountTable() { Id = (MainWindow.bankEntities.BankTable.Count()).ToString() });
            Bank.accountEntities.SaveChanges();
            Notify1.Invoke($"Менеджером добавлен клиент");
        }
    }
}
