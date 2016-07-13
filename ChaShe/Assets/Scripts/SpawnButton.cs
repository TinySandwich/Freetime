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
	private EventSystem system;

	private InputField Xin;
	private InputField Wid;
	private InputField Yin;
	private InputField Hei;
	private InputField Ord;
	private InputField Nam;
	private InputField Tex;

	private RayClick mySelector;
	private Camera newCam;

	void Start () {
		system = EventSystem.current;

		Xin = GameObject.FindWithTag ("XIn").GetComponent<InputField>();
		Wid = GameObject.FindWithTag ("WidthIn").GetComponent<InputField>();
		Yin = GameObject.FindWithTag ("YIn").GetComponent<InputField>();
		Hei = GameObject.FindWithTag ("HeightIn").GetComponent<InputField>();
		Ord = GameObject.FindWithTag ("OrderIn").GetComponent<InputField>();
		Tex = GameObject.FindWithTag ("TextIn").GetComponent<InputField>();
	}

	public void onClick() {
		Vector3 myPos = new Vector3 (myCam.transform.position.x, myCam.transform.position.y, -1);
		objClone = (GameObject)Instantiate (myObject, myPos, transform.rotation);

		try {
			//Must go into the RayClick script and change the variable.
			newCam = Camera.main.GetComponent<Camera> ();
			mySelector = newCam.GetComponent<RayClick>();
			oldSelect = mySelector.curSelect;
			oldSelect.tag = " ";
		}
		catch {
			oldSelect = objClone;
		}

		/*Update the data fields with position data*/
		Xin.text = objClone.transform.position.x.ToString ();
		Wid.text = objClone.transform.localScale.x.ToString();
		Yin.text = objClone.transform.position.y.ToString ();
		Hei.text = objClone.transform.localScale.y.ToString();
		float ordTemp = objClone.transform.position.z * -1;
		Ord.text = ordTemp.ToString ();
		if (objClone.name.Contains("Text"))
			Tex.text = objClone.GetComponent<TextMesh> ().text;
		else {
			Tex.text = "N/A";
		}/**/

		system.SetSelectedGameObject (myX.gameObject);
		PlayerPrefs.SetInt ("tab", 0);
		mySelector.setSelect (objClone);
	}
}
