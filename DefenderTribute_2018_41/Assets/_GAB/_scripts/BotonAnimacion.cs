using UnityEngine;
using System.Collections;

public class BotonAnimacion : MonoBehaviour {

	public Animator animatorBoton;

	public void PlayAnimacionBoton(){

		animatorBoton=gameObject.GetComponent<Animator>();
		animatorBoton.SetBool("Pulsado",true);
	}
}
