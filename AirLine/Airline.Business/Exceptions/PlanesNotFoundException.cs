using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airline.Business.Exceptions
{
	public class PlanesNotFoundException : Exception
	{
		public override string Message
		{
			get
			{
				return "Нет подходящих самолетов в результатах поиска";
			}
		}
	}
}
