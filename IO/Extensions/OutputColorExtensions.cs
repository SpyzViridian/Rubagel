namespace Spyz.Rubagel.IO.Extensions;

public static class OutputColorExtensions {
	public static string ToANSIEscapeSequence(this OutputColor color) {
		int colorCode = (int)color;

#if WINDOWS_10
		if(colorCode < 0) return "\u001B[0m";
		return $"\u001B[9{colorCode}m";
#elif UNIX
		if(colorCode < 0) return "\\033[0m";
		return $"\\033[0;9{colorCode}m";
#else
		return string.Empty;
#endif
	}
}
