using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmallEconomy.Shared
{
    public class Job
    {
        public readonly string name;
        public readonly UInt64 pay;
        public static readonly Job Unemployed;

        static Job()
        {
            Unemployed = new Job("Unemployed", 5);
        }

        public Job(string name, UInt64 pay)
        {
            if (String.IsNullOrEmpty(name))
            {
                throw new ArgumentNullException(nameof(name));
            }

            this.name = name;
            this.pay = pay;
        }
    }
}
