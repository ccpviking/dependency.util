using System.Text;

namespace dependency.lib
{
	public class Node<T>
	{
		public T Value { get; set; }
		public Node<T> DependsOn { get; set; } // Assumption that a package can have at most one dependency
		public Node<T> Previous { get; set; }
		public bool IsRoot { get; set; }

		public Node<T> FindByValue(T value)
		{
			if (Value.Equals(value))
			{
				return this;
			}
			return DependsOn?.FindByValue(value);
		}

		public string CommaDelimitedString()
		{
			var builder = new StringBuilder();
			builder.Append(DependsOn?.CommaDelimitedString());
			builder.Append($"{Value.ToString()}, ");
			return builder.ToString();
		}
	}
}