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
        private readonly static ConcurrentDictionary<string, EconomyData> economyData;
        private readonly static object dataLock;

        static InMemoryDatabase()
        {
            economyData = new ConcurrentDictionary<string, EconomyData>();
            dataLock = new object();
        }

        public EconomyData GetEconomyDataForPlayer(string id)
        {
            if (economyData.ContainsKey(id) == false)
            {
                economyData.TryAdd(id, new EconomyData());
            }

            return economyData[id];
        }

        public void UpdateMoneyForAllPlayers(UInt64 amount)
        {
            foreach (var kv in economyData)
            {
                var ed = kv.Value;
                ed.Money += amount;
            }
        }

        public void AddItemForPlayer(string id, Item item)
        {
            EconomyData data = GetEconomyDataForPlayer(id);

            lock (dataLock)
            {
                data.Items.Add(item);
            }
        }

        public Item GetItemForPlayer(string id, uint index)
        {
            EconomyData data = GetEconomyDataForPlayer(id);

            if (index > data.Items.Count - 1)
            {
                return null;
            }

            return data.Items[(int)index];
        }
    }
}
