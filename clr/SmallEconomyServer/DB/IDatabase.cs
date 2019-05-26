using System;
using SmallEconomy.Server.Items;
using SmallEconomy.Shared;

namespace SmallEconomy.Server
{
    /// <summary>
    /// Represents the database that holds player economy data.
    /// </summary>
    public interface IDatabase
    {
        EconomyData GetEconomyDataForPlayer(string id);
        void UpdateMoneyForAllPlayers(UInt64 amount);
        void AddItemForPlayer(string id, Item item);
        Item GetItemForPlayer(string id, uint index);
    }
}
