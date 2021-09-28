using System;
using System.Collections.Generic;
using System.Text;
using Task3._2;

namespace Task5._2
{
    class TransferTransaction
    {

        private Account fromAccount;
        private Account toAccount;
        private decimal amount;
        private DepositTransaction deposit;
        private WithdrawTransactions withDraw;
        private bool executed;
        private bool reversed;

        public bool Executed
        {

            get
            {
                return this.executed;
            }
        }

        public bool Reversed
        {

            get
            {
                return this.reversed;
            }
        }

        public TransferTransaction(Account fromAccount, Account toAccount, decimal amount)
        {

            this.fromAccount = fromAccount;
            this.toAccount = toAccount;
            this.amount = amount;
            withDraw = new WithdrawTransactions(fromAccount,amount);
            deposit = new DepositTransaction(toAccount,amount);

        }


        public void Print()
        {

            if (this.deposit.Executed && this.withDraw.Executed)
            {

                Console.WriteLine("Transfer Successful");
                Console.WriteLine("Transfered  " + +this.amount + " from " + this.fromAccount.Name + " Account to " + this.toAccount.Name + "Account");
            }
            else
            {

                Console.WriteLine("Transfer Failed");
            }
        }


        public void Execute()
        {

            if (this.Executed)
            {

                throw new InvalidOperationException("Transfer already Attempted");

            }
            else if (this.fromAccount.Balance < this.amount)
            {
                throw new InvalidOperationException("Insufficient Balance");

            }
            else
            {
                this.withDraw.Execute();
                this.executed = true;
                this.deposit.Execute();
            }

        }

        public void RollBack()
        {

            if (deposit.Executed && withDraw.Executed)
            {

                this.deposit.RollBack();
                this.withDraw.RollBack();
                this.reversed = true;

            } else if (toAccount.Balance < amount) 
            {
                throw new InvalidOperationException("Insufficient Fund to Roll Back");
            }
            else
            {

                throw new InvalidOperationException("Transaction already Attempted");
            }

        }


    }
}
