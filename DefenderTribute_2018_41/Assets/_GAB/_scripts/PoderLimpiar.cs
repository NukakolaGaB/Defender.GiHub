using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PoderLimpiar : MonoBehaviour {



	//canvas
	[SerializeField] Animator infiAnim;
	[SerializeField] GameObject limpiar;
	[SerializeField] PanelLimpiar panellimpiar;
	[SerializeField] Button botonLimpiar;




	public void ActivarBoton(){
		

		infiAnim.SetBool("LActivo",true);
		botonLimpiar.interactable = true;

	}
	public void LanzarMuro(){

		panellimpiar.Activar();
		limpiar.SetActive (true);
		infiAnim.SetBool("LLanzar",true);
		Accessos.disparador2D.DisparosInfinitos ();
		Puntuaciones.poderLimpia = false;
		botonLimpiar.interactable = false;

	}
//	public void DesactivarLimpiar(){
//
//		limpiar.SetActive (false);
//		infiAnim.SetBool("LLanzar",true);
//		Accessos.disparador2D.DisparosInfinitos ();
//
//	}
	public void DesactivarLimpiar(){

		limpiar.SetActive (false);
		Accessos.disparador2D.DisparosInfinitosDesact ();
		infiAnim.SetBool("LActivo",false);
		infiAnim.SetBool("LLanzar",false);
		
	}


}
