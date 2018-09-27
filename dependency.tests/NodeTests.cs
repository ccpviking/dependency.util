using dependency.lib;
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
				Value = "two",
				DependsOn = new Node<string> { Value = "one", DependsOn = new Node<string> { Value = "zero" } }
			};
		}

		[Fact]
		public void NodeIsFoundAsExpected()
		{
			Init();
			var node = _root.FindByValue("one");
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
			Assert.Equal("zero, one, two, ", cds);
		}
	}
}