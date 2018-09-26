using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using dependency.lib;
using Newtonsoft.Json;
using Xunit;

namespace dependency.tests
{
	public class ExtensionTests
	{
		[Fact]
		public void KvpListCreatedAsExpected()
		{
			var list = new List<string>
			{
				"KittenService: ",
				"Leetmeme: Cyberportal",
				"Cyberportal: Ice",
				"CamelCaser: KittenService",
				"Fraudstream: Leetmeme",
				"Ice: "
			};
			var kvpList = list.ToKvpList();
			Assert.True(kvpList.Count == 6);
			Assert.True(kvpList[5].Key.StartsWith("Ice"));
		}

		[Fact]
		public void KvpListExpectedBadFormat()
		{
			var list = new List<string>
			{
				"InvalidEntry"
			};
			Exception exception = null;
			try
			{
				list.ToKvpList();
			}
			catch (FormatException ex)
			{
				exception = ex;
			}
			Assert.NotNull(exception);
		}
	}
}