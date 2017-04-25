using System;
using System.Collections.Generic;
using System.Text;


namespace Airline.Business.Exceptions
{
	public class WrongArgumentException : ArgumentException
	{
		public override string Message
		{
			get
			{
				return "Введены неверные данные поиска";
			}
		}

	}
}
