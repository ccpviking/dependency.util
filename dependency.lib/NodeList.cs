using System.Collections.ObjectModel;

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
	}
}