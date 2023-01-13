using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clocker
{
    public class Time
    {
        public decimal TimeAmount { get; set; }
        public Time(decimal time)
        {
            this.TimeAmount = time;
        }
        
    }
}
