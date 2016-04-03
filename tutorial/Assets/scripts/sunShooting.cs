using UnityEngine;
using System.Collections;

public class sunShooting : MonoBehaviour {

	public Rigidbody2D player;
	public int plasmaDamage = 30;
	public AudioClip shotClip;
	public float flashIntensity = 3f;
	public float fadeSpeed = 10f;
	Animator animator;

	private Animator anim;
	//private HashIDs hash;
	private Light sunLight;
	private SphereCollider col;
	//private Transform player;
	//private PlayerHealth playerHealth;
	private bool shooting;

	private int dancing;

	void Awake()
	{
		anim = GetComponent<Animator> ();
		sunLight = GetComponentInChildren<Light> ();
	}

	void Start() {
		dancing = 0;
		animator = GetComponent<Animator> ();
	}

	void Update() {
		dancing += Random.Range (-1, 3);
		if (dancing > 100) {
			/*When the dancing is complete it fires at Voltage*/
			animator.SetBool ("firing", true); /*Flying forwards to the left*/
		}
		if (dancing > 200) {
			animator.SetBool ("firing", false);
			dancing = 0;
		}
	}
}
