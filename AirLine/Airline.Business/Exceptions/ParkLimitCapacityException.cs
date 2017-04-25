using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airline.Business.Exceptions
{
	public class ParkLimitCapacityException : Exception
	{
		public override string Message
		{
			get
			{
				return "Превышено количество самолётов в парке\r\n";
			}
		}
	}
}
