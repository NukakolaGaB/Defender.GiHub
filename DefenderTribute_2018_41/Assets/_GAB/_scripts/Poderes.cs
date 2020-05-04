using UnityEngine;
using System.Collections;

public class Poderes : MonoBehaviour {

	[SerializeField] PoderInfinito poderInfinito;
	[SerializeField] PoderLimpiar poderLimpiar;
	[SerializeField] PoderMuro poderMuro;
	[SerializeField] AudioSource botonSale;


	void Awake(){

		Accessos.poderes = this;

	}

	public void ActivarBotonLimpia(){

		poderLimpiar.ActivarBoton();
		botonSale.Play();
		Puntuaciones.poderLimpia = true;

	}
	public void ActivarBotonMuro(){
		
		poderMuro.ActivarBoton();
		botonSale.Play();
		Puntuaciones.poderMuro = true;

	}
	public void ActivarBotonInfin(){
		
		poderInfinito.ActivarBoton();
		botonSale.Play();
		Puntuaciones.poderInfinito = true;

	}




}
