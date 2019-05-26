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
       void UpdateMoneyForAllPlayers(UInt64 amount);
    }
}
