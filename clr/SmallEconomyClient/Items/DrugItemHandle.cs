using CitizenFX.Core;
using CitizenFX.Core.Native;


namespace SmallEconomy.Client.Items
{
    /// <summary>
    /// Hanlde to a weapon, client will cleanup on stash.
    /// </summary>
    public class DrugItemHandle : ItemHandle
    {
        public DrugItemHandle(string handle)
            : base(handle)
        {
        }

        public override void Dispose()
        {
            API.SetPedIsDrunk(API.GetPlayerPed(-1), false);
            API.ShakeGameplayCam("DRUNK_SHAKE", 0);
            API.SetPedConfigFlag(API.GetPlayerPed(-1), 100, false);
            API.SetPedMovementClipset(API.GetPlayerPed(-1), "move_m@casual@d", 0);
        }
    }
}
