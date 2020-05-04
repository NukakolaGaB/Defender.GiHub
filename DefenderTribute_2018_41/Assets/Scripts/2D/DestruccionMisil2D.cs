using UnityEngine;
using System.Collections;

public class DestruccionMisil2D : MonoBehaviour {
	
	[SerializeField]AudioSource audioExplosionAlcanzado;
	[Tooltip("Clip de explosion (pequeña) al ser alcanzado por disparo")]
	[SerializeField] AudioClip explosion2;
	[Tooltip("prefab con sprite de la explosion")]
	[SerializeField] GameObject exploUnit;
	public GameObject escudo;
	public AudioSource exploEscudo;

	[SerializeField] GameObject radar;

	public float escala = 1f;

	public int puntuacion;

	public bool misilDeJEfe;

	void OnEnable () {
		puntuacion = 1000 * (Puntuaciones.capa - 2);
	}
	void OnTriggerEnter2D (Collider2D choca) {
		
		if (choca.gameObject.name == "DanoDeMisiles2D") {
			Handheld.Vibrate();
			SimplePool.Despawn(gameObject);
			choca.gameObject.GetComponent<DanoDeMisiles>().Impacto();

		}
		
		
	}

	public void ActivarEscudo () {
		escudo.SetActive (true);
	}
	public void DesactivarEscudo () {
		escudo.SetActive (false);
	}
	
	public void ChocarContraProyectil () {
		audioExplosionAlcanzado.PlayOneShot (explosion2);
		#region crear explosion
		GameObject explo = SimplePool.Spawn(exploUnit, transform.position, transform.rotation)as GameObject;
		explo.GetComponent<ExploUnitScale>().Escala = escala;
		Vector2 velocidad=GetComponent<Rigidbody2D> ().velocity ;
		explo.GetComponent<ExploUnitScale>().Sentido(velocidad);

		#endregion

		SimplePool.Despawn(gameObject);
	}
	
	void Destruir () {
		radar.GetComponent<Animator>().SetBool("Explota", false);
		SimplePool.Despawn(gameObject);

	}
}
