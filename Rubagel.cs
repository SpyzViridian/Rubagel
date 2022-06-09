namespace Spyz.Rubagel;

using IO;
using Spyz.Rubagel.Lexer;
using System;
using System.Collections.Generic;

public class Rubagel : RubagelBase {

	// ------------------------------------------------------------------------
	// PROPERTIES
	// ------------------------------------------------------------------------

	// ------------------------------------------------------------------------
	// METHODS
	// ------------------------------------------------------------------------

	public void Test() {
		TokenLoader tokenLoader = new(new ResourceReader("tokens"));

		IList<TokenData> tokensData;

		try {
			tokensData = tokenLoader.LoadTokenData();
		} catch (Exception e) {
			Output.PrintLine(e, OutputColor.Red);
			return;
		}

		foreach (TokenData tokenData in tokensData) {
			Output.PrintLine(tokenData);
		}

		ConsoleReader reader = new();
		reader.ForEachLine(s => Output.PrintLine(s));
	}

}
