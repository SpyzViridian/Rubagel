﻿namespace Spyz.Rubagel.Lexer;

using Spyz.Rubagel.Extensions;
using Spyz.Rubagel.IO;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

public class TokenLoader : RubagelBase {

	// ------------------------------------------------------------------------
	// PROPERTIES
	// ------------------------------------------------------------------------

	private const char COMMENT_CHAR = '#';
	private const char FLAG_SPLIT = '&';
	private const string SPLIT_REGEX = @"\s+";

	private const int TOKEN_INDEX = 0;
	private const int PATTERN_INDEX = 1;
	private const int FLAGS_INDEX = 2;
	private const int PRECEDENCE_INDEX = 3;

	private readonly ILineReader _reader;
	private IList<TokenData> _tokenDataList;
	private ParseInfo _parseInfo;
	private Regex _splitRegex;

	// ------------------------------------------------------------------------
	// METHODS
	// ------------------------------------------------------------------------

	public TokenLoader(ILineReader reader) {
		_reader = reader;
		_parseInfo = new ParseInfo(reader.ResourceName, 1, 0);
	}

	public IList<TokenData> LoadTokenData() {
		_tokenDataList = new List<TokenData>();
		_splitRegex = new Regex(SPLIT_REGEX);
		
		try {
			_reader.ForEachLine(ParseLine);
		} catch (IOException e) {
			Output.PrintLine(e.Message, OutputColor.Red);
			return new List<TokenData>();
		}

		return _tokenDataList;
	}

	private void ParseLine(string line) {
		// Lines that starts with # or are empty should be ignored
		if(!string.IsNullOrWhiteSpace(line) && line[0] != COMMENT_CHAR) {
			string[] split = _splitRegex.Split(line);

			try {
				TokenData data = CreateTokenData(split);
				_tokenDataList.Add(data);
			} catch (ParsingException e) {
				Output.PrintLine(e, OutputColor.Yellow);
			}
		}

		_parseInfo.Line++;
	}

	private TokenData CreateTokenData(string[] split) {
		if (split.Length < 2) {
			throw new ParsingException("Unable to parse Token + Pattern", _parseInfo);
		}

		if(!split[TOKEN_INDEX].TryEnum(out Token token)) {
			throw new ParsingException($"Unrecognized token '{split[TOKEN_INDEX]}'", _parseInfo);
		}

		TokenData data = new(token, split[PATTERN_INDEX]);

		if(split.TryIndex(FLAGS_INDEX, out string flags)) {
			data.Flags = ParseFlags(flags);
		}

		if (split.TryIndex(PRECEDENCE_INDEX, out string precedenceStr)) {
			if (!int.TryParse(precedenceStr, out int precedence)) {
				throw new ParsingException($"Invalid precedence value '{precedenceStr}'", _parseInfo);
			}

			data.Precedence = precedence;
		}

		return data;
	}

	private TokenFlag ParseFlags(string flagStr) {
		TokenFlag flag = TokenFlag.None;
		foreach(string split in flagStr.Split(FLAG_SPLIT)) {
			if(!split.TryEnum(out TokenFlag tf)) {
				throw new ParsingException($"Unrecognized flag '{split}'", _parseInfo);
			}

			flag |= tf;
		}

		return flag;
	}

}