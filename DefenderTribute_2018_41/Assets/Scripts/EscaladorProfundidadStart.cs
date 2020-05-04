using UnityEngine;
using System.Collections;

/// <summary>
/// Cambia la escala solo en Start.
/// </summary>
public class EscaladorProfundidadStart : MonoBehaviour {
	
	[Tooltip("Esta es la escala que tendran para z=0")]
	public Vector3 tamanno = new Vector3 (1f, 1f, 1f);
	[Tooltip("Distancia a la que la escala se hace 0")]
	public float distanciaMax = 100f;
	public float escala = 1;
	[SerializeField] GameObject radar;
	//Vector3 escalaRadarInicial;
	[SerializeField] ParticleSystem particulas;
	public float TamanoInicial=0.42f;

	// Use this for initialization
	void Awake(){

		TamanoInicial=0.42f;
		//Debug.Log("Start size de las particulas"+TamanoInicial);
		//Debug.Log("EscaLA"+escala);
	}

	

	void OnEnable(){

		//calcula la escala:
		escala = (distanciaMax - transform.position.z) / distanciaMax;
		escala=Mathf.Clamp(escala,0.2f,1f);
		//le aplica la escala
		//Debug.Log(escala);
		transform.localScale = tamanno * escala;
		//para que destruccionMisil2D sepa a que escala crear las explosiones;
		GetComponent<DestruccionMisil2D> ().escala = escala;
		//hace que las particulas se generen con la escala adecuada:
		particulas.startSize *= escala*2;
		//para que todos se vean del mismo tamaño en el radar (deshace la aplicacion de escala en radar):
		radar.transform.localScale = new Vector3 (11/escala, 6/escala, 1/escala);


	}
	void OnDisable() {
		//calcula la escala:
		escala = 1;
		//le aplica la escala
		//Debug.Log(escala);
		transform.localScale = tamanno * escala;
		//para que destruccionMisil2D sepa a que escala crear las explosiones;
		GetComponent<DestruccionMisil2D> ().escala = escala;
		//hace que las particulas se generen con la escala adecuada:
		//Debug.Log("Start size de las particulas"+particulas.startSize);
		//particulas.startSize = TamanoInicial;
		particulas.startSize = TamanoInicial;
		//para que todos se vean del mismo tamaño en el radar (deshace la aplicacion de escala en radar):
		//radar.transform.localScale = escalaRadarInicial;
	}
//	void Start () {
//		//calcula la escala:
//		escala = (distanciaMax - transform.position.z) / distanciaMax;
//		//le aplica la escala
//		transform.localScale = tamanno * escala;
//		//para que destruccionMisil2D sepa a que escala crear las explosiones;
//		GetComponent<DestruccionMisil2D> ().escala = escala;
//		//hace que las particulas se generen con la escala adecuada:
//		GetComponentInChildren<ParticleSystem> ().startSize *= escala;
//		//para que todos se vean del mismo tamaño en el radar (deshace la aplicacion de escala en radar):
//		radar.transform.localScale = new Vector3 (11/escala, 6/escala, 1/escala);
//	}
//	public void Escalando(){
//
//
//		//calcula la escala:
//		escala = (distanciaMax - transform.position.z) / distanciaMax;
//		//le aplica la escala
//		Debug.Log(escala);
//		transform.localScale = tamanno * escala;
//		//para que destruccionMisil2D sepa a que escala crear las explosiones;
//		GetComponent<DestruccionMisil2D> ().escala = escala;
//		//hace que las particulas se generen con la escala adecuada:
//		GetComponentInChildren<ParticleSystem> ().startSize *= escala;
//		//para que todos se vean del mismo tamaño en el radar (deshace la aplicacion de escala en radar):
//		radar.transform.localScale = new Vector3 (11/escala, 6/escala, 1/escala);
//		activo=false;
//	}
	
}
