using System;
using SmallEconomy.Shared;

namespace SmallEconomy.Server
{
    /// <summary>
    /// Represents the database that holds player economy data.
    /// </summary>
    public interface IDatabase
    {
        EconomyData GetEconomyDataForPlayer(string id);
        StoreListing GetStoreListingData();
        void UpdateMoneyForAllPlayers(UInt64 amount);
        bool AddMoneyForPlayer(string id, UInt64 amount);
        bool DeductMoneyForPlayer(string id, UInt64 amount);
        void AddItemForPlayer(string id, Item item);
        Item GetItemForPlayer(string id, uint index);
    }
}
