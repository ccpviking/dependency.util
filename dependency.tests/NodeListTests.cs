using System;
using System.IO;
using System.Reflection;
using dependency.lib;
using Newtonsoft.Json;
using Xunit;

namespace dependency.tests
{
	public class NodeListTests
	{
		[Fact]
		public void NodeListCommaDelimitedStringWorksAsExpected()
		{
			var list = new NodeList<string>();

			var root = new Node<string>
			{
				Value = "two",
				DependsOn = new Node<string> { Value = "one", DependsOn = new Node<string> { Value = "zero" } }
			};
			list.Add(root);
			root = new Node<string>
			{
				Value = "five",
				DependsOn = new Node<string> { Value = "four", DependsOn = new Node<string> { Value = "three" } }
			};
			list.Add(root);
			var actual = list.CommaDelimitedString();
			Assert.True(actual.Contains("zero, one, two, three, four, five"));
		}
	}
}