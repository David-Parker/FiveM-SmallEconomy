using System;
using SmallEconomy.Shared;

namespace SmallEconomy.Server
{
    /// <summary>
    /// For persistent storage of player economy data.
    /// </summary>
    public class SQLDatabase : IDatabase
    {
        // Todo
        public EconomyData GetEconomyDataForPlayer(string id)
        {
            throw new NotImplementedException();
        }

        public void UpdateMoneyForAllPlayers(UInt64 amount)
        {
            throw new NotImplementedException();
        }

        public void AddItemForPlayer(string id, Item item)
        {
            throw new NotImplementedException();
        }

        public Item GetItemForPlayer(string id, uint index)
        {
            throw new NotImplementedException();
        }

        public StoreListing GetStoreListingData()
        {
            throw new NotImplementedException();
        }

        public bool DeductMoneyForPlayer(string id, UInt64 amount)
        {
            throw new NotImplementedException();
        }

        public bool AddMoneyForPlayer(string id, ulong amount)
        {
            throw new NotImplementedException();
        }
    }
}
