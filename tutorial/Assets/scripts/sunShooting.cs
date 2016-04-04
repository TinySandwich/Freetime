using UnityEngine;
using System.Collections;

public class sunShooting : MonoBehaviour {

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

	public bool shot;
	public bool shooting;
	public Rigidbody2D bCharge;
	private Rigidbody2D bulletClone = new Rigidbody2D ();
	public Light plasmaLight;

	private int dancing;
	public Rigidbody2D target;

	void Awake()
	{
		sunLight = GetComponentInChildren<Light> ();
	}

	void Start() {
		dancing = 0;
		animator = GetComponent<Animator> ();
	}

	void Update() {
	}
}
