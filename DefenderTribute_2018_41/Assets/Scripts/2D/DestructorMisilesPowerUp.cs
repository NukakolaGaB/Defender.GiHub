using UnityEngine;
using System.Collections;

public class DestructorMisilesPowerUp : MonoBehaviour {

	[SerializeField] bool derribaTodos;
	[SerializeField] int saludBarrera = 5;
	[SerializeField]Disparador2D disparador2D;


	SpriteRenderer spriteBarrera;

	[SerializeField]ParticleSystem particulasMuro;

	public TextMesh texto;

	// Use this for initialization
	void Start () {
		

		disparador2D = Accessos.disparador2D;
		if (!derribaTodos) {

			spriteBarrera = gameObject.GetComponent<SpriteRenderer> ();
			spriteBarrera.color = new Color (1, 1,1 , 0.75f);
			particulasMuro.startColor = spriteBarrera.color;
		}
	}
	void OnEnable(){
		

		if (!derribaTodos) {
			if(!Puntuaciones.dchaIzda){

					gameObject.transform.position=new Vector3(7f,1,0);

				}
				else{

					gameObject.transform.position=new Vector3(-7f,1,0);

				}


		}
	}

	public void RegenerarMuro(){


		saludBarrera = 3;
			spriteBarrera.color = new Color (1, 1, 1, 0.75f);
			particulasMuro.startColor = spriteBarrera.color;
	}
	void OnTriggerEnter2D (Collider2D col) {

			//Debug.Log(col.name);
			


		if (col.gameObject.tag == "misil") {
			DestruccionMisil2D misil = col.GetComponent<DestruccionMisil2D>();
			disparador2D.IncrementarProyDisparados();
			misil.ChocarContraProyectil ();
			if (derribaTodos) {
				//disparador2D.SumarPuntoJefe (misil.puntuacion);
				disparador2D.Sumarpunto (misil.puntuacion, transform.position);
			} else {
				disparador2D.Sumarpunto (misil.puntuacion, transform.position);
				saludBarrera--;
				ChequeaSalud ();
			}
		}
			
	}

	void ChequeaSalud () {
		
		spriteBarrera.color = new Color (1 , 0.5f * saludBarrera-0.5f,0.5f * saludBarrera-0.5f, 0.75f);
		particulasMuro.startColor = spriteBarrera.color;
		if (saludBarrera <= 0 ) {
			saludBarrera = 5;
			gameObject.SetActive (false);
		}
	}

}
