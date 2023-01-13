using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankTL.AccountCommand
{
    public interface IAccountCommand
    {
        void Execute(Account account, double amount);
    }

}
