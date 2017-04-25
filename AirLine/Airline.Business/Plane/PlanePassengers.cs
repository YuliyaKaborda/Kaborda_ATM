using System;
using Newtonsoft.Json.Serialization;
using System.Runtime.Serialization;

namespace Airline.Business.Plane
{
	[Serializable]
	public class PlanePassengers : PlaneBase
	{
		public PlanePassengers() : base()
		{

		}

		public int CapacityPassengers { get; set; } //проперти вместимость пассажирского самолета

		int CapacityCarring = 500;

		public override double GetCapacityCarrying()
		{
			return CapacityCarring;
		}

		public override int GetCapacityPassengers()
		{
			return CapacityPassengers;
		}
	}
}