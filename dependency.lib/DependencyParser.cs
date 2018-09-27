using System;
using System.Collections.Generic;
using System.Text;

namespace dependency.lib
{
	public interface IDependencyParser
	{
		string ParseDependenciesFromFile(string filename);
		string ParseDependencies(string text);
	}

	public class DependencyParser : IDependencyParser
	{
		private readonly IInputParser _inputParser;
		private NodeList<string> _dependencies;

		public DependencyParser(IInputParser inputParser)
		{
			this._dependencies = new NodeList<string>();
			this._inputParser = inputParser;
		}

		public string ParseDependencies(string text)
		{
			var input = _inputParser.Parse(text).ToTupleList();
			return ParseInput(input);
		}

		public string ParseDependenciesFromFile(string filename)
		{
			var input = _inputParser.ParseFile(filename).ToTupleList();
			return ParseInput(input);
		}

		private string ParseInput(List<(string, string)> input)
		{
			input.ForEach(item => InsertDependency(item));
			//CheckCircularDependencies();
			return _dependencies.CommaDelimitedString();
		}

		private void InsertDependency((string, string) pair)
		{
			var source = _dependencies.FindByValue(pair.Item1);
			if (source == null)
			{
				// add a new source in a root position (to be moved later if it becomes a dependency)
				source = new Node<string> { Value = pair.Item1, IsRoot = true };
				_dependencies.Add(source);
			}

			var dependsOn = (!string.IsNullOrWhiteSpace(pair.Item2)) ? _dependencies.FindByValue(pair.Item2) ?? new Node<string> { Value = pair.Item2 } : null;

			if (source.DependsOn != null)
			{
				throw new InvalidOperationException($"Failed to add dependency {source.Value}:{dependsOn.Value} - package dependency already exists {source.Value}:{source.DependsOn?.Value}");
			}
			if (dependsOn?.Previous != null)
			{
				throw new InvalidOperationException($"Failed to add dependency {source.Value}:{dependsOn.Value} - package dependency already exists {dependsOn?.Previous?.Value}:{dependsOn?.Value}");
			}
			source.DependsOn = dependsOn;
			if (dependsOn != null)
				dependsOn.Previous = source;

			if (dependsOn?.IsRoot == true)
			{
				var temp = dependsOn.Previous;
				while (temp.IsRoot == false && temp != dependsOn)
					temp = temp.Previous;
				if (temp != dependsOn)
				{
					// there is another root node, so we can remove this dependency from being a root node.
					_dependencies.Remove(dependsOn);
					dependsOn.IsRoot = false;
				}
				CheckCircularDependencies();
			}
		}

		private void CheckCircularDependencies()
		{
			foreach (var node in _dependencies)
			{
				var builder = new StringBuilder();
				builder.Append($"{node.Value} -> ");
				var temp = node.DependsOn;
				while (temp != null && temp != node)
				{
					builder.Append($"{temp.Value} -> ");
					temp = temp.DependsOn;
				}
				if (temp == node)
				{
					builder.Append($"{temp.Value}");
					throw new InvalidOperationException($"Circular reference detected {builder.ToString()}");
				}
			}
		}
	}
}