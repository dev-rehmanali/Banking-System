using System;
using System.Collections.Generic;
using System.Text;
using Task3._2;

namespace Task5._2
{
    class DepositTransaction
    {

        private Account account;
        private decimal amount;
        private bool executed;
        private bool success;
        private bool reversed;

      public bool Executed
        {

            get
            {
                return this.executed;
            }
        }

        public bool Success
        {
            get
            {
                return this.success;
            }
        }
        public bool Reversed
        {

            get
            {
                return this.reversed;
            }
        }

        public DepositTransaction(Account account, decimal amount)
        {

            this.account = account;
            this.amount = amount;

        }


        public void Print()
        {

            if (this.Success)
            {

                Console.WriteLine("Deposit Successful");
                Console.WriteLine("Amount Deposited: " + +this.amount);
            }
            else
            {

                Console.WriteLine("Transaction Failed");
            }
        }


        public void Execute()
        {

            this.executed = true;
            if (this.Success && !this.Reversed)
            {

                throw new InvalidOperationException("Transaction already Attempted");

            }
            else if (this.amount < 0)
            {
                throw new InvalidOperationException("Amount Less Than 0");

            }
            else
            {
                this.account.Balance += this.amount;
                this.success = true;
            }

        }

        public void RollBack()
        {

            if (this.Success && !this.Reversed)
            {

                this.account.Balance -= this.amount;
                this.reversed = true;

            }
            else
            {

                throw new InvalidOperationException("Transaction already Attempted");
            }

        }


    }
}
