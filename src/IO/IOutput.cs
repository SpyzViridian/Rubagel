namespace Spyz.Rubagel.IO;

public interface IOutput {
	public void Print(object value);
	public void Print(object value, OutputColor color);
	public void PrintLine(object value);
	public void PrintLine(object value, OutputColor color);
}
