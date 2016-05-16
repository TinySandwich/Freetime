using UnityEngine;
using System.Collections;

public class flight : MonoBehaviour {

	public float flyspeed = 1.0f;
	private Vector3 moveDirection = Vector3.zero;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 move = new Vector3(Input.GetAxis ("Horizontal") * flyspeed, Input.GetAxis ("Vertical") * flyspeed, 0);

		transform.position = transform.position + move;
	}
}
