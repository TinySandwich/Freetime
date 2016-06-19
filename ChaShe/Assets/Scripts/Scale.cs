using UnityEngine;
using System.Collections;

public class Scale : MonoBehaviour {

	private float origWidth = 640f;
	private float origHeight = 400f;
	private Vector3 scale;

	void OnGui(){
		scale.x = Screen.width / origWidth;
		scale.y = Screen.height / origHeight;
		scale.z = 1;

		Matrix4x4 svMat = GUI.matrix;

		GUI.matrix = Matrix4x4.TRS (Vector3.zero, Quaternion.identity, scale);

		Rect myRect = new Rect (10, 10, 200, 50);
		GUI.Box (myRect, "Box"); 
		myRect = new Rect (400, 180, 230, 50);
		GUI.Button (myRect, "Button");

		GUI.matrix = svMat;
	}
}
