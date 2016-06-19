using UnityEngine;
using System.Collections;

public class CameraDrag : MonoBehaviour {

	public float dragSpeed = 5;
	private Vector3 dragOrigin;

	public float outerLeft = -50f;
	public float outerRight = 250f;
	public float outerTop = 150f;
	public float outerBottom = 150f;

	private string output = "";

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
			dragOrigin = Input.mousePosition;
			return;
		}
		if (!Input.GetMouseButton (0)) {
			return;
		}

		Vector3 pos = Camera.main.ScreenToViewportPoint (dragOrigin - Input.mousePosition);
		Vector3 move = new Vector3 (pos.x * dragSpeed, pos.y * dragSpeed, 0);

		transform.Translate (move, Space.World);

		output = "X: " + Input.mousePosition.x + " Y: " + Input.mousePosition.y + 
			"\ncamX: " + transform.position.x + " camY: " + transform.position.y;

	}
}
