using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class PoderInfinito : MonoBehaviour {



	//canvas
	[SerializeField] Animator infiAnim;
	[SerializeField] Button botonInfinito;



	public void ActivarBoton(){
		
		botonInfinito.interactable = true;
		infiAnim.SetBool("LActivo",true);

	}
	public void LanzarMuro(){

		botonInfinito.interactable = false;
		infiAnim.SetBool("LLanzar",true);
		Accessos.disparador2D.DisparosInfinitos ();
		Puntuaciones.poderInfinito = false;
		Puntuaciones.usandoPoderInfinito = true;

	}

	public void DesactivarBoton(){


		Accessos.disparador2D.DisparosInfinitosDesact ();
		infiAnim.SetBool("LActivo",false);

		
	}
	public void LlanzarFalse(){
	
		infiAnim.SetBool("LLanzar",false);
	
	}


}
