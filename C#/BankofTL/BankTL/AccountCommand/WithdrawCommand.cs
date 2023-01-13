using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankTL.AccountCommand;

namespace BankTL.AccountCommand
{
    internal class WithdrawCommand : IAccountCommand
    {    
        public void Execute(Account account, double amount)
        {               
            
            var withdraw = new Transaction(-amount, DateTime.Now);
            account.AddTransaction(withdraw);
        }

    }
}
