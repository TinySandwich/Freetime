using UnityEngine;
using System.Collections;

public class sunDance : MonoBehaviour {
	Animator animator;
	private bool shot;
	private bool shooting;
	public Light plasmaLight;

	private int dancing;

	void Start() {
		dancing = 0;
		animator = GetComponent<Animator> ();

	}

	void Update() {
		dancing += Random.Range (-1, 3);
		if (shot) {
			shot = false;
		} else if (shooting && dancing > 200) {
			animator.SetBool ("fire", false);
			animator.SetBool ("firing", false);
			animator.SetTrigger ("fireT");
			shot = true;
			dancing = 0;
			shooting = false;
		} else if (shooting) {
			//plasmaLight.transform.position = transform.position;
			plasmaLight.intensity = 2;
//			bulletClone.transform.position = transform.position;
		} else if (dancing > 100) {
			/*When the dancing is complete it fires at Voltage*/
			animator.SetBool ("firing", true); /*Flying forwards to the left*/
//			bulletClone = (Rigidbody2D)Instantiate (bCharge, transform.position, transform.rotation);
			/*When the fire button is click start charging*/
			shooting = true;
		} else {
			plasmaLight.intensity = 0;
		}
		/*else if (dancing > 200) {
			animator.SetBool ("firing", false);
			dancing = 0;
			shooting = false;
		}*/
	}
}
