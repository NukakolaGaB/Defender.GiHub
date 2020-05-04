using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class InicializarPuntuaciones : MonoBehaviour {

	[Tooltip("arrays con las casillas de los records")]
	[SerializeField] Text [] nombresP;
	[SerializeField] Text [] puntuacionesP;
	[SerializeField] Text [] nivelesP;
	public bool terminado=false;

	// Use this for initialization
	void Start () {
		terminado = false;
		for (int i = 0; i < 5; i++) {
			if(Puntuaciones.panicMode){
				nombresP [i].text = Puntuaciones.nombresRecordPanic[i];
				puntuacionesP [i].text = Puntuaciones.puntuacionesRecordPanic[i].ToString();
				nivelesP [i].text = Puntuaciones.nivelRecordPanic[i].ToString();
			}
			else{
			nombresP [i].text = Puntuaciones.nombresRecordP[i];
			puntuacionesP [i].text = Puntuaciones.puntuacionesRecordP[i].ToString();
			nivelesP [i].text = Puntuaciones.nivelRecordP[i].ToString();
			}
		}
	}
	public void Terminado(){
	
		terminado = true;
	
	
	}
}
