﻿using System;
using CitizenFX.Core;
using SmallEconomy.Shared;

namespace SmallEconomy.Server.Event
{
    /// <summary>
    /// Server-side event for player to use an item.
    /// </summary>
    public class StashItemServer : BaseScript
    {
        private readonly IDatabase database;

        public StashItemServer(IDatabase database)
        {
            if (database == null)
            {
                throw new ArgumentNullException(nameof(database));
            }

            this.database = database;
        }

        public void StashItemEvent(uint index, [FromSource] Player player)
        {
            if (player == null)
            {
                throw new ArgumentNullException(nameof(player));
            }

            Item item = this.database.GetItemForPlayer(PlayerHandler.GetPlayerId(player), index);

            if (item == null)
            {
                ErrorHandler.PlayerError(player, $"You do not have an item at slot {index}");
                return;
            }

            item.Dispose();
        }
    }
}
