using System.IO;
using System.Text.RegularExpressions;

namespace dependency.tests
{
	public static class Extensions
	{
		// Returns <applicationPath>\<filename> as string
		public static string ToApplicationPath(this string fileName)
		{
			var exePath = Path.GetDirectoryName(System.Reflection
								.Assembly.GetExecutingAssembly().CodeBase);
			Regex appPathMatcher = new Regex(@"(?<!fil)[A-Za-z]:\\+[\S\s]*?(?=\\+bin)");
			var appRoot = appPathMatcher.Match(exePath).Value;
			return Path.Combine(appRoot, fileName);
		}
	}
}
