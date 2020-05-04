using UnityEngine;
using System.Collections;

public class LanzaMisiles2D : MonoBehaviour {

	public ControladorMisiones controladorMisiones;


	GameObject cohete;
	public GameObject prefabCohete;
	public GameObject prefabCoheteReves;

	public GameObject prefabBonusPersecucion;
	public GameObject prefabBonusVirus;
	public GameObject exploUnitMuerteJefe;

	GameObject lanzado;
	GameObject bonusV;
	GameObject bonusP;
	BonusPersecucion bonusPersecucion;

	float xLanzamiento = 20f;
	
	float tiempo = 2.50f;

	[Tooltip("Para restringir la Y minima de las 2 ultimas capas (entre -1.66 y 3.57)")]
	[SerializeField] float limiteInferiorUltimascapas = 0.5f;


	public bool igual;


	[Tooltip("Cuantos misiles lanza")]
	public int misilesPorLanzar;

	int capa = 3;


	[Tooltip("Si cada vez lanza un misil de la siguiente capa o elige capa al azar")]
	public bool capasProgresivas;
	
	// Use this for initialization
	void Awake () {

		Accessos.lanzaMisiles2D = this;
		if (Puntuaciones.dchaIzda) {
			xLanzamiento = 20f;
//			sentido = -1;
			cohete = prefabCohete;
		} else {
			xLanzamiento = -20f;
//			sentido = 1;
			cohete = prefabCoheteReves;
		}
		SimplePool.Preload(cohete, 3);
		SimplePool.Preload (prefabBonusPersecucion, 1);
		SimplePool.Preload (prefabBonusVirus, 1);
		SimplePool.Preload (exploUnitMuerteJefe, 1);
	}
	
	#region update
	// Update is called once per frame
	void Update () {
		if (tiempo >= Puntuaciones.tiempoLanzar) {
			
			LanzarCohete (capa);

			if (Puntuaciones.randomCapa) {
				capa = Random.Range (3, Puntuaciones.ultimaCapa +1);
			} else {
				if (capa >= Puntuaciones.ultimaCapa) {
					capa = 3;
				} else {
					capa++;
				}
			}
			tiempo = 0;
		} else {
			tiempo += Time.deltaTime;
		}
		
	}
	#endregion
	
	#region funciones lanzar misiles

	void LanzarCohete (int cap) {

		Puntuaciones.capa = cap;

		if (misilesPorLanzar > 0) {

			cap = Mathf.Clamp (cap, 3, 9);

				if (cap < 8) {
					lanzado = SimplePool.Spawn(cohete,  new Vector3 (xLanzamiento, Random.Range (-1.2f, 3.57f), cap * 10f), transform.rotation) as GameObject;

					float n = Random.Range(0,5);
					if(n<Puntuaciones.cantEscudos){
						lanzado.GetComponent<DestruccionMisil2D>().ActivarEscudo();
					}
					else{
						lanzado.GetComponent<DestruccionMisil2D>().DesactivarEscudo();
					}
				} else {
					lanzado = SimplePool.Spawn(cohete, new Vector3 (xLanzamiento, Random.Range (limiteInferiorUltimascapas, 3.57f), cap * 10f), transform.rotation) as GameObject;

				}
	
			lanzado.layer = (cap + 10);


			misilesPorLanzar--;
			controladorMisiones.misilesEnVuelo++;
			if (misilesPorLanzar <= 0) {
				controladorMisiones.LanzadoUltimoMisil ();
			}
		}
	}

	#endregion

	#region lanzar BonusPersecucion

	public void LanzaBonusPersecucion (int cap) {

		if (Puntuaciones.dchaIzda) {
			bonusP = SimplePool.Spawn (prefabBonusPersecucion, new Vector3 (xLanzamiento, Random.Range (1f, 2f),  cap * 10f), Quaternion.Euler(180* Vector3.up)) as GameObject;
			bonusPersecucion = bonusP.GetComponent<BonusPersecucion>();
			bonusPersecucion.danoDeMisiles = controladorMisiones.danoDeMisiles;

			bonusV = SimplePool.Spawn (prefabBonusVirus, bonusP.transform.position + bonusPersecucion.distancia * Vector3.right, bonusP.transform.rotation) as GameObject;

		} else {
			bonusP = SimplePool.Spawn (prefabBonusPersecucion, new Vector3 (xLanzamiento, Random.Range (1f, 2f),  cap * 10f), Quaternion.identity) as GameObject;
			bonusPersecucion = bonusP.GetComponent<BonusPersecucion>();
			bonusPersecucion.danoDeMisiles = controladorMisiones.danoDeMisiles;

			bonusV = SimplePool.Spawn (prefabBonusVirus, bonusP.transform.position - bonusPersecucion.distancia * Vector3.right, bonusP.transform.rotation) as GameObject;


		}
		PerseguidorBonus perseguidorBonus = bonusV.GetComponent<PerseguidorBonus>();
		perseguidorBonus.danoDeMisiles = controladorMisiones.danoDeMisiles;
		perseguidorBonus.perseguido = bonusP.transform;
		perseguidorBonus.distancia = bonusPersecucion.distancia;
		bonusPersecucion.perseguidor = bonusV;
		perseguidorBonus.bonusPersecucion=bonusPersecucion;
		bonusP.layer = (cap + 10);
		bonusV.layer = cap + 10;
		perseguidorBonus.TipoRecompensa (0);
		bonusPersecucion.CambiarSpriteProteus (0);

	}

	public void LanzaBonusPersecucion (int cap,int recompensa) {

		if (Puntuaciones.dchaIzda) {
			bonusP = SimplePool.Spawn (prefabBonusPersecucion, new Vector3 (xLanzamiento, Random.Range (1f, 2f),  cap * 10f), Quaternion.Euler(180* Vector3.up)) as GameObject;
			bonusPersecucion = bonusP.GetComponent<BonusPersecucion>();
			bonusPersecucion.danoDeMisiles = controladorMisiones.danoDeMisiles;

			bonusV = SimplePool.Spawn (prefabBonusVirus, bonusP.transform.position + bonusPersecucion.distancia * Vector3.right, bonusP.transform.rotation) as GameObject;

		} else {
			bonusP = SimplePool.Spawn (prefabBonusPersecucion, new Vector3 (xLanzamiento, Random.Range (1f, 2f),  cap * 10f), Quaternion.identity) as GameObject;
			bonusPersecucion = bonusP.GetComponent<BonusPersecucion>();
			bonusPersecucion.danoDeMisiles = controladorMisiones.danoDeMisiles;

			bonusV = SimplePool.Spawn (prefabBonusVirus, bonusP.transform.position - bonusPersecucion.distancia * Vector3.right, bonusP.transform.rotation) as GameObject;


		}
		PerseguidorBonus perseguidorBonus = bonusV.GetComponent<PerseguidorBonus>();
		perseguidorBonus.danoDeMisiles = controladorMisiones.danoDeMisiles;
		perseguidorBonus.perseguido = bonusP.transform;
		perseguidorBonus.distancia = bonusPersecucion.distancia;
		bonusPersecucion.perseguidor = bonusV;
		perseguidorBonus.bonusPersecucion=bonusPersecucion;
		bonusP.layer = (cap + 10);
		bonusV.layer = cap + 10;
		perseguidorBonus.TipoRecompensa (recompensa);
		bonusPersecucion.CambiarSpriteProteus (recompensa);


	}
	
	#endregion
}
