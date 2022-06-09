namespace Spyz.Rubagel.IO;

using Spyz.Rubagel.Extensions;

public abstract class BaseOutput : IOutput {

	// ------------------------------------------------------------------------
	// PROPERTIES
	// ------------------------------------------------------------------------



	// ------------------------------------------------------------------------
	// METHODS
	// ------------------------------------------------------------------------

	public abstract void Print(object value);
	public abstract void Print(object value, OutputColor color);
	public abstract void PrintLine(object value);
	public abstract void PrintLine(object value, OutputColor color);

	protected virtual string Colorize(string str, OutputColor color) {
		string colorStart = color.ToANSIEscapeSequence();
		string colorEnd = OutputColor.None.ToANSIEscapeSequence();

		return $"{colorStart}{str}{colorEnd}";
	}

	protected string Colorize(object value, OutputColor color) {
		return Colorize(value.ToString(), color);
	}
}
