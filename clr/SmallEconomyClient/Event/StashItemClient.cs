using System;
using System.Collections.Generic;
using CitizenFX.Core;
using CitizenFX.Core.Native;
using SmallEconomy.Client.Items;
using SmallEconomy.Shared;

namespace SmallEconomy.Client.Event
{
    /// <summary>
    /// Client-side event for user to use an item in their inventory.
    /// </summary>
    public class StashItemClient : BaseScript
    {
        public StashItemClient()
        {
            API.RegisterCommand("se:stash", new Action<int, List<object>, string>((source, args, raw) =>
            {
                uint index;

                if (args.Count != 1 || uint.TryParse(args[0] as string, out index) == false)
                {
                    ClientHandler.PlayerError("Usage: /se:stash index");

                    return;
                }

                TriggerServerEvent(Events.StashItemEventServer, index, source);
            }), false);
        }

        public void StashItemEvent(string handle)
        {
            InUseItemInventory.Remove(handle);
        }
    }
}
