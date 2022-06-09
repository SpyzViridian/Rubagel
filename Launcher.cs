namespace Spyz.Rubagel;

using System.Threading.Tasks;

#if STANDALONE
public static class Launcher {

	// ------------------------------------------------------------------------
	// PROPERTIES
	// ------------------------------------------------------------------------



	// ------------------------------------------------------------------------
	// METHODS
	// ------------------------------------------------------------------------

	private static void Main(string[] args) {
		Rubagel rubagel = new();
		rubagel.Test();
	}
}
#endif
