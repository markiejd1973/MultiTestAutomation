using Core.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Core.Transformations
{
    public static class StringValues
    {

		/// <summary>
		///     Take a value string and change everything to lowercase
		/// </summary>
		/// <param name="value"></param>
		/// <returns></returns>
		public static string GetAllCharToLower(string value)
		{
			DebugOutput.Log($"Proc - GetAllCharToLower {value}");
			return string.IsNullOrEmpty(value) ? string.Empty : value.ToLower();
		}


		/// <summary>
		/// Take a string and remove any hidden HTML chars and return
		/// </summary>
		/// <param name="value"></param>
		/// <returns></returns>
		public static string RemoveHtmlFromEnd(string value)
		{
			DebugOutput.Log($"Proc - RemoveHtmlFromEnd {value}");

			if (string.IsNullOrEmpty(value))
			{
				return value;
			}

			value = Regex.Replace(value, @"<[^>]+>|&nbsp|\n;", "").Trim();

			return value;
		}

		/// <summary>
		/// Certain chars are fine on screen, but in comparison.. BAD
		/// </summary>
		/// <param name="value"></param>
		/// <returns></returns>
		public static string RemoveReserveredChars(string value)
		{
			DebugOutput.Log($"Proc - RemoveReserveredChars {value}");

			if (string.IsNullOrEmpty(value))
			{
				return value;
			}

			value = value.Replace("$", "");
			value = value.Replace("-", "");
			value = value.Replace("(", "");
			value = value.Replace(")", "");
			value = value.Replace("%", "");
			value = value.Replace(" ", "");
			return value;
		}

		public static string RemoveRequiredFieldAstrixFromHeader(string value)
		{
			DebugOutput.Log($"Proc - RemoveRequiredFieldAstrixFromHeader {value}");
			value = value.Replace(" *", "");
			return value;
		}

		/// <summary>
		/// Take a string and remove all spaces from it.
		/// </summary>
		/// <param name="value"></param>
		/// <returns></returns>
		public static string RemoveAllSpaces(string value)
		{
			DebugOutput.Log($"Proc - RemoveAllSpaces {value}");
			var returnedValue = value.Replace(" ", "");
			return returnedValue;
		}

		/// <summary>
		/// Remove number chars from a string.
		/// </summary>
		/// <param name="value"></param>
		/// <param name="number"></param>
		/// <returns></returns>
		public static string RemoveLastNChars(string value, int number)
		{
			DebugOutput.Log($"Proc - RemoveLastNChars {value}");
			return string.IsNullOrEmpty(value) ? value : value.Substring(0, value.Length - number);
		}

		/// <summary>
		/// pass in string using bang ! as delimited and replace with numbers
		/// </summary>
		/// <param name="xpath"></param>
		/// <param name="values"></param>
		/// <returns></returns>
		public static string FillDynamicXPathWildcardBang(string xpath, params int[] values)
		{
			DebugOutput.Log($"Proc - FillDynamicXPathWildcardBang {xpath}");
			const char delimiter = '!';
			return BreakStringUpByDelmited(xpath, delimiter, values);
		}

		/// <summary>
		/// pass in a string using astrix * as demited and replace with numbers
		/// </summary>
		/// <param name="xpath"></param>
		/// <param name="values"></param>
		/// <returns></returns>
		public static string FillDynamicXPathWildcards(string xpath, params int[] values)
		{
			DebugOutput.Log($"Proc - FillDynamicXPathWildcardBang {xpath}");
			const char delimiter = '*';
			DebugOutput.Log($"Proc - FillDynamicXPathWildcards {xpath} with {delimiter} ");
			return BreakStringUpByDelmited(xpath, delimiter, values);
		}

		/// <summary>
		/// Pass in a string, if that string says a certain thing, it will return a date, date time.
		/// </summary>
		/// <param name="value"></param>
		/// <returns></returns>
		public static string DateString(string value)
		{
			DebugOutput.Log($"Proc - DateString {value}");

			switch (value)
			{
				default:
					{
						return value;
					}
				case "TODAYS DATE":
					{
						return DateValues.ReturnNowDateAsString();
					}
				case "TODAYS DATE AND TIME":
					{
						return DateValues.ReturnNowDateTimeAsString();
					}
			}
		}

		/// <summary>
		/// Break up a string passing in the delimiter value
		/// </summary>
		/// <param name="xpath"></param>
		/// <param name="delimiter"></param>
		/// <param name="values"></param>
		/// <returns></returns>
		private static string BreakStringUpByDelmited(string xpath, char delimiter, params int[] values)
		{
			DebugOutput.Log($"Proc - BreakStringUpByDelmited {xpath} with {delimiter} ");
			var wildcardCount = xpath.Count(x => x == delimiter);
			var valueCount = values.Length;

			if (wildcardCount != valueCount)
			{
				throw new ArgumentException(
					"Wrong number of integer parameters supplied. If you're surprised that you're seeing this message, then check that you aren't using a dynamic element selector in an `id`-based XPath!");
			}

			string[] XPathBuilder = xpath.Split(delimiter);
			var finalXPath = "";
			int counter = 0;

			foreach (var value in values)
			{
				DebugOutput.Log($"{counter} = {value}");
				finalXPath = finalXPath + XPathBuilder[counter] + value.ToString();
				counter++;
			}

			finalXPath = finalXPath + XPathBuilder[counter];
			DebugOutput.Log(finalXPath);
			return finalXPath;
		}
	}
}
