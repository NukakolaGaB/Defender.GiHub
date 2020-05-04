using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GetionTextosPuertasLoading : MonoBehaviour {

	[SerializeField]GameObject[] textos;
	float contador = 3f;
	int i=0;
	//public Text cuentaAtras;

	// Use this for initialization
	void Start () {

		i = Random.Range (0, textos.Length);
		textos[i].SetActive(true);

	}
	
	// Update is called once per frame
	void Update () {
		//cuentaAtras.text = contador.ToString();
		if (contador > 0) {
		
			contador -= Time.deltaTime;
		
		
		}
		else {
		
			contador=3f;
			if(i>=textos.Length-1){

				textos[i].SetActive(false);
				i=0;
				textos[i].SetActive(true);
			}
			else{

				textos[i].SetActive(false);
				i++;
				textos[i].SetActive(true);

			}
		
		}
				

	}
}
