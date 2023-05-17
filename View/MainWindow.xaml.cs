using Practicheskaya_8.DataBase;
using Practicheskaya_8.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Practicheskaya_8.Interface;

namespace Practicheskaya_8.View
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Bank bank;
        Manager manager;
        Consultant consultant;
        public static BankEntities bankEntities = new BankEntities();
        public delegate void Notice(string message);
        public event Notice Notify;

        public MainWindow()
        {
            InitializeComponent();
            LoadData();
        }
        public void LoadData()
        {
            bank = new Bank("Сбербунк");
            consultant = new Consultant(bank);
            manager = new Manager(bank);
            listView2.ItemsSource = bank.listClients;
            listView1.ItemsSource = bank.listClients;
            listView3.ItemsSource = bank.accounts;
            consultant.Notify += Message;
            manager.Notify1 += Message;
            Notify += Message;
        }

        private void btnConsultantUpdatePhone(object sender, RoutedEventArgs e)
            => consultant.ChangePhone(int.Parse(textBoxIdConsultantPhone.Text) - 1, textBoxNewConsultantPhone.Text);

        private void btnManagerUpdatePhone(object sender, RoutedEventArgs e)
        => manager.ChangePhone(int.Parse(textBoxIdManagerPhone.Text) - 1, textBoxNewManagerPhone.Text);

        private void btnManagerUpdateName(object sender, RoutedEventArgs e)
        => manager.ChangeName(int.Parse(textBoxIdManagerName.Text) - 1, textBoxNewManagerName.Text);

        private void btnManagerUpdateSurname(object sender, RoutedEventArgs e)
        => manager.ChangeSurname(int.Parse(textBoxIdManagerSurname.Text) - 1, textBoxNewManagerSurmane.Text);

        private void btnManagerUpdateOtchestvo(object sender, RoutedEventArgs e)
        => manager.ChangeOtchestvo(int.Parse(textBoxIdManagerOtchestvo.Text) - 1, textBoxNewManagerOtchestvo.Text);

        private void btnManagerUpdatePasport(object sender, RoutedEventArgs e)
        => manager.ChangePasport(int.Parse(textBoxIdManagerPasport.Text) - 1, textBoxNewManagerPasport.Text);

        private void btnManagerAddClient(object sender, RoutedEventArgs e)
        => manager.AddCLient(textBoxAddClientManagerName.Text, textBoxAddClientManagerSurname.Text, textBoxAddClientManagerOtchestvo.Text, textBoxAddClientManagerPhone.Text, textBoxAddClientManagerPasport.Text);

        private void btnOpenAccount(object sender, RoutedEventArgs e)
        {
            if(checkBoxDepositOpenAccount.IsChecked == true)
            {
                ICreateAccount<BankAccount<int>> account = new CreateDepositAccount();
                BankAccount<int> bankAccount = account.CreateAccount(0);
                bank.accounts[int.Parse(textBoxIdOpenAccount.Text) - 1].Deposit = bankAccount.Account.ToString();
                bank.accountEntities.SaveChanges();
                Notify.Invoke($"Открыт депозитный счёт у клиента с id {textBoxIdOpenAccount.Text}");
            }
            else if(checkBoxNedepositOpenAccount.IsChecked == true)
            {
                ICreateAccount<BankAccount<int>> account = new CreateNeDepositAccount();
                BankAccount<int> bankAccount = account.CreateAccount(0);
                bank.accounts[int.Parse(textBoxIdOpenAccount.Text) - 1].Nedeposit = bankAccount.Account.ToString();
                bank.accountEntities.SaveChanges();
                Notify.Invoke($"Открыт недепозитный счёт у клиента с id {textBoxIdOpenAccount.Text}");
            }
        }

        private void btnAddMoney(object sender, RoutedEventArgs e)
        {
            if (checkBoxDepositAddMoney.IsChecked == true)
            {
                int a = int.Parse(bank.accounts[int.Parse(textBoxIdAddMoney.Text) - 1].Deposit);
                bank.accounts[int.Parse(textBoxIdAddMoney.Text) - 1].Deposit = (a + int.Parse(textBoxSummaAddMoney.Text)).ToString();
                bank.accountEntities.SaveChanges();
                Notify.Invoke($"Пополнение депозитного счёта  {textBoxSummaAddMoney.Text}");
            }
            else if (checkBoxNedepositAddMoney.IsChecked == true)
            {
                int a = int.Parse(bank.accounts[int.Parse(textBoxIdAddMoney.Text) - 1].Nedeposit);
                bank.accounts[int.Parse(textBoxIdAddMoney.Text) - 1].Nedeposit = (a + int.Parse(textBoxSummaAddMoney.Text)).ToString();
                bank.accountEntities.SaveChanges();
                Notify.Invoke($"Пополнение недепозитного счёта {textBoxSummaAddMoney.Text}");
            }
        }

        private void btnCloseAccount(object sender, RoutedEventArgs e)
        {
            if (checkBoxDepositCloseAccount.IsChecked == true)
            {
                bank.accounts[int.Parse(textBoxIdCloseAccount.Text) - 1].Deposit = null;
                bank.accountEntities.SaveChanges();
                Notify.Invoke($"Закрытие депозитного счёта у клиента с id {textBoxIdOpenAccount.Text}");
            }
            else if (checkBoxNedepositCloseAccount.IsChecked == true)
            {
                bank.accounts[int.Parse(textBoxIdCloseAccount.Text) - 1].Nedeposit = null;
                bank.accountEntities.SaveChanges();
                Notify.Invoke($"Закрытие недепозитного счёта у клиента с id {textBoxIdOpenAccount.Text}");
            }
        }

        private void btnTransferMoney(object sender, RoutedEventArgs e)
        {
            if (checkBoxDepositTransferMoney.IsChecked == true)
            {
                ICreateAccount<BankAccount<int>> account = new CreateDepositAccount();
                BankAccount<int> bankAccount = account.CreateAccount(int.Parse(bank.accounts[int.Parse(textBoxIdFromTransferMoney.Text) - 1].Deposit));
                ICreateAccount<BankAccount<int>> account2 = new CreateDepositAccount();
                BankAccount<int> bankAccount2 = account.CreateAccount(int.Parse(bank.accounts[int.Parse(textBoxIdToTransferMoney.Text) - 1].Deposit));
                ISendMoney<BankAccount<int>> sendMoney = new AccountSendMoney();
                sendMoney.SendMoney(bankAccount, bankAccount2, int.Parse(textBoxSummaTransferMoney.Text));
                bank.accounts[int.Parse(textBoxIdFromTransferMoney.Text) - 1].Deposit = bankAccount.Account.ToString();
                bank.accounts[int.Parse(textBoxIdToTransferMoney.Text) - 1].Deposit = bankAccount2.Account.ToString();
                bank.accountEntities.SaveChanges();
                Notify.Invoke($"Перевод на депозитный счёт {textBoxSummaTransferMoney.Text}");
            }
            else if (checkBoxNedepositTransferMoney.IsChecked == true)
            {
                ICreateAccount<BankAccount<int>> account = new CreateDepositAccount();
                BankAccount<int> bankAccount = account.CreateAccount(int.Parse(bank.accounts[int.Parse(textBoxIdFromTransferMoney.Text) - 1].Nedeposit));
                ICreateAccount<BankAccount<int>> account2 = new CreateDepositAccount();
                BankAccount<int> bankAccount2 = account.CreateAccount(int.Parse(bank.accounts[int.Parse(textBoxIdToTransferMoney.Text) - 1].Nedeposit));
                ISendMoney<BankAccount<int>> sendMoney = new AccountSendMoney();
                sendMoney.SendMoney(bankAccount, bankAccount2, int.Parse(textBoxSummaTransferMoney.Text));
                bank.accounts[int.Parse(textBoxIdFromTransferMoney.Text) - 1].Nedeposit = bankAccount.Account.ToString();
                bank.accounts[int.Parse(textBoxIdToTransferMoney.Text) - 1].Nedeposit = bankAccount2.Account.ToString();
                bank.accountEntities.SaveChanges();
                Notify.Invoke($"Перевод на недепозитный счёт {textBoxSummaTransferMoney.Text}");

            }
        }

        public void Message(string message)
        {
            MessageBox.Show(message, "Уведомлнеие");
        }
    }
}