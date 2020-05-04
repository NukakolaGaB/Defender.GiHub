using UnityEngine;
using System.Collections;

public class DesactivaActivaHabla : MonoBehaviour {

	[SerializeField] DesactivaActiva desactivaActiva;


	// Use this for initialization
	public void Desactivarme () {

		desactivaActiva.ActivarJuego();
	
	}
	

}
