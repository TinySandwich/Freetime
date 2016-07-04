using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class RayClick : MonoBehaviour {

	private Camera myCamera;

	private EventSystem system;
	private string output = "";

	private InputField Xin;
	private InputField Wid;
	private InputField Yin;
	private InputField Hei;
	private InputField Ord;
	private InputField Nam;
	private InputField Tex;

	private GameObject curSelect;

	void Start () {
		myCamera = Camera.main.GetComponent<Camera> ();

		system = EventSystem.current;

		Xin = GameObject.FindWithTag ("XIn").GetComponent<InputField>();
		Wid = GameObject.FindWithTag ("WidthIn").GetComponent<InputField>();
		Yin = GameObject.FindWithTag ("YIn").GetComponent<InputField>();
		Hei = GameObject.FindWithTag ("HeightIn").GetComponent<InputField>();
		Ord = GameObject.FindWithTag ("OrderIn").GetComponent<InputField>();
		Nam = GameObject.FindWithTag ("NameIn").GetComponent<InputField>();
		Tex = GameObject.FindWithTag ("TextIn").GetComponent<InputField>();

		curSelect = new GameObject();
	}

	void OnGUI() {
		GUIStyle myStyle = new GUIStyle();
		myStyle.fontSize = 24;
		myStyle.fontStyle = FontStyle.Bold;
		myStyle.clipping = TextClipping.Overflow;
		GUI.color = Color.black;
		GUI.Label (new Rect (10, 25, 1000, 20), output, myStyle);
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown (0)) {
			Ray myRay = myCamera.ScreenPointToRay (Input.mousePosition);
			RaycastHit myHit;
			if (Physics.Raycast (myRay, out myHit)) {
				curSelect.tag = " ";
				curSelect = myHit.transform.gameObject;
				curSelect.tag = "selected";

				Xin.text = curSelect.transform.position.x.ToString ();
				Wid.text = "Hi I'm the width";
				Yin.text = curSelect.transform.position.y.ToString ();
				Hei.text = "I'm the height";
				Ord.text = curSelect.transform.position.z.ToString ();
				Nam.text = curSelect.transform.name.ToString ();
				Tex.text = "text";

				system.SetSelectedGameObject (Xin.gameObject);
			}
		} else if (curSelect.tag.Equals("selected")) {
			float newX = 0;
			float newY = 0;
			float newZ = 0;
			try {
				newX = float.Parse (Xin.text.ToString ());
			}
			catch {
				newX = 0;
			}
				
			try {
				newY = float.Parse (Yin.text.ToString ());
			}
			catch {
				newY = 0;
			}

			try {
				newZ = float.Parse (Ord.text.ToString ());
			}
			catch {
				newZ = 0;
			}
				
			curSelect.transform.position = new Vector3(newX, newY, newZ);
			output = Xin.text.ToString ();
		}
	}
}
