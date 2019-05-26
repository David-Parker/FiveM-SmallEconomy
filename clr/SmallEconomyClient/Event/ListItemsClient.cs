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
    public class ListItemsClient : BaseScript
    {
        public ListItemsClient()
        {
            API.RegisterCommand("se:items", new Action<int, List<object>, string>((source, args, raw) =>
            {
                if (args.Count != 0)
                {
                    TriggerEvent("chat:addMessage", new
                    {
                        color = new[] { 255, 0, 0 },
                        args = new[] { "Invalid Command", "Usage: /listItems" }
                    });

                    return;
                }

                TriggerServerEvent(Events.ListItemsEventServer, source);
            }), false);
        }

        public void ListItemsEvent(string items)
        {
            TriggerEvent("chat:addMessage", new
            {
                color = new[] { 255, 0, 0 },
                args = new[] { "[SmallEconomy]", $"Your Items: {items}" }
            });
        }
    }
}
