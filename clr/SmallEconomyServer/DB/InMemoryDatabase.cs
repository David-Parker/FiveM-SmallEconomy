using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using SmallEconomy.Shared;

namespace SmallEconomy.Server
{
    /// <summary>
    /// Holds all economy data in an in-memory database. Useful for testing and mocking tests.
    /// </summary>
    public class InMemoryDatabase : IDatabase
    {
        private readonly static ConcurrentDictionary<string, EconomyData> economyData;
        private readonly static StoreListing store;
        private readonly static object dataLock;

        static InMemoryDatabase()
        {
            economyData = new ConcurrentDictionary<string, EconomyData>();
            dataLock = new object();

            // Create some store items
            IList<StoreItem> storeItems = new List<StoreItem>();
            storeItems.Add(new StoreItem(0, new StoreListingItem(ItemType.Vehicle, "adder")));
            storeItems.Add(new StoreItem(0, new StoreListingItem(ItemType.Vehicle, "infernus")));
            storeItems.Add(new StoreItem(0, new StoreListingItem(ItemType.Vehicle, "coquette")));
            storeItems.Add(new StoreItem(0, new StoreListingItem(ItemType.Weapon, "WEAPON_MG")));
            storeItems.Add(new StoreItem(0, new StoreListingItem(ItemType.Drug, "Beer")));

            store = new StoreListing(storeItems);
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

        public StoreListing GetStoreListingData()
        {
            return store;
        }

        public bool DeductMoneyForPlayer(string id, UInt64 amount)
        {
            EconomyData data = GetEconomyDataForPlayer(id);

            if (data.Money < amount)
            {
                return false;
            }

            lock (dataLock)
            {
                data.Money -= amount;
            }

            return true;
        }

        public bool AddMoneyForPlayer(string id, ulong amount)
        {
            EconomyData data = GetEconomyDataForPlayer(id);

            lock (dataLock)
            {
                data.Money += amount;
            }

            return true;
        }
    }
}
