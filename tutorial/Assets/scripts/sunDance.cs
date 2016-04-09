using UnityEngine;
using System.Collections;

public class sunDance : MonoBehaviour {
	Animator animator;
	private bool shot;
	private bool charging;
	public Light plasmaLight;
	public Rigidbody2D bullet; 
	public Transform aim;

	private int dancing;

	void Start() {
		dancing = 0;
		animator = GetComponent<Animator> ();

	}

	void Update() {
		dancing += Random.Range (-1, 3);
		if (shot) {
			shot = false;
		} else if (charging && dancing > 200) {
			animator.SetBool ("fire", false);
			animator.SetBool ("firing", false);
			animator.SetTrigger ("fireT");
			aim.GetComponent<sunShooting> ().shot = false;
			shot = true;
			dancing = 0;
			charging = false;
		} else if (charging) {
			plasmaLight.intensity = 2;
		} else if (dancing > 100) {
			/*When the dancing is complete it fires at Voltage*/
			animator.SetBool ("firing", true); /*Flying forwards to the left*/
			charging = true;
		} else {
			plasmaLight.intensity = 0;
		}
	}
}
