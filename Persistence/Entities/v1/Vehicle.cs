using Persistence.Implementations.v1;

namespace Persistence.Entities.v1
{
    public class Vehicle : BaseEntity
    {
        public int EngineCapacity { get; set; }

        public int VehicleAge { get; set; }

        public Guid VehicleTypeId { get; set; }

        public VehicleType VehicleType { get; set; }

        public Guid TownId { get; set; }

        public Town Town { get; set; }

        public Purpose Purpose { get; set; }
    }
}
