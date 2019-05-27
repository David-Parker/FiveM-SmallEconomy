using CitizenFX.Core;
using CitizenFX.Core.Native;

namespace SmallEconomy.Client.Items
{
    /// <summary>
    /// Hanlde to a weapon, client will cleanup on stash.
    /// </summary>
    public class WeaponItemHandle : ItemHandle
    {
        private readonly WeaponHash weapon;

        public WeaponItemHandle(string handle, WeaponHash weapon)
            : base(handle)
        {
            this.weapon = weapon;
        }

        public override void Dispose()
        {
            API.RemoveWeaponFromPed(Game.PlayerPed.Handle, (uint)weapon);
        }
    }
}
