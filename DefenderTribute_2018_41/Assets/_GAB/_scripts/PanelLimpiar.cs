using UnityEngine;
using System.Collections;

public class PanelLimpiar : MonoBehaviour {
	
	[SerializeField] Animator pLimpAnim;


	// Use this for initialization
	public void Activar () {
		
		pLimpAnim.SetBool("Activo",true);
	}
	
	// Update is called once per frame
	public void Desactivar () {
	
		pLimpAnim.SetBool("Activo",false);
	}
}
