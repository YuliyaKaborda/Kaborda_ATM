using System;
namespace Airline.Business.Plane
{
	[Serializable]
	public class PlaneTransport : PlaneBase
    {

        public PlaneTransport() : base()
        {
        }

        public double CapacityCarrying { get; set; }

		int CapacityPassengers = 3;

		public override double GetCapacityCarrying()
        {
           return CapacityCarrying;
        }

        public override int GetCapacityPassengers()
        {
            return CapacityPassengers;
        }
    }
}
