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
		public void TupleListCreatedAsExpected()
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
			var pairs = list.ToTupleList();
			Assert.True(pairs.Count == 6);
			Assert.True(pairs[5].Item1.StartsWith("Ice"));
		}

		[Fact]
		public void TupleListExpectedBadFormat()
		{
			var list = new List<string>
			{
				"InvalidEntry"
			};
			Exception exception = null;
			try
			{
				list.ToTupleList();
			}
			catch (FormatException ex)
			{
				exception = ex;
			}
			Assert.NotNull(exception);
		}
	}
}