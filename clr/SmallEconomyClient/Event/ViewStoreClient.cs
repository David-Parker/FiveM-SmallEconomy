using System;
using System.Collections.Generic;
using CitizenFX.Core;
using CitizenFX.Core.Native;
using SmallEconomy.Shared;

namespace SmallEconomy.Client.Event
{
    /// <summary>
    /// Client-side event for user to query their items.
    /// </summary>
    public class ViewStoreClient : BaseScript
    {
        public ViewStoreClient()
        {
            API.RegisterCommand("se:store", new Action<int, List<object>, string>((source, args, raw) =>
            {
                if (args.Count != 0)
                {
                    ClientHandler.PlayerError("Usage: /se:store");

                    return;
                }

                TriggerServerEvent(Events.ViewStoreEventServer, source);
            }), false);
        }

        public void ViewStoreEvent(string items)
        {
            ClientHandler.PlayerInfo($"{items}");
        }
    }
}
