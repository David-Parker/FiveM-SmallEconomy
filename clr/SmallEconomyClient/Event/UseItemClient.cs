using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CitizenFX.Core;
using CitizenFX.Core.Native;
using SmallEconomy.Client.Items;
using SmallEconomy.Shared;

namespace SmallEconomy.Client.Event
{
    /// <summary>
    /// Client-side event for user to use an item in their inventory.
    /// </summary>
    public class UseItemClient : BaseScript
    {
        public UseItemClient()
        {
            API.RegisterCommand("se:use", new Action<int, List<object>, string>((source, args, raw) =>
            {
                uint index;

                if (args.Count != 1 || uint.TryParse(args[0] as string, out index) == false)
                {
                    TriggerEvent("chat:addMessage", new
                    {
                        color = new[] { 255, 0, 0 },
                        args = new[] { "Invalid Command", "Usage: /se:use index" }
                    });

                    return;
                }

                TriggerServerEvent(Events.UseItemEventServer, index, source);
            }), false);
        }

        public async Task UseItemEvent(string handle, int type, string param)
        {
            ItemType itemType = (ItemType)type;

            switch (itemType)
            {
                case ItemType.Vehicle:
                    await UseVehicle(handle, type, param);
                    break;
            }
        }

        private async Task UseVehicle(string handle, int type, string param)
        {
            var hash = (uint)API.GetHashKey(param);
            if (!API.IsModelInCdimage(hash) || !API.IsModelAVehicle(hash))
            {
                TriggerEvent("chat:addMessage", new
                {
                    color = new[] { 255, 0, 0 },
                    args = new[] { "[SmallEconomy Error]", $"A vehicle was attempted to be loaded with an invalid model type." }
                });

                return;
            }

            var vehicle = await World.CreateVehicle(param, Game.PlayerPed.Position, Game.PlayerPed.Heading);

            ItemHandle vHandle = new VehicleItemHandle(handle, vehicle);

            InuseItemInventory.Add(handle, vHandle);

            Game.PlayerPed.SetIntoVehicle(vehicle, VehicleSeat.Driver);
        }
    }
}
