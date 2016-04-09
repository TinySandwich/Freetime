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

	public int bulletSpeed = 50;
	public bool shot = true;
	public bool shooting;
	public Rigidbody2D bCharge;
	private Rigidbody2D bulletClone = new Rigidbody2D ();
	public Rigidbody2D bullet;
	public Light plasmaLight;
	public Rigidbody2D target;
	public Rigidbody2D source;

	void Awake()
	{
		sunLight = GetComponentInChildren<Light> ();
	}

	void Start() {
		
	}

	void Update() {
		if (!shot) {
			plasmaLight.intensity = 8;
			//Physics.IgnoreLayerCollision (2, 3, true);

			var screenPoint = Camera.main.WorldToScreenPoint (transform.position);
			var offset = new Vector2 (target.transform.position.x - transform.position.x + Random.Range (-3, 3), target.transform.position.y + Random.Range (-1, 5) - transform.position.y);
			offset = offset.normalized;
			var angle = Mathf.Atan2 (offset.y, offset.x) * Mathf.Rad2Deg;

			Quaternion temp = new Quaternion (transform.rotation.x, transform.rotation.y, transform.rotation.z, 0);
			bulletClone = (Rigidbody2D)Instantiate (bullet, transform.position, temp);
			bulletClone.velocity = offset * bulletSpeed;
			shot = true;
		}
	}
}
