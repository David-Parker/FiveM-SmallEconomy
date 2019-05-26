using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using SmallEconomy.Server.Items;
using SmallEconomy.Shared;

namespace SmallEconomy.Server
{
    /// <summary>
    /// Holds all economy data in an in-memory database. Useful for testing and mocking tests.
    /// </summary>
    public class InMemoryDatabase : IDatabase
    {
        private readonly static ConcurrentDictionary<string, EconomyData> economyData;
        private readonly static ConcurrentDictionary<string, IList<Item>> itemData;

        static InMemoryDatabase()
        {
            economyData = new ConcurrentDictionary<string, EconomyData>();
            itemData = new ConcurrentDictionary<string, IList<Item>>();
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
            IList<Item> items;

            if (itemData.TryGetValue(id, out items) == false)
            {
                items = new List<Item>();
                itemData.TryAdd(id, items);
            }

            items.Add(item);
        }

        public Item GetItemForPlayer(string id, uint index)
        {
            IList<Item> items;

            if (itemData.TryGetValue(id, out items) == false)
            {
                return null;
            }

            if (index > items.Count - 1)
            {
                return null;
            }

            return items[(int)index];
        }
    }
}
