using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clocker.ClockCommand
{
    public interface IClockerCommand
    {
        void Execute(Employee employee, decimal time);
    }
}
