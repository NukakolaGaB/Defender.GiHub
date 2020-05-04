using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GestorInfoPuertas : MonoBehaviour {
	public Text nivel;
	public Text titulo;
	public Text infoIzqu;
	public Text infoDere;
	public Image captura;
	public Sprite cap0;
	public Sprite cap1;
	public Sprite cap2;
	public Sprite cap3;

	string [] nivelAleatorio = new string[] {"Nivel Aleatorio ", "Random Level ", "Ausazko Maila "};
	string [] facil = new string[] {"Fácil ","Easy ", "Erraza "};
	string [] normal = new string[] {"Normal ", "Normal ", "Normala "};
	string [] dificil = new string[] {"Difícil ", "Hard ", "Zaila "};
		string [] locura = new string[] {"Locura ", "Madness ", "Eromena "};

	string [] descripcionPanic = new string[] {"El modo Panic consiste en una progresión de dificultad sin pausas.¿Hasta que nivel llegarás?",
		"Panic Mode is a non-paused difficulty increasing. What level will you reach?",
		"Zailtasuna atsedengabe handitzen doa Panic eran. Ze mailaraino iritsiko zara?"};
	string [] descripcionCombos = new string[] {"Intenta conseguir combos (destruyendo misiles simultáneamente) para multiplicar tus puntos y activar los poderes", 
		"Try combos (destroying missiles simultaneously) for greater scores and to activate powers.", 
		"Puntuak bidertzeko eta ahalmen bereziak aktibatzeko saiatu konboak egiten (misilak ia aldi berean  suntsituz)."};
	string [] textoNivel = new string[] {"Nivel:", "Level:", "Maila:"};
	string [] desierto = new string[] {"Desierto Austral ", "Austral Dessert ", "Ego Basamortua "};
	string [] descripcionDesierto = new string[] {"Tu primera misión. Las centrales solares que abastecen de energía a los sistemas de defensa están bajo ataque.", 
		"Your first mission. The solar power plants of the defense system are under attack.", 
		"Zure lehenengo misioa. Defentsa sistemek ornitzen dituzten eguzki zentralak erasopean daude."};
	string [] descripcionDesierto2 = new string[] {"Buen trabajo. Pero ten cuidado, ahora atacan por otra dirección.", 
		"Good job. Caution, now the attack comes form a new direction.", 
		"Ondo egina. Kontuz, beste aldetik erasoko dute orain."};
	string [] cordilleras = new string[] {"Cordilleras ", "Hills ", "Mendikateak "};
	string [] descripcionCordilleras = new string[] {"La grandes cordilleras albergan el centro de defensa unificado de la tierra.Tienes que defenderlo, el fracaso no es una opción.",
		" The great mountain ranges house the unified defense center of the earth . You have to defend him , failure is not an option.",
		"Lurreko defentsa sistema zentrala mendikate garaietan dago. Defenditu behar duzu, porrotak ez du lekurik. "};
	string [] descripcionCombos2 = new string[] {"Si salvas a la Proteus conseguirás recuperar una vida.Afina tu puntería al máximo.",
		"If you save the Proteus you will get a life. Sharpen your aim to the maximum.", 
"Bizitza bat berreskuratzeko salba ezazu Proteusa, zuhurtziaz egin tiro."};
	string [] descripcionCordilleras2 = new string[] {"Cambiaremos de zona para poder defender más terreno.",
		"Zone change to defend more ground. ", 
		"Lekuz aldatuko gara lur zati zabalagoa defenditzeko."};
	string [] montanas = new string[] {"Montañas ", "Mountains ", "Mendi garaiak "};
	string [] descripcionMontanas = new string[] {"El último reducto de defensa humano.En lo alto de las montañas se encuentra el centro de defensa mundial.La última batalla te aguarda",
		"The last bastion of human defense.High in the mountains is the center of world defense. The final battle awaits.",
		"Giza defentsaren azken gotorlekua mendien puntan dago. Azken bataila heltzear dago."};
	string [] descripcionCombos3 = new string[] {"Observa bien el radar, te dará pistas de por donde vienen los misiles.",
		" Look carefully at the radar, will give you clues about the incoming missiles.", 
		"Arretaz begiratu erradarra, datozen misilen kokapena aurretuko dizu."};
	string [] descripcionMontanas2 = new string[] {"Múltiples ataques detectados, eres nuestra última esperanza.",
		"Multiple attacks detected , you are our last hope. ",
		"Eraso ugari topatu ditugu, zu zara gure azkenengo itxaropena."};
	string [] montanasNevadas = new string[] {"Montañas Nevadas ", "Snowy Mountains", "Elur Mendiak "};
	string [] descripcionMontanasNevadas = new string[] {"Toneladas de nieve protegen el sistema de monitorización de la guerra, sin ella estamos perdidos.",
		"Tons of snow protect war monitoring system,  without it we are lost.",
		"Guda azterketa zentruak elur tonen azpian daude babesturik, eurak gabe akabo."};
	string [] descripcionCombos4 = new string[] {"Derriba los misiles con escudo mediante dos disparos rápidos.",
		" Shoot down the shielded missiles by two quick shots.", 
		"Suntsitu ezkutua duten misilak bi tiro azkarrekin."};
	string [] descripcionMontanasNevadas2 = new string[] {"Pocos han sido capaces de llegar hasta aquí, enhorabuena.",
		" Few have been able to get this far, congratulations.",
		"Hain urrun heltzen inor gutxi lortu du, zorionak."};
	string [] descripcionCombos5 = new string[] {"Con múltiples objetivos en pantalla hay que aprender a priorizar.",
		"With multiple targets on the screen must learn to prioritize.", 
		"Lehentasunak nabaritzea beharrezkoa da pantailan objetibo asko daudenean."};

	// Use this for initialization
	void Start () {
		TextosNivel(Puntuaciones.comienzaEnNivel);
		//Debug.Log (Puntuaciones.dchaIzda);
	}
	void TextosNivel (int nivelCargado) {
		if (Puntuaciones.panicMode) {
			Puntuaciones.puntoMira = false;
			nivel.text = nivelAleatorio[Idioma.elegido];
			switch(Puntuaciones.dificultadPanic){

			case 0:
				titulo.text = facil[Idioma.elegido];
				break;
			case 1:
				titulo.text = normal[Idioma.elegido];
				break;
			case 2:
				titulo.text = dificil[Idioma.elegido];
				break;
			case 3:
				titulo.text = locura[Idioma.elegido];
				break;


			}

			infoIzqu.text = descripcionPanic[Idioma.elegido];
			infoDere.text = descripcionCombos[Idioma.elegido];
			Puntuaciones.scroll = Random.Range (0, 4);
			switch (Puntuaciones.scroll) {
			case 0:
				captura.sprite = cap0;
				break;
			case 1:
				captura.sprite = cap1;
				break;
			case 2:
				captura.sprite = cap2;
				break;
			case 3:
				captura.sprite = cap3;
				break;

			}
		} else {
			switch (nivelCargado) {
			case 0:
				Puntuaciones.puntoMira = true;

				nivel.text = textoNivel[Idioma.elegido]+" "+nivelCargado.ToString();
				titulo.text = desierto[Idioma.elegido];
				infoIzqu.text = descripcionDesierto[Idioma.elegido];
				captura.sprite = cap0;
				infoDere.text = descripcionCombos[Idioma.elegido];
				break;
			case 1:
				Puntuaciones.puntoMira = true;

				nivel.text = textoNivel[Idioma.elegido]+" "+nivelCargado.ToString();
				titulo.text = desierto[Idioma.elegido];
				infoIzqu.text = descripcionDesierto[Idioma.elegido];
				captura.sprite = cap0;
				infoDere.text = descripcionCombos[Idioma.elegido];
				break;
			case 6:
				Puntuaciones.puntoMira = false;

				nivel.text = textoNivel[Idioma.elegido]+" "+nivelCargado.ToString();
				titulo.text = desierto[Idioma.elegido];
				infoIzqu.text = descripcionDesierto2[Idioma.elegido];
				captura.sprite = cap0;
				infoDere.text = descripcionCombos[Idioma.elegido];
				break;

			case 11:
				Puntuaciones.puntoMira = false;

				nivel.text = textoNivel[Idioma.elegido]+" "+nivelCargado.ToString();
				titulo.text = cordilleras[Idioma.elegido];
				infoIzqu.text = descripcionCordilleras[Idioma.elegido];
				captura.sprite = cap1;
				infoDere.text = descripcionCombos2[Idioma.elegido]; 
				break;

			case 16:
				Puntuaciones.puntoMira = false;

				nivel.text = textoNivel[Idioma.elegido]+" "+nivelCargado.ToString();
				titulo.text = cordilleras[Idioma.elegido];
				infoIzqu.text = descripcionCordilleras2[Idioma.elegido];
				captura.sprite = cap1;
				infoDere.text = descripcionCombos3[Idioma.elegido];
				break;

			case 21:
				Puntuaciones.puntoMira = false;

				nivel.text = textoNivel[Idioma.elegido]+" "+nivelCargado.ToString();
				titulo.text = montanas[Idioma.elegido];
				infoIzqu.text = descripcionMontanas[Idioma.elegido];
				captura.sprite = cap2;
				infoDere.text = descripcionCombos3[Idioma.elegido];
				break;

			case 26:
				Puntuaciones.puntoMira = false;

				nivel.text = textoNivel[Idioma.elegido]+" "+nivelCargado.ToString();
				titulo.text = montanas[Idioma.elegido];
				infoIzqu.text = descripcionMontanas2[Idioma.elegido];
				captura.sprite = cap2;
				infoDere.text = descripcionCombos4[Idioma.elegido];
				break;

			case 31:
				Puntuaciones.puntoMira = false;

				nivel.text = textoNivel[Idioma.elegido]+" "+nivelCargado.ToString();
				titulo.text = montanasNevadas[Idioma.elegido];
				infoIzqu.text = descripcionMontanasNevadas[Idioma.elegido];
				captura.sprite = cap3;
				infoDere.text = descripcionCombos5[Idioma.elegido];
				break;
			case 36:
				Puntuaciones.puntoMira = false;

				nivel.text = textoNivel[Idioma.elegido]+" "+nivelCargado.ToString();
				titulo.text = montanasNevadas[Idioma.elegido];
				infoIzqu.text = descripcionMontanasNevadas2[Idioma.elegido];
				captura.sprite = cap3;
				infoDere.text = descripcionCombos5[Idioma.elegido];
				break;

			default:

				break;
			}
		}
}

}
