using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class SpawnButton : MonoBehaviour {

	public GameObject myObject;
	public Camera myCam; // items will spawn in the center of the camera.
	public Selectable myX; // this will place the focus in the X field
	private GameObject objClone;
	private EventSystem system;

	// Use this for initialization
	void Start () {
		system = EventSystem.current;
	}

	public void onClick() {
		Vector3 myPos = new Vector3 (myCam.transform.position.x, myCam.transform.position.y, -1);
		objClone = (GameObject)Instantiate (myObject, myPos, transform.rotation);
		system.SetSelectedGameObject (myX.gameObject);
		PlayerPrefs.SetInt ("tab", 0);
	}
}
