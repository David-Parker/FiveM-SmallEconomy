using System;
using System.Collections.Generic;
using CitizenFX.Core;
using CitizenFX.Core.Native;
using SmallEconomy.Shared;

namespace SmallEconomy.Client.Event
{
    /// <summary>
    /// Client-side event for user to query their current money balance.
    /// </summary>
    public class GetMoneyClient : BaseScript
    {
        public GetMoneyClient()
        {
            API.RegisterCommand("se:money", new Action<int, List<object>, string>((source, args, raw) =>
            {
                if (args.Count != 0)
                {
                    ClientHandler.PlayerError("Usage: /se:money");

                    return;
                }

                TriggerServerEvent(Events.GetMoneyEventServer, source);
            }), false);
        }

        public void GetMoneyEvent(UInt64 money)
        {
            ClientHandler.PlayerInfo($"Your Money: {money}");
        }
    }
}
