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
                    TriggerEvent("chat:addMessage", new
                    {
                        color = new[] { 255, 0, 0 },
                        args = new[] { "Invalid Command", "Usage: /store" }
                    });

                    return;
                }

                TriggerServerEvent(Events.ViewStoreEventServer, source);
            }), false);
        }

        public void ViewStoreEvent(string items)
        {
            TriggerEvent("chat:addMessage", new
            {
                color = new[] { 255, 0, 0 },
                args = new[] { "[SmallEconomy]", $"{items}" }
            });
        }
    }
}
