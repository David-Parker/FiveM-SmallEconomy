﻿using System;
using SmallEconomy.Server.Items;
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
    }
}