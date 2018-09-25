using System;
using System.IO;
using System.Reflection;
using dependency.lib;
using Xunit;

namespace dependency.tests
{
	public class InputParserTests
	{
		const string invalidInput = @"input_invalid.txt";
		const string validInput = @"input_valid.txt";

		[Fact]
		public void ParseFileCorrectly()
		{
			var parser = new InputParser();
			var input = parser.ParseFile(validInput.ToApplicationPath());
			Assert.NotNull(input);
		}
	}
}
