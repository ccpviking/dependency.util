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

		public DependencyParser(IInputParser inputParser)
		{
			this._inputParser = inputParser;
		}

		public string ParseDependencies(string text)
		{
			throw new System.NotImplementedException();
		}

		public string ParseDependenciesFromFile(string filename)
		{
			var input = _inputParser.ParseFile(filename);
			throw new System.NotImplementedException();
		}
	}
}