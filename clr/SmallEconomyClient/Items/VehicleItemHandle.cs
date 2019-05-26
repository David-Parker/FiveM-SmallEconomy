using CitizenFX.Core;

namespace SmallEconomy.Client.Items
{
    /// <summary>
    /// Hanlde to a vehicle, client will cleanup on stash.
    /// </summary>
    public class VehicleItemHandle : ItemHandle
    {
        private readonly Vehicle vehicle;

        public VehicleItemHandle(string handle, Vehicle vehicle)
            :base(handle)
        {
            this.vehicle = vehicle;
        }

        public override void Dispose()
        {
            this.vehicle.Delete();
        }
    }
}
