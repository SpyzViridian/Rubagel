namespace Spyz.Rubagel.IO;

using System.Threading.Tasks;

public interface ILineProvider {
	public void ForEachLine(LineConsumer lineConsumer);
}
