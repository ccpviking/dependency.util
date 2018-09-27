using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace dependency.lib
{
	public class NodeList<T> : Collection<Node<T>>
	{
		public NodeList() : base() { }

		public Node<T> FindByValue(T value)
		{
			// search the list for the value
			foreach (var item in Items)
			{
				var node = item.FindByValue(value);
				if (node != null)
				{
					return node;
				}
			}
			// if we reach this point, the node does not exist
			return null;
		}

		public bool HasLeafNode()
		{
			foreach (var item in Items)
			{
				if (item.DependsOn == null)
					return true;
			}
			return false;
		}

		public string CommaDelimitedString()
		{
			var builder = new StringBuilder();
			foreach (var item in Items)
			{
				builder.Append(item.CommaDelimitedString());
			}
			return builder.ToString();
		}
	}
}