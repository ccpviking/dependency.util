using System;
using System.IO;
using System.Reflection;
using dependency.lib;
using Newtonsoft.Json;
using Xunit;

namespace dependency.tests
{
	public class InputParserTests
	{
		const string invalidInput = @"input_invalid.json";
		const string validInput = @"input_valid.json";

		[Fact]
		public void ParseFileAsExpected()
		{
			var parser = new InputParser();
			var input = parser.ParseFile(validInput.ToApplicationPath());
			Assert.NotEmpty(input);
		}

		[Fact]
		public void NoFileThrowsException()
		{
			Exception exception = null;
			var parser = new InputParser();
			try
			{
				parser.ParseFile("not_a_file".ToApplicationPath());
			}
			catch (FileNotFoundException ex)
			{
				exception = ex;
			}
			Assert.NotNull(exception);
		}

		[Fact]
		public void WrongFileFormatThrowsException()
		{
			Exception exception = null;
			var parser = new InputParser();
			try
			{
				parser.ParseFile("input_bad_format.txt".ToApplicationPath());
			}
			catch (JsonReaderException ex)
			{
				exception = ex;
			}
			Assert.NotNull(exception);
		}
	}
}
