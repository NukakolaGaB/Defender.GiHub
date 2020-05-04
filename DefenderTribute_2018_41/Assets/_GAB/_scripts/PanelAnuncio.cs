using UnityEngine;
using System.Collections;

public class PanelAnuncio : MonoBehaviour {

	public DanoDeMisiles danoDeMisiles;

	public void Veranuncio(){

		Time.timeScale=0;
		danoDeMisiles.verAnuncio=true;
		danoDeMisiles.ComprobarAnuncio();


	}
	public void NoVerAnuncio(){
		Time.timeScale=0;
		danoDeMisiles.verAnuncio=false;
		danoDeMisiles.ComprobarAnuncio();



	}
}
