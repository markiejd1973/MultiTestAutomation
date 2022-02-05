using Core.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Transformations
{
    public static class DateValues
	{
		/// <summary>
		/// Return the current date (as in when this is called/ran) in a format
		/// Using SQL FormatNumbers
		/// https://www.mssqltips.com/sqlservertip/1145/date-and-time-conversions-using-sql-server/
		/// </summary>
		/// <param name="date"></param>
		/// <returns></returns>
		public static string ReturnNowDateAsString(string format = "101")
		{
			DebugOutput.Log($"Proc - ReturnNowDateAsString");

			// format = At some point we will want to override the default format 101 with a read from a config file
			DateTime now = DateTime.Now;
			var date = Format(now);
			DebugOutput.Log($"sending back date as  {date}");
			return date;
		}

		//public static string DateFormat(string date)
		//{
		//	DebugOutput.Log($"Proc - DateFormat {date}");

		//	if (LR.Tests.Bdd.Core.Location.location == "UK")
		//	{
		//		return UKDateSupplied(date);
		//	}

		//	if (LR.Tests.Bdd.Core.Location.location == "US")
		//	{
		//		return date;
		//	}

		//	DebugOutput.Log($"Setting default to UK date format");
		//	return UKDateSupplied(date);
		//}

		public static string UKDateSupplied(string date)
		{
			DebugOutput.Log($"Proc - UKDateSupplied {date}");

			if (!date.Contains("/"))
			{
				DebugOutput.Log($"Need forward slash for now");
				return date;
			}

			string[] fullDate = date.Split('/');
			var numberOfParts = fullDate.Count();

			if (fullDate.Count() != 3)
			{
				DebugOutput.Log($"Need 3 parts of a date {date}");
				return date;
			}

			var day = fullDate[0];
			var month = fullDate[1];
			var year = fullDate[2];

			if (day.Length != 2)
			{
				day = "0" + day;
			}

			if (month.Length != 2)
			{
				month = "0" + month;
			}

			var usDate = $"{month}/{day}/{year}";
			return usDate;
		}


		/// <summary>
		/// Format the date supplied in a given format
		/// </summary>
		/// <param name="dateSupplied"></param>
		/// <param name="format"></param>
		/// <returns></returns>
		private static string Format(DateTime dateSupplied, string format = "101")
		{
			DebugOutput.Log($"Proc - Format {dateSupplied} {format}");
			string date = "";

			switch (format)
			{
				default:
				case "1":
					{
						date = dateSupplied.ToString("MM/dd/yy");
						break;
					}
				case "2":
					{
						date = dateSupplied.ToString("yy/MM/dd");
						break;
					}
				case "101":
					{
						date = dateSupplied.ToString("MM/dd/yyyy");
						break;
					}
				case "103":
					{
						date = dateSupplied.ToString("dd/MM/yyyy");
						break;
					}
				case "104":
					{
						date = dateSupplied.ToString("dd.MM.yyyy");
						break;
					}
			}

			return date;
		}

		/// <summary>
		/// Use maths to a date and return the date as a string
		/// </summary>
		/// <param name="number"></param>
		/// <param name="maths"></param>
		/// <param name="format"></param>
		/// <returns></returns>
		public static string MathsToDate(string number, string maths, string format = "101")
		{
			DebugOutput.Log($"Proc - MathsToDate {number} {maths} {format}");

			double doubleDays;
			var days = double.TryParse(number, out doubleDays);
			var date = "";

			if (maths == "+")
			{
				date = Format(DateTime.Now.AddDays(doubleDays), format);
			}

			return date;
		}

		public static string TurnStringDateAround(string date)
		{
			DebugOutput.Log($"Proc - TurnStringDateAround {date}");
			DebugOutput.Log($"Some dates are right, but wrong...  dd/mm/yyyy changed to mm/dd/yyyy");
			string dd = date.Substring(0, 2);
			DebugOutput.Log(dd);
			string mm = date.Substring(3, 2);
			DebugOutput.Log(mm);
			string yyyy = date.Substring(6, 4);
			DebugOutput.Log(yyyy);
			string newDate = $"{mm}/{dd}/{yyyy}";
			DebugOutput.Log($"changed {date} to {newDate}");
			return newDate;
		}

		/// <summary>
		/// Return NOW() as a STRING
		/// </summary>
		/// <param name="format"></param>
		/// <returns></returns>
		public static string ReturnNowDateTimeAsString(string format = "20")
		{
			DebugOutput.Log($"Proc - ReturnNowDateTimeAsString");

			// format = At some point we will want to override the default format 101 with a read from a config file
			string date = "";

			switch (format)
			{
				default:
				case "1":
					{
						break;
					}
				case "20":
					{
						date = DateTime.Now.ToString("yyyy-MM-dd H:mm:ss");
						break;
					}
				case "101":
					{
						date = DateTime.Now.ToString("MM/dd/yyyy");
						break;
					}
				case "103":
					{
						date = DateTime.Now.ToString("dd/MM/yyyy");
						break;
					}
				case "104":
					{
						date = DateTime.Now.ToString("dd.MM.yyyy");
						break;
					}
			}

			DebugOutput.Log($"sending back date as  {date}");
			return date;
		}

		/// <summary>
		/// Take a date and change the divider - like a / to a . or visa versa
		/// </summary>
		/// <param name="date"></param>
		/// <param name="changeTo"></param>
		/// <returns></returns>
		public static string ChangeDateDivider(string date, string changeTo)
		{
			var returned = "";

			if (date.Contains("/"))
			{
				returned = date.Replace("/", changeTo);
			}

			if (date.Contains("."))
			{
				returned = date.Replace(".", changeTo);
			}

			return "";
		}

	}
}
