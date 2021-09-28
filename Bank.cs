using System;
using System.Collections.Generic;
using System.Linq;
using Task3._2;
using Task5._2;

namespace Task6._2
{
    class Bank
    {

        private List<Account> accountList = new List<Account>();

        public List<Account> AccountList{

            get {
                return accountList.ToList();
            }

        }

        public Bank() 
        { 
            
        }

        public void AddAccount(Account account) 
        {
            accountList.Add(account);
        }

        public Account GetAccount(String name) 
        {
            Account account1 = null;
            foreach (Account account in this.accountList )
            {

                if (account.Name.CompareTo(name) == 0) 
                {
                    account1 = account;
                }
            }
            return account1;
        }

        //Method Overloading
        public void ExecuteTransaction(DepositTransaction transaction)
        {
            transaction.Execute();
        }

        //Method Overloading
        public void ExecuteTransaction(WithdrawTransactions transaction)
        {
            transaction.Execute();
        }

        //Method Overloading
        public void ExecuteTransaction(TransferTransaction transaction)
        {
            transaction.Execute();
        }

        public Account FindAccount(Bank bank) 
        {
            Account account3 = null;
            Console.WriteLine("Enter the Account name to be Searched");
            string name = Console.ReadLine();
            foreach (Account account in bank.accountList) 
            {
                if (account.Name.CompareTo(name) == 0) 
                {
                    account3 = account;
                    Console.WriteLine(account.Name + " Account Found");
                }
            }
            if (account3 == null) 
            {
                Console.WriteLine("No Account Exists With The Name " + "\"" + name + "\"");
            }

            return account3;
        
        }



    }
}
