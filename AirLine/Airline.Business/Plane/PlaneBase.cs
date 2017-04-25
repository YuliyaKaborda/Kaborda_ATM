using System;

namespace Airline.Business.Plane
{
	[Serializable]
	public abstract class PlaneBase
    {
        public string ID { get; set; }

        public double Distance { get; set; }

        public string ModelName { get; set; }

        public PlaneBase()
        {
       
        }

        public abstract int GetCapacityPassengers();

        public abstract double GetCapacityCarrying();

    }
}