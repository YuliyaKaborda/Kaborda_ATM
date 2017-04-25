using Airline.Business;
using Airline.Business.Exceptions;
using Airline.Business.Plane;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;


namespace AirLine
{
	internal class Program
	{

		private static void Main(string[] args)
		{
			//БД

			var dbNorth = new DbNorth();
			
			dbNorth.dbSelect();
			dbNorth.dbInsert();
			dbNorth.dbUpdate("Pasta/Tapas");
			dbNorth.dbDelete("Pasta/Tapas");

			dbNorth.callProcedure("Produce", 1996);
			dbNorth.callMyProcedure();


			//объявляем переменные с именами моделей самолетов
			string boeing737 = "Boeing 737";

			string boeing747 = "Boeing 747";

			string boeing777 = "Boeing 777";

			string il76 = "IL-76";

			string an124 = "AN-124";

			var aviaPark = new AviaPark(); //вызываем конструктор авиапарка с пустыми коллекциями самолетов
										   //создаем экземпляры самолетов, задаем параметры
			string[] id;

			try
			{
				id = File.ReadAllLines("d:\\CNet\\PlanesID.txt"); //читаем данные ID из файла на диске
			}
			catch (FileNotFoundException ex)
			{
				Console.WriteLine("Создайте файл PlanesID.txt в каталоге d:\\CNet\\");
				Console.ReadKey();
				return;
			}
			catch (DirectoryNotFoundException ex1)
			{
				Console.WriteLine("Неправильное имя папки. Создайте каталог на диске d:\\CNet\\");
				Console.ReadKey();
				return;
			}

			PlanePassengers boeing1;
			PlanePassengers boeing2;
			PlanePassengers boeing3;
			PlanePassengers boeing4;
			PlanePassengers boeing5;
			PlanePassengers ty134;
			PlaneTransport an1;
			PlaneTransport il1;
			PlaneTransport il2;

			try
			{

				boeing1 = new PlanePassengers()
				{
					CapacityPassengers = 159,
					ID = id[0],
					ModelName = boeing737,
					Distance = 7900
				};

				boeing2 = new PlanePassengers()
				{
					CapacityPassengers = 279,
					ID = id[1],
					ModelName = boeing747,
					Distance = 9000
				};

				boeing3 = new PlanePassengers()
				{
					CapacityPassengers = 299,
					ID = id[2],
					ModelName = boeing777,
					Distance = 15000
				};

				boeing4 = new PlanePassengers()
				{
					CapacityPassengers = 159,
					ID = id[3],
					ModelName = boeing737,
					Distance = 7900
				};
				boeing5 = new PlanePassengers()
				{
					CapacityPassengers = 299,
					ID = id[4],
					ModelName = boeing777,
					Distance = 15000
				};

				il1 = new PlaneTransport()
				{
					CapacityCarrying = 127000,
					ID = id[5],
					ModelName = il76,
					Distance = 6700
				};

				il2 = new PlaneTransport()
				{
					CapacityCarrying = 127000,
					ID = id[6],
					ModelName = il76,
					Distance = 6700
				};

				an1 = new PlaneTransport()
				{
					CapacityCarrying = 222000,
					ID = id[7],
					ModelName = an124,
					Distance = 7500
				};

				ty134 = new PlanePassengers();
				ty134.Distance = 5670;
				ty134.ID = id[8];
				ty134.CapacityPassengers = 130;
				ty134.ModelName = "Ту-134";
			}

			catch (IndexOutOfRangeException ex)
			{
				Console.WriteLine("Создайте .txt файл содержащий ID самолетов парка");
				Console.ReadKey();
				return;

			}

			//JSON de\serialization

			string serializedPlane = JsonConvert.SerializeObject(boeing1);
			string serializedTransport = JsonConvert.SerializeObject(an1);
			PlaneTransport desirializedTransport = JsonConvert.DeserializeObject<PlaneTransport>(serializedTransport);
			PlanePassengers deserializedPlane = JsonConvert.DeserializeObject<PlanePassengers>(serializedPlane);

			try
			{

				aviaPark.AddPassengersPlane(deserializedPlane);
				aviaPark.AddPassengersPlane(boeing2);
				aviaPark.AddPassengersPlane(boeing3);
				aviaPark.AddPassengersPlane(boeing4);
				aviaPark.AddPassengersPlane(boeing5);
				aviaPark.AddPassengersPlane(ty134);

				aviaPark.AddTransportPlane(il1);
				aviaPark.AddTransportPlane(il2);
				aviaPark.AddTransportPlane(desirializedTransport);
			}
			catch (ParkLimitCapacityException ex)
			{
				Console.WriteLine(ex.Message);
			}
				
			
			var passengersCapacity = aviaPark.GetCommomPassengersCapacity();

			Console.WriteLine("Общая вместимость парка " + passengersCapacity + "чел");

			var carryingCapacity = aviaPark.GetCommonCarryingCapacity();

			Console.WriteLine("Общая грузоподъемность парка " + carryingCapacity + "кг");

			//сортировка по дальности полета

			var sortedPlanes = new List<PlaneBase>(); 

			aviaPark.SortPlanesByDistance(aviaPark.GetAllPlanes());

			Console.WriteLine("Доступные самолеты компании:");

			BinaryFormatter formatter = new BinaryFormatter();

			using (FileStream fs = new FileStream("d:\\CNet\\Collection.dat", FileMode.OpenOrCreate))
			{
				List<PlaneBase> dePlanes = (List<PlaneBase>)formatter.Deserialize(fs);
				sortedPlanes = dePlanes;
				sortedPlanes.Reverse();

			}


			foreach (PlaneBase sortedPlane in sortedPlanes)
			{
				Console.WriteLine(sortedPlane.ID + " " + sortedPlane.ModelName + " " + sortedPlane.Distance + "км");
			}
			Console.WriteLine("Задайте параметры поиска. Введите дальность полета в км");
			double minDistance = 0;

			try
			{
				minDistance = GetMinDistance(Console.ReadLine());
			}
			catch (WrongArgumentException ex)
			{
				Console.WriteLine(ex.Message);
				Console.ReadKey();
				return;
			}
			catch (ArgumentNullException ex1)
			{
				Console.WriteLine("Необходимо ввести значение для поиска");
				Console.ReadKey();
				return;
			}
			Console.WriteLine("Введите массу груза в кг");
			var minCarryingCapacity = Convert.ToDouble(Console.ReadLine());
			Console.WriteLine("Введите количество пассажиров");
			var minPassengersCapacity = Convert.ToInt16(Console.ReadLine());
			var planes = new List<PlaneBase>();
			try
			{
				planes = aviaPark.SearchPlane(minDistance, minCarryingCapacity, minPassengersCapacity); //результаты поиска
				
			}
			catch (ArgumentException ex)
			{
				Console.WriteLine("Введены отрицательные значения. Поиск невозможен.");
				Console.ReadKey();
				return;
			}

			catch (PlanesNotFoundException ex1)
			{
				Console.WriteLine(ex1.Message);
				Console.ReadKey();
				return;
			}
				Console.WriteLine("Результаты поиска:\r\n");
			foreach (PlaneBase searchPlane in planes)
			{
				var SearchResultsLine = searchPlane.ID + " " + searchPlane.ModelName + " " + searchPlane.Distance + "км " + searchPlane.GetCapacityCarrying() + "кг " + searchPlane.GetCapacityPassengers() + "чел\r\n";
				File.AppendAllText("d:\\CNet\\PlanesSearchResults.txt", SearchResultsLine); //записываем результаты поиска в файл на диске
				Console.WriteLine(SearchResultsLine);
			}

			Console.WriteLine("Спасибо, что воспользовались услугами нашей авиакомпании! Удачи!");
			Console.ReadKey();
		}

		private static double GetMinDistance(string input)
		{
			double minDistance;

			if (input == string.Empty)
			{
				throw new ArgumentNullException();

			}

			try
			{
				minDistance = Convert.ToDouble(input);
			}
			catch
			{
				throw new WrongArgumentException();
			}

			return minDistance;
		}
	}
}