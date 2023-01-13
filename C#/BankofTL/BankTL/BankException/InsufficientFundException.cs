using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankTL.BankException
{
    public class InsufficientFundException : ApplicationException
    {
        public InsufficientFundException() : base("Insufficient funds for this withdrawal")
        {}
    }
}
