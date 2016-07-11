using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class FieldTab : MonoBehaviour {
	public Selectable oneField;
	public Selectable twoField;
	public Selectable thrField;
	public Selectable fouField;
	public Selectable fivField;
	public Selectable sixField;
	//public Selectable sevField;
	private EventSystem system;
	private Selectable[] mySelectables;

	// Use this for initialization
	void Start () {
		PlayerPrefs.SetInt ("tab", 0); // This is to prevent any problems with the edge case (hitting tab, before creating an object)
		system = EventSystem.current;
		mySelectables = new Selectable[7];
		mySelectables [0] = oneField;
		mySelectables [1] = twoField;
		mySelectables [2] = thrField;
		mySelectables [3] = fouField;
		mySelectables [4] = fivField;
		mySelectables [5] = sixField;
		//mySelectables [6] = sevField;
	}

	void Update () {
		if (Input.GetKey (KeyCode.LeftShift) && Input.GetKeyDown (KeyCode.Tab)) {
			int myLoc = PlayerPrefs.GetInt ("tab");
			myLoc--;
			if (myLoc < 0)
				myLoc = 5; // if they shift+tab back past the first field, need to go to the end field
			system.SetSelectedGameObject (mySelectables[myLoc].gameObject);
			PlayerPrefs.SetInt ("tab", myLoc);
		} else if (Input.GetKeyDown (KeyCode.Tab)) {
			int myLoc = PlayerPrefs.GetInt ("tab");
			myLoc = (myLoc + 1) % 6; // if they tab past the last field, need to go to first field
			system.SetSelectedGameObject (mySelectables[myLoc].gameObject);
			PlayerPrefs.SetInt ("tab", myLoc);
		} 
	}
}


/*	
 * Below was my first attempt it worked well enough. Each of the different fields would have its own prev and 
 * next (like a list). However, for some reason the next and prevs kept getting mixed up. As such I decided 
 * to go with the above more direct over arching approach.
 * 
 * public Selectable prev;
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
	}/**/
