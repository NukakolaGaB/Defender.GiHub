using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class AsignadorTextosUpdate : MonoBehaviour {

	[SerializeField] Text campoTexto;
	[Multiline]
	[SerializeField] string [] textos = new string[3];
	//[SerializeField] TextAreaAttribute [] textos = new TextAreaAttribute[3];

	void Update(){
		campoTexto = GetComponent<Text> ();
		if (campoTexto != null) {
			campoTexto.text = textos [Idioma.elegido];
		}
	}

}
