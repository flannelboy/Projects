using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clocker.ClockCommand
{
    internal class ClockInCommand : IClockerCommand
    {
        public void Execute(Employee employee, decimal time)
        {
            var time = new Time(TimeAmount);
            employee.AddTime(time);
            
        }
    }
}
