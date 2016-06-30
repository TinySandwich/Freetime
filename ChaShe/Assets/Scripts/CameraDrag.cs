using UnityEngine;
using System.Collections;

public class CameraDrag : MonoBehaviour {

	public float dragSpeed = 20;
	private Vector3 dragOrigin;
	public Camera thisCam;
	public float amount = 1f;
	public int minZoom = 5;
	public int maxZoom = 30;

	/*public float outerLeft = -50f;
	public float outerRight = 250f;
	public float outerTop = 150f;
	public float outerBottom = 150f;*/

	private string output = "";

	void ZoomOrthoCamera (Vector3 zoomTowards, float myAmount)
	{
		float multiplier = (1.0f / thisCam.orthographicSize * myAmount);

		transform.position += (zoomTowards - transform.position) * multiplier;

		thisCam.orthographicSize -= myAmount;

		thisCam.orthographicSize = Mathf.Clamp(thisCam.orthographicSize, minZoom, maxZoom);
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
		if (Input.GetAxis ("Mouse ScrollWheel") > 0) {
			ZoomOrthoCamera (Camera.main.ScreenToWorldPoint (Input.mousePosition), amount);
		}

		if (Input.GetAxis ("Mouse ScrollWheel") < 0) {
			ZoomOrthoCamera (Camera.main.ScreenToWorldPoint (Input.mousePosition), -1 * amount);
		}

		if (!Input.GetMouseButton (1)) {
			dragOrigin = Input.mousePosition;
			return;
		}
		/*if (Input.GetMouseButtonDown (1)) {
			dragOrigin = Input.mousePosition;
			return;
		}/**/

		Vector3 pos = Camera.main.ScreenToViewportPoint (dragOrigin - Input.mousePosition);
		Vector3 move = new Vector3 (pos.x * dragSpeed, pos.y * dragSpeed, 0);

		transform.Translate (move, Space.World);/**/

		output = /*"X: " + Input.mousePosition.x + " Y: " + Input.mousePosition.y + 
			"\ncamX: " + transform.position.x + " camY: " + transform.position.y;/**/
			"wheel" + Input.GetAxis ("Mouse ScrollWheel");
	}
}
