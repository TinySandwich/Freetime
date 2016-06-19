using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class FieldTab : MonoBehaviour {

	public Selectable prev;
	public Selectable next;
	private EventSystem system;

	// Use this for initialization
	void Start () {
		system = EventSystem.current;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey (KeyCode.LeftShift) && Input.GetKeyDown (KeyCode.Tab) && system.currentSelectedGameObject == gameObject) {
			system.SetSelectedGameObject (prev.gameObject);
		} else if (Input.GetKeyDown (KeyCode.Tab) && system.currentSelectedGameObject == gameObject) {
			system.SetSelectedGameObject (next.gameObject);
		} 
	}
}
