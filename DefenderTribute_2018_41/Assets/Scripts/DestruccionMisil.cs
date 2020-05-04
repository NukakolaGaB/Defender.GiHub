using UnityEngine;
using System.Collections;

public class DestruccionMisil : MonoBehaviour {

	AudioSource audioExplosionAlcanzado;
	[SerializeField] AudioClip explosion1;
	[SerializeField] AudioClip explosion2;

	[SerializeField] GameObject exploUnit;
	int num;



	// Use this for initialization
	void Start () {
		audioExplosionAlcanzado = gameObject.GetComponent<AudioSource> ();
	}

	void OnCollisionEnter (Collision choca) {

		if (choca.gameObject.name == "DanoDeMisiles") {
			audioExplosionAlcanzado.PlayOneShot (explosion1);
		} else {
			audioExplosionAlcanzado.PlayOneShot (explosion2);
			num = Random.Range (3, 6);
			for (int i = 0; i < num; i++) {
				GameObject explo = Instantiate (exploUnit, new Vector3 (transform.position.x, transform.position.y + Random.Range (-0.35f, 0.35f), transform.position.z + Random.Range (0f, 0.15f)), transform.rotation) as GameObject;
				explo.transform.SetParent (gameObject.transform);
			}
			GetComponent<Rigidbody> ().velocity = -1.5f * GetComponent<Rigidbody> ().velocity;
		}
		GetComponent<SpriteRenderer> ().enabled = false;
		GetComponent<Collider> ().enabled = false;
		Invoke ("Destruir", 4.55f);
//		GetComponent<Rigidbody> ().velocity = -1.5f * GetComponent<Rigidbody> ().velocity;
	}

	void Destruir () {
		Destroy (gameObject);
	}
}
