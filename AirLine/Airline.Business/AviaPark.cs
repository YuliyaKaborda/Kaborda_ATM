using Airline.Business.Plane;
using System;
using System.Collections.Generic;
using Airline.Business.Exceptions;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace Airline.Business
{
	public class AviaPark
	{
		private const int parkCapacity = 10;
		public List<PlanePassengers> PassengersPark { get; set; } //коллекция пассажирских самолетов

		public List<PlaneTransport> TransportPark { get; set; } //коллекция транспортных самолетов

		

		public AviaPark() //конструктор класса АвиаПарк
		{
			PassengersPark = new List<PlanePassengers>(); //создаем пустые экземпляры коллекциий самолетов

			TransportPark = new List<PlaneTransport>(); 

		}

		public void AddPassengersPlane(PlanePassengers plane)
		{
			if (GetAllPlanes().Count == parkCapacity)
			{
				throw new ParkLimitCapacityException();
			}
			else {
				PassengersPark.Add(plane);
			}
		}

		public void AddTransportPlane(PlaneTransport plane)
		{
			if (GetAllPlanes().Count == parkCapacity)
			{
				throw new ParkLimitCapacityException();
			}
			else
			{
				TransportPark.Add(plane);
			}
		}

		public List<PlaneBase> GetAllPlanes() //вывод всех самолетов
		{
			var collection = new List<PlaneBase>(); 

			collection.AddRange(PassengersPark);

			collection.AddRange(TransportPark);

			return collection;
		}


		public List<PlaneBase> SortPlanesByDistance(List<PlaneBase> collection) //метод сортировки самолетов по дальности
		{
			for (var i = 1; i < collection.Count; i++)
			{
				for (int j = 0; j < collection.Count - 1; j++)
				{
					var item1 = collection[j];
					var item2 = collection[j + 1];
					if (item1.Distance > item2.Distance)
					{
						collection.RemoveAt(j);
						collection.Insert(j + 1, item1);
					}
				}
			}

			BinaryFormatter formatter = new BinaryFormatter();

			using (FileStream fs = new FileStream("d:\\CNet\\Collection.dat", FileMode.OpenOrCreate))
			{
				formatter.Serialize(fs, collection);

			}

			return collection;
		}

		public int GetCommomPassengersCapacity()
		{
			int result = 0;

			foreach (var plane in GetAllPlanes())
			{
				result += plane.GetCapacityPassengers();
			}

			return result;
		}

		public double GetCommonCarryingCapacity()
		{
			double result = 0;

			foreach (var plane in GetAllPlanes())
			{
				result += plane.GetCapacityCarrying();
			}

			return result;
		}

		public List<PlaneBase> SearchPlane(double minDistance, double minCarryingCapacity, int minPassengersCapacity)
		{

			if (minDistance < 0 || minCarryingCapacity < 0 || minPassengersCapacity < 0)
			{
				throw new ArgumentException();
			}

			var result = new List<PlaneBase>();

			foreach (var plane in GetAllPlanes())
			{
				if (plane.Distance < minDistance)
					continue;
				if (plane.GetCapacityCarrying() < minCarryingCapacity)
					continue;
				if (plane.GetCapacityPassengers() < minPassengersCapacity)
					continue;

				result.Add(plane);
			}

			if (result.Count == 0)
			{
				throw new PlanesNotFoundException();
			}

			return result;

		}
	}
}