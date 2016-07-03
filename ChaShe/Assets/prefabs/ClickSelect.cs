using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ClickSelect : MonoBehaviour {

	private string output = "";
	private bool selected = false;
	private bool skip = false;
	Ray myRay;
	RaycastHit hit;
	public Camera myCamera;
	private GameObject myGameObject;

	private InputField Xin;
	private InputField Wid;
	private InputField Yin;
	private InputField Hei;
	private InputField Ord;
	private InputField Nam;
	private InputField Tex;

	void Start () {
		Xin = GameObject.FindWithTag ("XIn").GetComponent<InputField>();
		Wid = GameObject.FindWithTag ("WidthIn").GetComponent<InputField>();
		Yin = GameObject.FindWithTag ("YIn").GetComponent<InputField>();
		Hei = GameObject.FindWithTag ("HeightIn").GetComponent<InputField>();
		Ord = GameObject.FindWithTag ("OrderIn").GetComponent<InputField>();
		Nam = GameObject.FindWithTag ("NameIn").GetComponent<InputField>();
		Tex = GameObject.FindWithTag ("TextIn").GetComponent<InputField>();
	}

	void OnGUI() {
		GUIStyle myStyle = new GUIStyle();
		myStyle.fontSize = 24;
		myStyle.fontStyle = FontStyle.Bold;
		myStyle.clipping = TextClipping.Overflow;
		GUI.color = Color.black;
		GUI.Label (new Rect (10, 25, 1000, 20), output, myStyle);
	}

	void OnMouseDown() {
		if (Input.GetMouseButtonDown (0)) {
			selected = true;
			skip = true;
			output = "selected: " + transform.ToString ();
			transform.tag = "selected";
			/*Update the data fields with position data*/
			Xin.text = transform.position.x.ToString ();
			Wid.text = "Hi I'm the width";
			Yin.text = transform.position.y.ToString ();
			Hei.text = "I'm the height";
			Ord.text = transform.position.z.ToString ();
			Nam.text = transform.name.ToString ();
			Tex.text = "text";
		}
	}/**/

	// Update is called once per frame
	void Update () {
		if (skip) {
			skip = false;
		} else if (Input.GetMouseButtonDown (0) && !selected) {
			output = "";
			transform.tag = " ";
		} else if (selected) {
			transform.position.Set (float.Parse(Xin.text), float.Parse(Yin.text), float.Parse(Ord.text));
		}

		selected = false;

		/*Update the data fields*/
	}

	public void selectObj ()
	{
		Start ();
		OnMouseDown ();
	}
}
