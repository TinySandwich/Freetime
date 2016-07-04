using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class SpawnButton : MonoBehaviour {

	public GameObject myObject;
	public Camera myCam; // items will spawn in the center of the camera.
	public Selectable myX; // this will place the focus in the X field
	private GameObject oldSelect;
	private GameObject objClone;
	private ClickSelect objSelect;
	private EventSystem system;

	private InputField Xin;
	private InputField Wid;
	private InputField Yin;
	private InputField Hei;
	private InputField Ord;
	private InputField Nam;
	private InputField Tex;

	void Start () {
		system = EventSystem.current;

		Xin = GameObject.FindWithTag ("XIn").GetComponent<InputField>();
		Wid = GameObject.FindWithTag ("WidthIn").GetComponent<InputField>();
		Yin = GameObject.FindWithTag ("YIn").GetComponent<InputField>();
		Hei = GameObject.FindWithTag ("HeightIn").GetComponent<InputField>();
		Ord = GameObject.FindWithTag ("OrderIn").GetComponent<InputField>();
		Nam = GameObject.FindWithTag ("NameIn").GetComponent<InputField>();
		Tex = GameObject.FindWithTag ("TextIn").GetComponent<InputField>();
	}

	public void onClick() {
		Vector3 myPos = new Vector3 (myCam.transform.position.x, myCam.transform.position.y, -1);
		objClone = (GameObject)Instantiate (myObject, myPos, transform.rotation);

		try {
			oldSelect = GameObject.FindWithTag ("selected").GetComponent<GameObject>();
			oldSelect.tag = " ";
		}
		catch {
			oldSelect = objClone;
		}
		//output = "selected: " + transform.ToString ();
		objClone.transform.tag = "selected";
		/*Update the data fields with position data*/
		Xin.text = objClone.transform.position.x.ToString ();
		Wid.text = "Hi I'm the width";
		Yin.text = objClone.transform.position.y.ToString ();
		Hei.text = "I'm the height";
		Ord.text = objClone.transform.position.z.ToString ();
		Nam.text = objClone.transform.name.ToString ();
		Tex.text = "text";

		system.SetSelectedGameObject (myX.gameObject);
		PlayerPrefs.SetInt ("tab", 0);
	}
}
