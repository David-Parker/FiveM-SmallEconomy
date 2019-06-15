using System;
using System.Collections.Generic;

namespace SmallEconomy.Shared
{
    /// <summary>
    /// Represents the economy data for a single player.
    /// </summary>
    public class EconomyData
    {
        public EconomyData()
        {
            this.Money = 0ul;
            this.Items = new List<Item>();
            this.Job = Job.Unemployed;
        }

        public UInt64 Money { get; set; }
        public IList<Item> Items { get; set; }
        public Job Job { get; set; }
    }
}
