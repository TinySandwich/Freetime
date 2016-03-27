using UnityEngine;
using System.Collections;

public class cameraFollow : MonoBehaviour {

	public float dampTime = 0.15f;
	private Vector3 velocity = Vector3.zero;
	public Transform target;

	// Update is called once per frame
	void FixedUpdate () 
	{
		if (target)
		{
			Vector3 midpoint = (target.position + GetComponent<Camera> ().ScreenToWorldPoint (Input.mousePosition)) / 2;
			midpoint.z = target.position.z; /*This prevents the camera from changing z levels*/

			Vector3 point = GetComponent<Camera>().WorldToViewportPoint(midpoint);
			Vector3 delta = midpoint - GetComponent<Camera>().ViewportToWorldPoint(new Vector3(0.5f, 0.5f, point.z)); //(new Vector3(0.5, 0.5, point.z));
			Vector3 destination = transform.position + delta;
			transform.position = Vector3.SmoothDamp(transform.position, destination, ref velocity, dampTime);
		}
	}
}