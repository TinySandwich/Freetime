using UnityEngine;
using System.Collections;

public class ScaleQuad : MonoBehaviour {

	public bool vert;
	public GameObject myQuad;

	void Start() {
		RectTransform rt = (RectTransform)myQuad.transform;
		if (vert) {
			myQuad.transform.position.Set (myQuad.transform.position.x, Screen.width-50f, myQuad.transform.position.z);
			//rt.sizeDelta = new Vector2 (50f, Screen.height);
		} else {
			myQuad.transform.position.Set (0, Screen.height-50f, myQuad.transform.position.z);
			//rt.sizeDelta = new Vector2 (Screen.width, 50f);
		}


	}
}
