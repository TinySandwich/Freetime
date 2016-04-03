using UnityEngine;
using System.Collections;

public class cameraFollow : MonoBehaviour {

	public float dampTime = 0.15f;
	private Vector3 velocity = Vector3.zero;
	public Transform target; /*Typically Player Character*/

	// Update is called once per frame
	void FixedUpdate () 
	{
		if (target) 
		{
			Vector3 midpoint = (target.position + GetComponent<Camera> ().ScreenToWorldPoint (Input.mousePosition)) / 2; /*Calculates the world position for the midpoint between the player and the mouse*/
			midpoint.z = target.position.z; /*This prevents the camera from changing z levels*/
			Vector3 point = GetComponent<Camera>().WorldToViewportPoint(midpoint);
			Vector3 delta = midpoint - GetComponent<Camera>().ViewportToWorldPoint(new Vector3(0.5f, 0.5f, point.z)); /*calculates the difference between the midpoint and the current camera position*/
			Vector3 destination = transform.position + delta; /*Current position augmented by the difference*/
			transform.position = Vector3.SmoothDamp(transform.position, destination, ref velocity, dampTime); /*This moves the camera with a smooth dampener*/
		}
	}
}