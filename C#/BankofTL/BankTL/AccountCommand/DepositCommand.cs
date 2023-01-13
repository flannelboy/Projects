using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankTL;

namespace BankTL.AccountCommand
{
    internal class DepositCommand : IAccountCommand
    {
        public void Execute(Account account, double amount)
        {
            var deposit = new Transaction(amount, DateTime.Now);
            account.AddTransaction(deposit);          
        }
    }
}
