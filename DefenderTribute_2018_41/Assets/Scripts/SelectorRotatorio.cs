using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SelectorRotatorio : MonoBehaviour {

	public Transform centro;
	public Transform selector;
	Selector selectorS;

	bool cogido;
	public bool seleccionado;
//	public bool seleccionadoDefinitivo;
	public bool seleccionable;
	public int nivel;

	Vector2 pos;

	public Image imagen;
	public Text texto;

	public Button historia;
	public AudioSource ruletaClick;
	public AudioClip clickSonido;

	public Color colorSeleccionable;
	public Color colorNoSeleccionable;
	public Color colorTextoSeleccionable;
	public Color colorTextoNoSeleccionable;
	public Color colorSeleccionado;

	float n=0;


	// Use this for initialization
	void Start () {

//		centro = transform.parent;
//		selector = centro.parent;
		selectorS = selector.GetComponent<Selector> ();
//		Image imagen = GetComponent<Image> ();
		if (imagen != null) {
//			imagen.enabled = seleccionable;
			if (seleccionable) {
				imagen.color = colorSeleccionable;
			} else {
				imagen.color = colorNoSeleccionable;
			}
		}
//		Text texto = GetComponentInChildren<Text> ();
		if (texto != null) {
//			texto.enabled = seleccionable;
			if (seleccionable) {
				texto.color = colorTextoSeleccionable;
			} else {
				texto.color = colorTextoNoSeleccionable;
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
			
		if (Input.GetMouseButton (0) && (Input.mousePosition - transform.position).magnitude < 25f) {
			cogido = true;
			historia.interactable=false;
		}
		if (Input.GetMouseButtonUp (0)) {
			cogido = false;
			historia.interactable=true;
			if (seleccionable && (selector.position - transform.position).magnitude < 75f) {
//				seleccionado = true;
				selectorS.Seleccionar (this);
			} else {
//				seleccionado = false;
			}
		}
		if (cogido) {
			pos = transform.InverseTransformDirection(transform.position - Input.mousePosition);
			centro.RotateAround (centro.position, centro.forward, pos.x * Time.deltaTime * 5);
		}	

		if (seleccionado) {

			n++;
			pos = transform.position - selector.position;
			centro.RotateAround (centro.position, centro.forward, pos.x * Time.deltaTime);

			if(n<=1){

				ruletaClick.PlayOneShot(clickSonido);

			}
		}else{

			n=0;
		}


//		if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved) {
//			// Get movement of the finger since last frame
//			Vector2 touchDeltaPosition = Input.GetTouch(0).deltaPosition;
//			Vector2 tt = transform.InverseTransformDirection(touchDeltaPosition);
//
//			centro.transform.RotateAround (centro.transform.position, centro.transform.up, tt.x);
//		}
	}
	public void ApagarSonido(){
		ruletaClick.enabled=false;
	}


//	public void Rotar () {
//
//		Vector2 touchDeltaPosition = Input.GetTouch(0).deltaPosition;
//		Vector2 tt = transform.InverseTransformDirection(touchDeltaPosition);
//		
//		centro.transform.RotateAround (centro.transform.position, centro.transform.up, tt.x);
//	}
	
}
