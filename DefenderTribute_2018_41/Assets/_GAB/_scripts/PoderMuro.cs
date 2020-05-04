using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PoderMuro : MonoBehaviour {



	//canvas
	[SerializeField] Animator infiAnim;
	[SerializeField] GameObject muroEscena;
	[SerializeField] DestructorMisilesPowerUp destructorMisilesPowerUp;
	[SerializeField] Button botonMuro;




	public void ActivarBoton(){


		infiAnim.SetBool("LActivo",true);
		botonMuro.interactable = true;
	}
	public void LanzarMuro(){

		botonMuro.interactable = false;
		muroEscena.SetActive(true);
		destructorMisilesPowerUp.RegenerarMuro ();
		infiAnim.SetBool("LLanzar",true);
		Puntuaciones.poderMuro = false;


	}

	public void DesactivarBoton(){

		infiAnim.SetBool("LActivo",false);
		infiAnim.SetBool("LLanzar",false);

	}


}
