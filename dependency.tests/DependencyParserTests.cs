using System;
using dependency.lib;
using Xunit;

namespace dependency.tests
{
	public class DepenencyParserTests
	{
		[Fact]
		public void ParseDependenciesAsExpected()
		{
			var parser = new DependencyParser(new InputParser());
			var actual = parser.ParseDependenciesFromFile("input_valid.json".ToApplicationPath());
			Assert.NotNull(actual);
		}

		[Fact]
		public void ParseDependencyTextAsExpected()
		{
			var text = "[\"zero: one\",\"one: two\",\"two: three\",\"three: \",\"four: five\",\"five: six\",\"six: \"]";
			var parser = new DependencyParser(new InputParser());
			var actual = parser.ParseDependencies(text);
			Assert.NotNull(actual);
		}

		[Fact]
		public void ParseDependenciesCatchesCircularDependencies()
		{
			var parser = new DependencyParser(new InputParser());
			Exception exception = null;
			try
			{
				parser.ParseDependenciesFromFile("input_invalid.json".ToApplicationPath());
			}
			catch (InvalidOperationException ex)
			{
				exception = ex;
			}
			Assert.NotNull(exception);
		}

		[Fact]
		public void ParseExistingDependencyThrowsError()
		{
			var text = "[\"zero: one\",\"one: two\",\"two: three\",\"three: one\",\"four: five\",\"five: six\",\"six: \"]";
			var parser = new DependencyParser(new InputParser());
			Exception exception = null;
			try
			{
				parser.ParseDependencies(text);
			}
			catch (InvalidOperationException ex)
			{
				exception = ex;
			}
			Assert.NotNull(exception);
		}

		[Fact]
		public void ParseDependencyTextCatchesCircularDependencies()
		{
			var text = "[\"zero: one\",\"one: two\",\"two: three\",\"three: zero\",\"four: five\",\"five: six\",\"six: \"]";
			var parser = new DependencyParser(new InputParser());
			Exception exception = null;
			try
			{
				parser.ParseDependencies(text);
			}
			catch (InvalidOperationException ex)
			{
				exception = ex;
			}
			Assert.NotNull(exception);
		}
	}
}