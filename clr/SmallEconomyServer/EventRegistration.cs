﻿using System;
using CitizenFX.Core;
using CitizenFX.Core.Native;
using SmallEconomy.Server.Event;
using SmallEconomy.Shared;

namespace SmallEconomy.Server
{
    /// <summary>
    /// Register server-side events.
    /// </summary>
    public class EventRegistration : BaseScript
    {
        private readonly IDatabase database;
        public EventRegistration()
        {
            this.database = new InMemoryDatabase();

            EventHandlers["onResourceStart"] += new Action<string>(OnResourceStart);

            var onTick = new OnTick(this.database);
            Tick += onTick.Payday;

            var moneyEvent = new GetMoneyServer(this.database);
            EventHandlers[Events.GetMoneyEventServer] += new Action<Player>(moneyEvent.GetMoneyEvent);

            var useItemEvent = new UseItemServer(this.database);
            EventHandlers[Events.UseItemEventServer] += new Action<uint, Player>(useItemEvent.UseItemEvent);

            EventHandlers["playerConnecting"] += new Action<Player, string, dynamic, dynamic>(OnPlayerConnecting);
        }

        private void OnPlayerConnecting([FromSource]Player player, string playerName, dynamic setKickReason, dynamic deferrals)
        {
            deferrals.defer();
            this.database.GetEconomyDataForPlayer(player.Identifiers["steam"]);
            deferrals.done();
        }

        private void OnResourceStart(string resourceName)
        {
            if (API.GetCurrentResourceName() != resourceName)
            {
                return;
            }

            foreach (var player in this.Players)
            {
                this.database.GetEconomyDataForPlayer(player.Identifiers["steam"]);
            }
        }
    }
}