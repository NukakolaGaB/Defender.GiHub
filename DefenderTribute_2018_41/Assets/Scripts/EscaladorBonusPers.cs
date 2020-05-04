using UnityEngine;
using System.Collections;

public class EscaladorBonusPers : MonoBehaviour {

	[Tooltip("Esta es la escala que tendran para z=0")]
	public Vector3 tamanno = new Vector3 (1f, 1f, 1f);
	[Tooltip("Distancia a la que la escala se hace 0")]
	public float distanciaMax = 100f;
	public float escala = 1;

	// Use this for initialization
	void OnEnable () {
		//calcula la escala:
		escala = (distanciaMax - transform.position.z) / distanciaMax;
		//le aplica la escala
		transform.localScale = tamanno * escala;
	}
}
