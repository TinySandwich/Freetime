using UnityEngine;
using System.Collections;

public class lookAt : MonoBehaviour {
	public float distanceFromCamera = 10.0f;

	void Update() {
		Vector3 pos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, distanceFromCamera);
		pos = Camera.main.ScreenToWorldPoint(pos);
		transform.position = pos;
	}
}
