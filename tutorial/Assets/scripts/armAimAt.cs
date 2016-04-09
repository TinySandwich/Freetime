using UnityEngine;
using System.Collections;

public class armAimAt : MonoBehaviour {

	Vector3 mouse_pos;
	Transform target; //Assign to the object you want to rotate
	Vector3 object_pos;
	float angle;
	bool facingRight = true;
	bool curfacingRight;

	Animator animator;

	void Start() {
		animator = GetComponent<Animator> ();
	}

	void Update ()
	{
		var mouse = Input.mousePosition;
		var screenPoint = Camera.main.WorldToScreenPoint(transform.position);
		var offset = new Vector2(mouse.x - screenPoint.x, mouse.y - screenPoint.y);
		var angle = Mathf.Atan2(offset.y, offset.x) * Mathf.Rad2Deg;


		// If Voltage is looking left, the angle of the arm needs to be reversed.
		if (offset.x < 0) {
			curfacingRight = false;
			angle *= -1;
		} 
		// If Voltage is looking right
		else if (offset.x > 0) {
			curfacingRight = true;
		}

		if (curfacingRight != facingRight) {
			facingRight = !facingRight;
			Flip ();
		}

		transform.rotation = Quaternion.Euler(0, 0, angle);
	}

	void Flip(){
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		theScale.y *= -1;
		transform.localScale = theScale;
	}
}
