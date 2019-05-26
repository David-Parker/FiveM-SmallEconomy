using System;
using System.Collections.Concurrent;
using SmallEconomy.Shared;

namespace SmallEconomy.Server
{
    /// <summary>
    /// Holds all economy data in an in-memory database. Useful for testing and mocking tests.
    /// </summary>
    public class InMemoryDatabase : IDatabase
    {
        private readonly static ConcurrentDictionary<string, EconomyData> data;

        static InMemoryDatabase()
        {
            data = new ConcurrentDictionary<string, EconomyData>();
        }

        public EconomyData GetEconomyDataForPlayer(string id)
        {
            if (data.ContainsKey(id) == false)
            {
                data.TryAdd(id, new EconomyData());
            }

            return data[id];
        }

        public void UpdateMoneyForAllPlayers(UInt64 amount)
        {
            foreach (var kv in data)
            {
                var ed = kv.Value;
                ed.Money += amount;
            }
        }
    }
}
