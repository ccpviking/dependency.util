using System.Text;

namespace dependency.lib
{
	public class Node<T>
	{
		public T Value { get; set; }
		public Node<T> Left { get; set; }
		public Node<T> Right { get; set; }

		public Node<T> FindByValue(T value)
		{
			if (Value.Equals(value))
			{
				return this;
			}
			return Left?.FindByValue(value) ?? Right?.FindByValue(value);
		}

		public string CommaDelimitedString()
		{
			var builder = new StringBuilder();
			builder.Append(Left?.CommaDelimitedString());
			builder.Append($"{Value.ToString()}, ");
			builder.Append(Right?.CommaDelimitedString());
			return builder.ToString();
		}
	}
}