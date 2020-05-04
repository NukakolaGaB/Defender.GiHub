using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;


//[ExecuteInEditMode]

public class ForzarModulo : MonoBehaviour {

	[SerializeField] StandaloneInputModule  standaloneInputModule;
	// Use this for initialization
	void Start () {

		if (Application.isEditor) {

			standaloneInputModule = GetComponent<StandaloneInputModule> ();
			standaloneInputModule.forceModuleActive = true;

		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
