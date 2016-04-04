using UnityEngine;
using System.Collections;

public class sunAim : MonoBehaviour {

	public Rigidbody2D target;
	Transform target2; //Assign to the object you want to rotate
	Vector3 object_pos;
	float angle;

	void Update ()
	{
		var screenPoint = Camera.main.WorldToScreenPoint(transform.position);
		var offset = new Vector2(transform.position.x - target.transform.position.x, transform.position.y - target.transform.position.y);
		var angle = Mathf.Atan2(offset.y, offset.x) * Mathf.Rad2Deg;

		transform.rotation = Quaternion.Euler(0, 0, angle);
	}
}
