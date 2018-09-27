using System;
using System.Collections.Generic;

namespace dependency.lib
{
	public static class LibExtensions
	{
		// expected string format {some_string}: {other_string}
		public static List<(string, string)> ToTupleList(this List<string> list)
		{
			var result = new List<(string, string)>();
			list.ForEach(item =>
			{
				var temp = item.Split(':');
				if (temp.Length <= 1)
					throw new FormatException("Expecting (:) delimiters.");
				result.Add((temp[0].Trim(), temp[1]?.Trim() ?? string.Empty));
			});
			return result;
		}
	}
}