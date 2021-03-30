using System;

namespace dioBank
{
    public class Account
    {
        private AccountType Type {get; set; }
        
        private double Balance { get; set; }

        private double Credit { get; set; }

        private string Name { get; set; }

        public Account(AccountType type, double balance, double credit, string name)
        {
            this.Type = type;
            this.Balance = balance;
            this.Credit = credit;
            this.Name = name;
        }

        public bool Withdraw(double withdrawValue)
        {
            if(this.Balance - withdrawValue < (this.Credit * -1)){
                Console.WriteLine("Saldo insuficiente.");
                return false;
            }

            this.Balance -= withdrawValue;
            Console.WriteLine("Saldo atual da conta de {0} é {1}", this.Name, this.Balance);

            return true;
        }

        public void Deposit(double depositValue)
        {
            this.Balance += depositValue;

            Console.WriteLine("Saldo atual da conta de {0} é {1}", this.Name, this.Balance);
        }

        public void WireTransfer(double wireTransferValue, Account finalAccount)
        {
            if(this.Withdraw(wireTransferValue)){
                finalAccount.Deposit(wireTransferValue);
            }
        }

        public override string ToString()
        {
            string callbackText = "";
            callbackText += "TipoConta " + this.Type + " | ";
            callbackText += "Nome " + this.Name + " | ";
            callbackText += "Saldo " + this.Balance + " | ";
            callbackText += "Crédito " + this.Credit + " | ";
            return callbackText;
        }

    }
}