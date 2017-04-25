using System;

namespace Calculator
{
	class Program
	{
		static void Main(string[] args)
		{
			var selection = "y";

			while (selection == "y")
			{
				Console.WriteLine("Введи число Х:");
				var x = Convert.ToDouble(Console.ReadLine());
				
				Console.WriteLine("Введи знак операции (+ - * /):");
				var op = Console.ReadLine();

				Console.WriteLine("Введи число Y:");
				var y = Convert.ToDouble(Console.ReadLine());

				double result = 0;

				if (op == "*")
				{
					result = x * y;
				}
				else if (op == "-")
				{
					result = x - y;
				}
				else if (op == "+")
				{
					result = x + y;
				}
				else if (op == "/")

				{if (y == 0)
					{ Console.WriteLine("Нельзя делить на 0. Повторить? Введите y (да) или нажмите любую клавишу для выхода");
						selection = Console.ReadLine();
						continue;
					}
					result = x / y;
				}
				else
				{
					Console.WriteLine("Такую операцию выполнить нельзя. Повторить? Введите y (да) или нажмите любую клавишу для выхода");
					selection = Console.ReadLine();

					continue;
				}

				Console.WriteLine("Ответ: " + result.ToString() + " \r\nПовторить? Введите y (да) или нажмите любую клавишу для выхода");
				selection = Console.ReadLine();
			}
		}
	}
}
