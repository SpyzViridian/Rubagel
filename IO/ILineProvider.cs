namespace Spyz.Rubagel.IO;

public interface ILineProvider {
	public void ForEachLine(System.Action<string> action);
}
