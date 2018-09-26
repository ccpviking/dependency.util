using System;
using System.IO;
using System.Reflection;
using dependency.lib;
using Newtonsoft.Json;
using Xunit;

namespace dependency.tests
{
	public class NodeTests
	{
		private Node<string> _root;
		private void Init()
		{
			_root = new Node<string>
			{
				Value = "three",
				Left = new Node<string> { Value = "one", Left = new Node<string> { Value = "zero" }, Right = new Node<string> { Value = "two" } },
				Right = new Node<string> { Value = "five", Left = new Node<string> { Value = "four" }, Right = new Node<string> { Value = "six" } }
			};
		}

		[Fact]
		public void NodeIsFoundAsExpected()
		{
			Init();
			var node = _root.FindByValue("six");
			Assert.NotNull(node);
		}

		[Fact]
		public void NodeNotFoundAsExpected()
		{
			Init();
			var node = _root.FindByValue("no_node");
			Assert.Null(node);
		}

		[Fact]
		public void NodeCommaDelimitedStringWorksAsExpected()
		{
			Init();
			var cds = _root.CommaDelimitedString();
			Assert.Equal("zero, one, two, three, four, five, six, ", cds);
		}
	}
}