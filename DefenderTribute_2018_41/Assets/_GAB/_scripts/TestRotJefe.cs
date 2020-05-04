using UnityEngine;
using System.Collections;

public class TestRotJefe : MonoBehaviour {

	//[SerializeField] GameObject [] spritesJefe;
	float tiempo;
	//public int indice;
	Transform myTransform;

	[SerializeField] ControladorMisiones controlador;

	public float distanciaMax = 100f;
	public float escala = 1;
	public Animator jefePadreAnimator;
	public Vector3 tamanno = new Vector3 (1f, 1f, 1f);
	[SerializeField] ParticleSystem particulas;
	[SerializeField] GameObject particulasDanno;
	public ParticleSystem particulasDannoComp;
	public GameObject exploUnitMuerteJefe;
	PolygonCollider2D polyCollider;
	public SpriteRenderer spriteJefe;


	[Tooltip("velocidad lateral de la nava")]
	[SerializeField] float velAcercaAleja;
	Vector3 movAcercaAleja;
	[Tooltip("velocidad vertical de la nava")]
	[SerializeField] float velArribaAbajo;
	Vector3 movArribaAbajo;
	[Tooltip("velocidad de avance de la nava")]
	[SerializeField] float velIzdaDcha;
	Vector3 movIzdaDcha;

	[Tooltip("cada cuanto tiempo hace cambio de direccion")]
	[SerializeField] float tiempoManiobra;
	[SerializeField] float tiempoManiobraMin;
	[SerializeField] float tiempoManiobraMax;

	float maxX;
	float minX = -5f;
	float maxY;
	float minY = 0f;
	float maxZ;
	float minZ = 30f;

	bool acerca;
	bool aleja;
	bool izdaDcha;
	bool dchaIzda;
	bool subir;
	bool bajar;

	public int vida;
	[Tooltip ("Tiempo maximo entre disparos")]
	public float rangoM;
	[Tooltip ("Tiempo minimo entre disparos")]
	public float rangoMin;
	[Tooltip ("Tiempo maximo entre disparos")]
	public float rangoMax;
	[Tooltip ("Hasta Cuanto se puede acercar al borde dcho de la pantalla 0: facil, 2: dificil")]
	[SerializeField] float limiteDerecha = 2f;
	int n;
	int fuerte;
	int tocado;
	int semiFuerte;
	int debil;

	[SerializeField] GameObject cohete;
	[SerializeField] Transform spawPointMisiles;
	public GameObject lanzado;
	public AudioSource sonidoMisil;

	// Use this for initialization
	void Start () {

		controlador = Accessos.controladorMisiones;

		myTransform = transform;
		particulas.startSize *= escala;
		n = vida;
		fuerte = n;
		//Debug.Log(fuerte);
		tocado = fuerte/2;
		//Debug.Log(tocado);
		semiFuerte = fuerte/3;
		//Debug.Log(semiFuerte);
		debil = fuerte/4;
		//Debug.Log(debil);
		//polyCollider= gameObject.AddComponent<PolygonCollider2D>() as PolygonCollider2D;

	}

	void OnEnable () {

		Invoke ("LanzarMisil", 3f);
		EmpIzdaDcha ();
		Puntuaciones.capa = Random.Range (3, 9);
	}

	// Update is called once per frame
	void Update () {

//		tiempo += Time.deltaTime;
//		if (tiempo < 2 ) {
//			
//			transform.position -= Time.deltaTime * velocidad/3 * Vector3.left;
//		}
//		else if (tiempo > 2 && tiempo < 3) {
//
//			transform.position += Time.deltaTime * velocidad * Vector3.forward;
//			jefePadreAnimator.SetBool ("EmpAlejarse", true);
//		} 
//		else if (tiempo > 3 && tiempo < 5) {
//			jefePadreAnimator.SetBool ("EmpAlejarse", false);
//			jefePadreAnimator.SetBool ("TermAlejarse", true);
//			transform.position += Time.deltaTime  * new Vector3 (0,Random.Range (-1,1),0) ;
//		} 
//		else if (tiempo > 4 && tiempo < 6) {
//			jefePadreAnimator.SetBool ("TermAlejarse", false);
//			jefePadreAnimator.SetBool ("EmpAcercarse", true);
//			transform.position -= Time.deltaTime * velocidad * Vector3.forward;
//			//jefePadreAnimator.SetBool ("Quieto", true);
//		}
//		else if (tiempo > 6 && tiempo < 8) {
//
//			jefePadreAnimator.SetBool ("EmpAcercarse", false);
//			jefePadreAnimator.SetBool ("TermAcercarse", true);
//			//transform.position = transform.position;
//		} 
//		else if (tiempo > 8 && tiempo < 11) {
//			jefePadreAnimator.SetBool ("TermAcercarse", false);
//			transform.position -= Time.deltaTime  * new Vector3 (0,Random.Range (-1,1),0) ;
//		
//		}
//		else if (tiempo > 12 && tiempo< 14 ) {
//			
//			transform.position += Time.deltaTime * velocidad/3 * Vector3.left;
//
//		}
//		else if(tiempo>14){
//			tiempo = 0;
//
//		}

		tiempo += Time.deltaTime;

		if (tiempo > tiempoManiobra) {
			tiempo = 0;
			tiempoManiobra = Random.Range (tiempoManiobraMin, tiempoManiobraMax);
			AlAzar();
			maxX = Random.Range (-3f, limiteDerecha);
			maxY = Random.Range (0f, 3.5f);
			maxZ = Random.Range (40f, 81f);
		}

		CambiarLayer (myTransform.position.z);
		if (myTransform.position.z < distanciaMax) {
			myTransform.localScale = tamanno * (distanciaMax - myTransform.position.z) / distanciaMax;
		}


		if (myTransform.position.x > maxX) {
			if (izdaDcha) {
				TermIzdaDcha ();
			} else {
//				Invoke ("EmpDchaIZda", 0.5f);
			}
		} else if (myTransform.position.x < minX) {
			if (dchaIzda) {
				TermDchaIzda();
			}
//			Invoke ("EmpIzdaDcha", 0.5f);
		}
		if (myTransform.position.y > maxY) {
			if (subir) {
				TermSubir ();
			} else {
//				Invoke ("EmpBajar", 0.5f);
			}
		} else if (myTransform.position.y < minY) {
			if (bajar ) {
				TermBajar ();
			} else {
//				Invoke ("EmpSubir", 0.5f);
			}
		}
		if (myTransform.position.z > maxZ) {
			if (aleja) {
				TermAlejarse ();
			} else {
//				Invoke ("EmpAcercarse", 1.5f);
			}
		} else if (myTransform.position.z < minZ) {
			if (acerca) {
				TermAcercarse();
			} else {
//				Invoke ("EmpAlejarse", 1.5f);
			}
		}

		myTransform.position += Time.deltaTime * (movAcercaAleja + movIzdaDcha + movArribaAbajo);


	}

	void EmpAlejarse () {
		jefePadreAnimator.SetBool ("TermAlejarse", false);
		jefePadreAnimator.SetBool ("EmpAlejarse", true);
		movAcercaAleja = velAcercaAleja * Vector3.forward;
		aleja = true;
	}
	void TermAlejarse () {
		jefePadreAnimator.SetBool ("EmpAlejarse", false);
		jefePadreAnimator.SetBool ("TermAlejarse", true);
		movAcercaAleja = Vector3.zero;
		aleja = false;
	}
	void EmpAcercarse () {
		jefePadreAnimator.SetBool ("TermAcercarse", false);
		jefePadreAnimator.SetBool ("EmpAcercarse", true);
		movAcercaAleja = velAcercaAleja * Vector3.back;
		acerca = true;
	}
	void TermAcercarse () {
		jefePadreAnimator.SetBool ("EmpAcercarse", false);
		jefePadreAnimator.SetBool ("TermAcercarse", true);
		movAcercaAleja = Vector3.zero;
		acerca = false;
	}
	void EmpSubir () {
		movArribaAbajo = velArribaAbajo * Vector3.up;
		subir = true;
	}
	void TermSubir () {
		movArribaAbajo = Vector3.zero;
		subir = false;
	}
	void EmpBajar () {
		movArribaAbajo = velArribaAbajo * Vector3.down;
		bajar = true;
	}
	void TermBajar () {
		movArribaAbajo = Vector3.zero;
		bajar = false;
	}
	void EmpIzdaDcha () {
		movIzdaDcha = velIzdaDcha * Vector3.right;
		izdaDcha = true;
	}
	void TermIzdaDcha () {
		movIzdaDcha = Vector3.zero;
		izdaDcha = false;
	}
	void EmpDchaIZda () {
		movIzdaDcha = velIzdaDcha * Vector3.left;
		dchaIzda = true;
	}
	void TermDchaIzda () {
		movIzdaDcha = Vector3.zero;
		dchaIzda = false;
	}
	

	void AlAzar () {
		int azar = Random.Range (0, 6);
		switch (azar) {
		case 0:
			if (bajar) {
				TermBajar();
			} else {
				EmpSubir();
			}
			break;
		case 1:
			if (subir) {
				TermSubir();
			} else {
				EmpBajar();
			}
			break;
		case 2:
			if (dchaIzda) {
				TermDchaIzda();
			} else {
				EmpIzdaDcha();
			}
			break;
		case 3:
			if (izdaDcha) {
				TermIzdaDcha();
			} else {
				EmpDchaIZda();
			}
			break;
		case 4:
			if (aleja) {
				TermAlejarse();
			} else {
				EmpAcercarse();
			}
			break;
		case 5:
			if (acerca) {
				TermAcercarse();
			} else {
				EmpAlejarse();
			}
			break;
		}
	}


	public void NuevoPolycollider(){

		Destroy(polyCollider);
		polyCollider= gameObject.AddComponent<PolygonCollider2D>() as PolygonCollider2D;
		polyCollider.isTrigger=true;

	}
	void CambiarLayer (float z) {
		if (z < 30f) {
			gameObject.layer = Tags.capa3;
		} else if (z > 30 && z < 40) {
			gameObject.layer = Tags.capa4;
		} else if (z > 40 && z < 50) {
			gameObject.layer = Tags.capa5;
		} else if (z > 50 && z < 60) {
			gameObject.layer = Tags.capa6;
		} else if (z > 60 && z < 70) {
			gameObject.layer = Tags.capa7;
		} else   {
			gameObject.layer = Tags.capa8;
		} 
	}



	void LanzarMisil () {

		if(!aleja && !acerca){

			lanzado = SimplePool.Spawn (cohete, spawPointMisiles.position, myTransform.rotation) as GameObject;
			lanzado.layer = gameObject.layer;
			sonidoMisil.enabled=true;
			lanzado.GetComponent<DestruccionMisil2D>().DesactivarEscudo();
			lanzado.GetComponent<VelocidadInicial> ().Parado();
			lanzado.GetComponent<BoxCollider2D>().enabled=false;
			Invoke("ActivarColliderMisil",0.5f);

		}
		if (vida > 10 ) {
			Invoke ("LanzarMisil",  Random.Range(rangoMin,rangoMax));

		}
	}
	public void ActivarColliderMisil(){

		//collider.enabled=true;
		lanzado.GetComponent<BoxCollider2D>().enabled=true;
		sonidoMisil.enabled=false;


	}

	public void RecibirDisparo () {

			n--;
			//Debug.Log(n);
			vida = n;
			//Debug.Log(semiFuerte);
			AlAzar();
			if(vida < tocado && vida > semiFuerte){
				
				//Debug.Log("semiFuerte = "+semiFuerte);
				particulasDanno.SetActive(true);
				particulasDannoComp.emissionRate=10;
				spriteJefe.color=new Color (0.8f,0.7f,0.7f,1f);
				
			}
			else if(vida < semiFuerte && vida > debil){

				//Debug.Log("semiFuerte = "+semiFuerte);
				particulasDanno.SetActive(true);
				particulasDannoComp.emissionRate=100;
				spriteJefe.color=new Color (0.8f,0.5f,0.5f,1f);
				rangoM=3;
			}
			else if(vida < debil && vida > 0){
				//Debug.Log("debil = "+debil);
				particulasDanno.SetActive(true);
				particulasDannoComp.emissionRate=350;
				spriteJefe.color=new Color (1f,0.35f,0.3f,1f);
				velIzdaDcha=20;

				
			}
			else if(vida<=0){

				//Debug.Log("muerto ");
				//vivo=false;
				particulasDanno.SetActive(false);
//				gameObject.SetActive(false);
				GameObject explo = SimplePool.Spawn(exploUnitMuerteJefe,transform.position, transform.rotation) as GameObject;
				controlador.MuerteJefeFinal ();
			gameObject.SetActive (false);
			}
	}
}
