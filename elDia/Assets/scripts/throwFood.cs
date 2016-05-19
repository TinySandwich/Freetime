using UnityEngine;
using System.Collections;

public class throwFood : MonoBehaviour {

	public Transform spawn;
	public Rigidbody2D pan;
	public Rigidbody2D bottle1;
	public Rigidbody2D bottle2;
	public Rigidbody2D skull;
	public int bottleSpeed = 20;

	private Rigidbody2D food = new Rigidbody2D ();
	private float delay; // The random delay between item throwing

	// Use this for initialization
	void Start () {
		delay = Random.Range (5, 20);
	}
	
	// Update is called once per frame
	void Update () {
		if (delay < 0) {
			delay = Random.Range (1, 6);
			launch ();
		} else {
			delay -= Time.deltaTime;
		}
	}

	/* The launch method determines which random piece of food will be thrown at the main character. Each food has a different pattern.*/
	void launch (){
		int food = Random.Range (0, 3);
		/*if (food == 2) {
			spawnSkull ();
		} else if (food == 1) {/**/
			spawnBottle ();
		/*} else {
			spawnPan ();
		}/**/
	}

	/*Skulls fly directly at the player, but doesn't turn well*/
	void spawnSkull () {

	}

	/*Bottles are flung high into the air and then arcs down*/
	void spawnBottle () {
		Quaternion temp = new Quaternion (transform.rotation.x, transform.rotation.y, Random.Range (0, 360), 0);

		if (Random.Range (0, 2) == 0) {
			food = (Rigidbody2D)Instantiate (bottle1, spawn.position, temp);
		} else {
			food = (Rigidbody2D)Instantiate (bottle2, spawn.position, temp);
		}
			
		Vector2 randomVec = new Vector2 (Random.Range (3, 10), Random.Range (3, 10));
		food.velocity = randomVec * bottleSpeed;
	}

	/*Pan is thrown horizontally at the player though it doesn't turn*/
	void spawnPan () {

	}
}
