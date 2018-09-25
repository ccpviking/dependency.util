using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace dependency.lib
{
	public class InputParser
	{
		public List<string> ParseFile(string path)
		{
			var text = ReadFileText(path);
			return Parse(text);
		}

		public List<string> Parse(string input) => JsonConvert.DeserializeObject<List<string>>(input);

		private string ReadFileText(string path)
		{
			System.Diagnostics.Debug.Assert(!string.IsNullOrWhiteSpace(path));
			if (!File.Exists(path))
			{
				throw new FileNotFoundException("File not found.", path);
			}
			return File.ReadAllText(path);
		}
	}
}
