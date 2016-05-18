using UnityEngine;
using System.Collections;

public class flight : MonoBehaviour {

	public float flyspeed = 4.0f;
	public int slowDown = 2;
	private Vector3 moveDirection = Vector3.zero;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 move = new Vector3(Input.GetAxis ("Horizontal") * flyspeed, Input.GetAxis ("Vertical") * flyspeed, 0);
		if (move.x < 0) {
			move.x = move.x * slowDown;
		}

		transform.position = transform.position + move;
	}
}
