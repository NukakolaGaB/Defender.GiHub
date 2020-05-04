public static class Puntuaciones {


	/// <summary>
	/// La puntuacion total de la partida.
	/// </summary>
	public static int score;
	/// <summary>
	/// El record de puntuacion.
	/// </summary>
	public static int maxScore;
	public static int maxScorePanic0;
	public static int maxScorePanic1;
	public static int maxScorePanic2;
	public static int maxScorePanic3;
	/// <summary>
	/// Dice si los cohetes van de dcha a izda (bool).
	/// </summary>
	public static bool dchaIzda;
	/// <summary>
	/// Que escena se va a cargar.
	/// </summary>
	public static int escena = 2;
	public static int nivel = 1;
	public static int comienzaEnNivel=1;
	public static int maxNivel = 1;
	/// <summary>
	/// Que scroll se muestra (0 desierto o 1 nieve de momento).
	/// </summary>
	public static int scroll;
	/// <summary>
	/// Cuantos misiles han escapado.
	/// </summary>
	public static int cuantosImpactan=0;
	//cuando cuantosImpactan == limiteImpactos GameOver.
	public const int limiteImpactos = 4;
	/// <summary>
	/// VAlor constante para cargar la escena de las puertas.
	/// </summary>
	public const int escenapuertas = 2;
	public static int ultimaCapa = 3;
	public const int limiteAbsolutoCapas = 9;
	public static int capa = 3;
	/// <summary>
	/// Cada cuantos segundos se lanza un misil.
	/// </summary>
	public static float tiempoLanzar = 2f;
	public const float tiempoLanzarMin = 1f;
	/// <summary>
	/// con que velocidad se lanzan los misiles.
	/// </summary>
	public static float speed = 5;
	public const float speedInicial = 5;
	/// <summary>
	/// Si el juego es en modo panic (true) o historia(false).
	/// </summary>
	public static bool panicMode = true;
	/// <summary>
	/// Si lanza cohetes en capas al azar (true) o cada vez de una capa (false).
	/// </summary>
	public static bool randomCapa;
	/// <summary>
	/// nivel de dificultad del panic (0 easy, 1 normal, 2 hard, 3 crazy).
	/// </summary>
	public static int dificultadPanic;
	/// <summary>
	/// cada cuantos misiles se sube de nivel.
	/// </summary>
	public static int misilesTotales = 10;

	public static int proyDisparados;

	public static bool activadoResetPrefs = true;

	public static int indiceCanvasInfo;
	public static int cuantosCanvasInfo = 5;

	public static int videosParaVer = 3;

	public static bool usandoPoderInfinito=false;
	//poderes entre escenas
	public static bool poderLimpia = false;
	public static bool poderInfinito = false;
	public static bool poderMuro = false;

	//tags
	public const string proyectil = "proyectil";
	public const string perseguido = "perseguido";
	public const string perseguidoR = "perseguidoR";
	public const string muro = "muro";
	public const string puntoDebil = "puntoDebil";

	public static float cantEscudos = 0f;

//	public static bool valeParaPremio;
	public static string[] nombresRecordP = new string[5] {"UNAI","AITOR","GAIZKA",  "JUAN", "RAFA"};
	public static int[] puntuacionesRecordP = new int[5] {3562167,3423604,3411272,  1456100, 1325700}; 
	public static int[] nivelRecordP = new int[5] {41, 32, 30, 15, 10};

	public static string[] nombresRecordPanic = new string[5] {"GAIZKA","UNAI",  "AITOR", "JUAN", "RAFA"};
	public static int[] puntuacionesRecordPanic = new int[5] {644000, 636000, 3000, 2000, 1000}; 
	public static int[] nivelRecordPanic = new int[5] {28, 20, 2, 1, 1};

	public static bool puntoMira;

	public static float duracionBarrera;
}
	
public static class Tags {

	public const string proyectil = "proyectil";
	public const string perseguido = "perseguido";
	public const string perseguidoR = "perseguidoR";
	public const string misil = "misil";
	public const string untagged = "Untagged";
	public const string muro = "muro";
	public const string puntoDebil = "puntoDebil";

	public const int capa3 = 13;
	public const int capa4 = 14;
	public const int capa5 = 15;
	public const int capa6 = 16;
	public const int capa7 = 17;
	public const int capa8 = 18;
	public const int capa9 = 19;
	public const int entreCapas = 10;
	public const int capaP3 = 23;
	public const int capaP4 = 24;
	public const int capaP5 = 25;
	public const int capaP6 = 26;
	public const int capaP7 = 27;
	public const int capaP8 = 28;
	public const int capaP9 = 29;

}

public static class Idioma {
	public static int elegido = 0;
	public const int cuantos = 3;
	public const int castellano = 0;
	public const int ingles = 1;
	public const int euskera = 2;
}

public static class Guardado {

	public const string maximoNivel = "maximoNivel";
	public const string maximaPuntuacion = "maximaPuntuacion";
	public const string maximaPuntuacionPanic0 = "maximaPuntuacionPanic0";
	public const string maximaPuntuacionPanic1 = "maximaPuntuacionPanic1";
	public const string maximaPuntuacionPanic2 = "maximaPuntuacionPanic2";
	public const string maximaPuntuacionPanic3 = "maximaPuntuacionPanic3";

	public const string scorePartida = "scorePartida";
	public const string nivelPartida = "nivelPartida";
	public const string vidasPartida = "vidasPartida";
	public const string speedPartida = "speedPartida";
	public const string tiempoLanzarPartida = "tiempoLanzarPartida";

	public static readonly string[] nombresPremio = {"nombre0", "nombre1", "nombre2", "nombre3", "nombre4"};
	public static readonly string[] scoresPremio = {"score0", "score1", "score2", "score3", "score4"};
	public static readonly string[] nivelesPremio = {"nivel0", "nivel1", "nivel2", "nivel3", "nivel4"};

	public static readonly string[] nombresPremioP = {"nombre0P", "nombre1P", "nombre2P", "nombre3P", "nombre4P"};
	public static readonly string[] scoresPremioP = {"score0P", "score1P", "score2P", "score3P", "score4P"};
	public static readonly string[] nivelesPremioP = {"nivel0P", "nivel1P", "nivel2P", "nivel3P", "nivel4P"};

}
public static class Escenas {

	public const int carga = 0;
	public const int start = 1;
	public const int seleccionModo = 2;
	public const int escenapuertas = 3;
	public const int game = 4;
	public const int juegoSuperado = 5;
	public const int guardarnombre = 6;
}

public static class Accessos {

	public static ControladorMisiones controladorMisiones;
	public static RandomizeMusica randomizeMusica;
	public static MascaraDanno mascaraDanno;
	public static Disparador2D disparador2D;
	public static Poderes poderes;
	public static LanzaMisiles2D lanzaMisiles2D;

}

