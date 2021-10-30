using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROGRAM6
{
    class BankAccount
    {
        private long number;
        private decimal balance;
        private string type;
        public long Number
        {
            get
            {
                return number;
            }
            set
            {
                number = value;
            }
        }
        public decimal Balance
        {
            get
            {
                return balance;
            }
            set
            {
                balance = value;
            }
        }
        public string Type
        {
            get
            {
                return type;
            }
            set
            {
                type = value;
            }
        }
        public void MoneyTransfer(BankAccount bank, int sum)
        {
            this.Balance -= sum;
            bank.Balance += sum;
        }
        public void PrintValues()
        {
            Console.WriteLine($"Account number: {number}");
            Console.WriteLine($"Account balance: {balance}");
            Console.WriteLine($"Account type: {type}");
        }
    }
}
