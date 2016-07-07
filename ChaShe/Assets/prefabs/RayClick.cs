using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class RayClick : MonoBehaviour {

	private Camera myCamera;

	private Vector3 dragOrigin;
	private EventSystem system;
	public string output = "";

	private InputField Xin;
	private InputField Wid;
	private InputField Yin;
	private InputField Hei;
	private InputField Ord;
	private InputField Nam;
	private InputField Tex;

	public GameObject curSelect;


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

				setFields (curSelect);

				system.SetSelectedGameObject (Xin.gameObject);
				PlayerPrefs.SetInt ("tab", 0);
			}
		}

		if (curSelect.tag.Equals("selected")) {
			//curSelect = GameObject.FindWithTag ("selected").GetComponent<GameObject>;
			float newX = 0;
			float newW = 0;
			float newY = 0;
			float newH = 0;
			float newZ = 0;
			//X position
			try {
				newX = float.Parse (Xin.text.ToString ());
			}
			catch {
				newX = 0;
			}
			//Width
			try {
				newW = float.Parse (Wid.text.ToString ());
			}
			catch {
				newW = 0;
			}
			//Y position
			try {
				newY = float.Parse (Yin.text.ToString ());
			}
			catch {
				newY = 0;
			}
			//Height
			try {
				newH = float.Parse (Hei.text.ToString ());
			}
			catch {
				newH = 0;
			}
			try {
				newZ = float.Parse (Ord.text.ToString ());
			}
			catch {
				newZ = 0;
			}
				
			curSelect.transform.position = new Vector3(newX, newY, newZ * -1);
			curSelect.transform.localScale = new Vector3 (newW, newH);
			//output = Xin.text.ToString ();
		}

		if (!Input.GetMouseButton (0)) {
			dragOrigin = Input.mousePosition;
			return;
		}

		Vector3 myPos = dragOrigin - Input.mousePosition;
		curSelect.transform.position = curSelect.transform.position - myPos;
		if (curSelect.transform.position.x < -100)
			curSelect.transform.position = new Vector3 (-100, curSelect.transform.position.y, curSelect.transform.position.z);
		if (curSelect.transform.position.x > 800)
			curSelect.transform.position = new Vector3 (800, curSelect.transform.position.y, curSelect.transform.position.z);
		if (curSelect.transform.position.y < -200)
			curSelect.transform.position = new Vector3 (curSelect.transform.position.x, -200, curSelect.transform.position.z);
		if (curSelect.transform.position.y > 800)
			curSelect.transform.position = new Vector3 (curSelect.transform.position.x, 800, curSelect.transform.position.z);
		dragOrigin = Input.mousePosition;

		if (curSelect.tag.Equals ("selected")) {
			setFields (curSelect);
		}
	}

	public void setSelect (GameObject myObject)
	{
		curSelect.tag = " ";
		curSelect = myObject;
		curSelect.tag = "selected";
	}

	private void setFields (GameObject mySel)
	{
		Xin.text = mySel.transform.position.x.ToString ();
		Wid.text = mySel.transform.localScale.x.ToString();
		Yin.text = mySel.transform.position.y.ToString ();
		Hei.text = mySel.transform.localScale.y.ToString();
		float ordTemp = mySel.transform.position.z * -1;
		Ord.text = ordTemp.ToString ();
		Nam.text = mySel.transform.name.ToString ();
		Tex.text = "text";
		output = "Selected: " + mySel.name.ToString();
	}

	public void deleteSelect ()
	{
		if (curSelect.tag.Equals ("selected")) {
			curSelect.tag = " ";
			DestroyObject (curSelect.gameObject);
			curSelect = new GameObject();
		}
	}
}
