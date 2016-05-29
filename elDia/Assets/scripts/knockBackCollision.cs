using UnityEngine;
using System.Collections;

public class knockBackCollision : MonoBehaviour {

	public int kbDist = 1;
	private float timeMultiplier = 1;

	void OnCollisionEnter2D(Collision2D coll) {
		/*Check to see if the object collided with is the player if so. Knock the player back and delete the object.*/
		if (coll.gameObject.tag == "Player") {
			timeMultiplier = Time.timeSinceLevelLoad / 10;

			/*Keep the position the same except move the player backwards equal to kbDist multiplied by the timeMultiplier*/
			float knockback = kbDist * timeMultiplier;

			Vector3 kbVec = new Vector3 (coll.gameObject.transform.position.x - knockback, coll.gameObject.transform.position.y, coll.gameObject.transform.position.z);
			coll.gameObject.transform.position = kbVec;

			Destroy (this.gameObject);

			/*How to pull in game data using tags and components*/
			//GameObject myGobj = GameObject.FindGameObjectWithTag ("Player");
			//Rigidbody2D myPlayer = myGobj.GetComponent<Rigidbody2D> ();
		}
	}
}
