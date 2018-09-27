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
		private NodeList<string> _list;

		private void Init()
		{
			_list = new NodeList<string>();
		}

		[Fact]
		public void NodeListCommaDelimitedStringWorksAsExpected()
		{
			throw new NotImplementedException();
		}
	}
}