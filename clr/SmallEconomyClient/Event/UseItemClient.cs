using System;
using System.Collections.Generic;
using System.Threading;
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
                    ClientHandler.PlayerError("Usage: /se:use index");

                    return;
                }

                TriggerServerEvent(Events.UseItemEventServer, index, source);
            }), false);
        }

        public async Task UseItemEvent(string handle, int type, string param)
        {
            ItemType itemType = (ItemType)type;

            ItemHandle iHandle;

            switch (itemType)
            {
                case ItemType.Vehicle:
                    iHandle = await UseVehicle(handle, type, param);
                    break;
                case ItemType.Weapon:
                    iHandle = UseWeapon(handle, type, param);
                    break;
                case ItemType.Drug:
                    iHandle = await UseDrug(handle, type, param);
                    break;
                default:
                    ClientHandler.PlayerError($"Invalid enum.");
                    return;
            }

            if (iHandle == null)
            {
                return;
            }

            InUseItemInventory.Add(handle, iHandle);
        }

        private async Task<ItemHandle> UseVehicle(string handle, int type, string param)
        {
            var hash = (uint)API.GetHashKey(param);
            if (!API.IsModelInCdimage(hash) || !API.IsModelAVehicle(hash))
            {
                ClientHandler.PlayerError($"A vehicle was attempted to be loaded with an invalid model type.");

                return null;
            }

            var vehicle = await World.CreateVehicle(param, Game.PlayerPed.Position, Game.PlayerPed.Heading);
            ItemHandle iHandle = new VehicleItemHandle(handle, vehicle);

            Game.PlayerPed.SetIntoVehicle(vehicle, VehicleSeat.Driver);

            return iHandle;
        }

        private ItemHandle UseWeapon(string handle, int type, string param)
        {
            WeaponHash hash = (WeaponHash)API.GetHashKey(param);

            ItemHandle iHandle = new WeaponItemHandle(handle, hash);

            API.GiveWeaponToPed(Game.PlayerPed.Handle, (uint)hash, 999, false, true);

            return iHandle;
        }

        private async Task<ItemHandle> UseDrug(string handle, int type, string param)
        {
            ItemHandle iHandle = new DrugItemHandle(handle);

            if (API.HasAnimSetLoaded("MOVE_M@DRUNK@VERYDRUNK") == false)
            {
                API.RequestAnimSet("MOVE_M@DRUNK@VERYDRUNK");

                while (API.HasAnimSetLoaded("MOVE_M@DRUNK@VERYDRUNK") == false)
                {
                    await Delay(10);
                }
            }

            API.SetPedIsDrunk(API.GetPlayerPed(-1), true);
            API.ShakeGameplayCam("DRUNK_SHAKE", 1.0f);
            API.SetPedConfigFlag(API.GetPlayerPed(-1), 100, true);
            API.SetPedMovementClipset(API.GetPlayerPed(-1), "MOVE_M@DRUNK@VERYDRUNK", 1.0f);

            return iHandle;
        }
    }
}
