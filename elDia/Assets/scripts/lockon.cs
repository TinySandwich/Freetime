using UnityEngine;
using System.Collections;

public class lockon : MonoBehaviour {

	public Rigidbody2D projectile;
	public int speed = 100;
	public Transform target; // Note: target should be set by the instantiating object <see throwFood.cs>

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		Vector2 targetVec = new Vector2 (target.position.x - transform.position.x, target.position.y - transform.position.y);
		targetVec.Normalize ();
		projectile.velocity = targetVec * speed;

	}
}
