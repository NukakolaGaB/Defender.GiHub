using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Letra : MonoBehaviour {

    [SerializeField] string letras = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
	[SerializeField] char[] alpha;
	int i = 0;
	[SerializeField] Text mytext;
	string [] beta;

	// Use this for initialization
	void Start () {
        alpha = letras.ToCharArray();
        Debug.Log("Alpha[i] = " + alpha);
        mytext.text = alpha [i].ToString();
        
		beta = new string[alpha.Length + 1];
		for (int j = 0; j < alpha.Length; j++) {
			beta [j] = alpha [j].ToString();
		}
		beta [alpha.Length] = " ";
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public void Subir () {
		if (i == beta.Length -1) {
			i = 0;
		} else {
			i++;
		}
		mytext.text = beta [i];
	}
	public void Bajar () {
		if (i == 0) {
			i = beta.Length - 1;
		} else {
			i--;
		}
		mytext.text = beta [i];
	}
}
