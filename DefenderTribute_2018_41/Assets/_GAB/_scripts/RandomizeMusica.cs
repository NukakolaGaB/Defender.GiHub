using UnityEngine;
using System.Collections;

public class RandomizeMusica : MonoBehaviour {

	[SerializeField] AudioClip musica1;
	[SerializeField] AudioClip musica2;
	[SerializeField] AudioClip musica3;
	[SerializeField] AudioClip musica4;

	[SerializeField] AudioSource musicaSource;


	// Use this for initialization
	void Awake () {

		Accessos.randomizeMusica = this;
		musicaSource=gameObject.GetComponent<AudioSource>();
		ElegirMusica ();
	}
	public void ElegirMusica(){

		musicaSource.enabled=false;
		if(Puntuaciones.nivel<10){
			
			musicaSource.clip = musica1;
		
			
			
		}
		else{ 
			
			if(Puntuaciones.nivel<20){
				
				musicaSource.clip = musica2;

			}
			else {
				
				if(Puntuaciones.nivel<30){
					
					musicaSource.clip=musica3;

				}
				else{
					
					musicaSource.clip=musica4;

					
				}
				
			}
		}

		musicaSource.enabled=true;
		
	}

}
