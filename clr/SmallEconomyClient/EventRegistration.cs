using System;
using System.Threading.Tasks;
using CitizenFX.Core;
using SmallEconomy.Client.Event;
using SmallEconomy.Shared;

namespace SmallEconomy.Client
{
    /// <summary>
    /// Register client-side events.
    /// </summary>
    public class EventRegistration : BaseScript
    {
        public EventRegistration()
        {
            var helpEvent = new HelpEventClient();

            var moneyEvent = new GetMoneyClient();
            EventHandlers[Events.GetMoneyEventClient] += new Action<UInt64>(moneyEvent.GetMoneyEvent);

            var useItemEvent = new UseItemClient();
            EventHandlers[Events.UseItemEventClient] += new Func<string, int, string, Task>(useItemEvent.UseItemEvent);

            var listItemEvent = new ListItemsClient();
            EventHandlers[Events.ListItemsEventClient] += new Action<string>(listItemEvent.ListItemsEvent);

            var viewStoreEvent = new ViewStoreClient();
            EventHandlers[Events.ViewStoreEventClient] += new Action<string>(viewStoreEvent.ViewStoreEvent);

            var buyItemEvent = new BuyItemClient();
            EventHandlers[Events.BuyItemEventClient] += new Action<bool, string>(buyItemEvent.BuyItemEvent);

            var stashItemEvent = new StashItemClient();
            EventHandlers[Events.StashItemEventClient] += new Action<string>(stashItemEvent.StashItemEvent);
        }
    }
}
