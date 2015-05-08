using System;

namespace System.ComponentModel.DataAnnotations
{
	public class MinAgeAttribute : ValidationAttribute
	{
		private readonly int minimumAge;
		public MinAgeAttribute(int minAge)
		{
			minimumAge = minAge;
		}

		public override bool IsValid(object value)
		{
			if(value == null)
			{
				return true;
			}

			DateTime date = Convert.ToDateTime(value);
			long ticks = DateTime.Now.Ticks - date.Ticks;
			int years = new DateTime(ticks).Year;
			return years > minimumAge;
		}
	}
}
