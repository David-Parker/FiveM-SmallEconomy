using System;
using System.Collections.Generic;
using CitizenFX.Core;
using CitizenFX.Core.Native;
using SmallEconomy.Shared;

namespace SmallEconomy.Client.Event
{
    /// <summary>
    /// Client-side event for user to use an item in their inventory.
    /// </summary>
    public class HelpEventClient : BaseScript
    {
        public HelpEventClient()
        {
            API.RegisterCommand("se:help", new Action<int, List<object>, string>((source, args, raw) =>
            {
                if (args.Count != 0)
                {
                    ClientHandler.PlayerError("Usage: /se:help");
                    return;
                }

                ClientHandler.PlayerInfo("");
            }), false);
        }
    }
}
