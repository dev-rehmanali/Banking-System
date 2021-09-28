using System;
using Task3._2;

namespace Task5._2
{
    class WithdrawTransactions
    {
        private Account account;
        private decimal amount;
        private bool executed;
        private bool success;
        private bool reversed;

        public WithdrawTransactions(Account account,decimal amount) {

            this.account = account;
            this.amount = amount;

        }

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

        public void Print() {

            if (this.Success) 
            {

                Console.WriteLine("Withdraw Successful");
                Console.WriteLine("Amount Withdrawn: " + this.amount);
            }else
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
            else if (this.account.Balance < this.amount || this.account.Balance == 0)
            {
                throw new InvalidOperationException("Insufficient Balance to Withdraw");

            }
            else 
            {
                this.account.Balance -= this.amount;
                this.success = true;
            }

        }

        public void RollBack()
        {

            if (this.Success && !this.Reversed)
            {

                this.account.Balance += this.amount;
                this.reversed = true;

            }
            else 
            {

                throw new InvalidOperationException("Transaction already Attempted");
            }

        }


    }
}
