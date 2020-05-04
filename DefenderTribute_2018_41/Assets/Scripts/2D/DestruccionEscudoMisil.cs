using UnityEngine;
using System.Collections;

public class DestruccionEscudoMisil : MonoBehaviour {
	
	AudioSource audioExplosionAlcanzado;
	[Tooltip("Clip de explosion (grande) contra defendido")]
	[SerializeField] AudioClip explosion1;
	[Tooltip("Clip de explosion (pequeña) al ser alcanzado por disparo")]
	[SerializeField] AudioClip explosion2;
	[Tooltip("prefab con sprite de la explosion")]
	[SerializeField] GameObject exploUnit;

	public float escala = 1f;

	public int puntuacion;

	// Use this for initialization
	void Start () {
		audioExplosionAlcanzado = gameObject.GetComponent<AudioSource> ();
	}

	void OnTriggerEnter2D (Collider2D choca) {
		
		if (choca.gameObject.name == "DanoDeMisiles2D") {
			audioExplosionAlcanzado.PlayOneShot (explosion1);
			choca.gameObject.GetComponent<DanoDeMisiles>().Impacto();
			Invoke ("Destruir", 0f);
		}
	}
	
	public void ChocarContraProyectil () {
		audioExplosionAlcanzado.PlayOneShot (explosion2);
		//para que ya no choque con nada:
		GetComponent<Collider2D> ().enabled = false;
		//esperamos un poco a destruirlo del todo para que suene y se vea la explosion:
		Invoke ("Destruir", 1f);
	}
	
	void Destruir () {
		//Destroy (gameObject);
		SimplePool.Despawn(gameObject);
	}
}
