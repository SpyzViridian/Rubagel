namespace Spyz.Rubagel;

using Spyz.Rubagel.IO;
using Spyz.Rubagel.Lexer;
using System.Collections.Generic;
using System.Threading.Tasks;

public class Interpreter : RubagelBase {

	// ------------------------------------------------------------------------
	// PROPERTIES
	// ------------------------------------------------------------------------

	private const string TOKEN_DATA_FILE = "tokens";

	private static TokenDataset _tokenDataset;

	// ------------------------------------------------------------------------
	// METHODS
	// ------------------------------------------------------------------------

	private static void LoadTokensData() {
		if(_tokenDataset is null) {
			TokenLoader tokenLoader = new(new ResourceReader(TOKEN_DATA_FILE));
			_tokenDataset = tokenLoader.LoadTokenData();
		}
	}

	public virtual void Evaluate(ILineReader lineReader) {
		// Load tokens data if data is not loaded
		LoadTokensData();

		// Parse tokens from the provider
		TokenParser parser = new(lineReader, _tokenDataset);

		IList<ParsedToken> tokens = parser.Parse();
		foreach (ParsedToken token in tokens) {
			Output.PrintLine($"{token}", OutputColor.Green);
		}
	}
}
