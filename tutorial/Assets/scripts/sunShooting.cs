using UnityEngine;
using System.Collections;

public class sunShooting : MonoBehaviour {

	public int plasmaDamage = 30;
	public AudioClip shotClip;
	public float flashIntensity = 3f;
	public float fadeSpeed = 10f;

	private Animator anim;
	//private HashIDs hash;
	private Light sunLight;
	private SphereCollider col;
	private Transform player;
	//private PlayerHealth playerHealth;
	private bool shooting;

	void Awake()
	{
		anim = GetComponent<Animator> ();
		sunLight = GetComponentInChildren<Light> ();

	}
}
