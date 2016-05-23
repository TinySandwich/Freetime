using UnityEngine;
using System.Collections;

public class knockBackCollision : MonoBehaviour {

	public int kbDist = 100;

	void OnCollisionEnter2D(Collision2D coll) {
		/*Check to see if the object collided with is the player if so. Knock the player back and delete the object.*/
		if (coll.gameObject.tag == "Player") {
			/*Keep the position the same except move the player backwards equal to kbDist*/
			Vector3 kbVec = new Vector3 (coll.gameObject.transform.position.x - kbDist, coll.gameObject.transform.position.y, coll.gameObject.transform.position.z);
			coll.gameObject.transform.position = kbVec;

			Destroy (this.gameObject);

			/*How to pull in game data using tags and components*/
			//GameObject myGobj = GameObject.FindGameObjectWithTag ("Player");
			//Rigidbody2D myPlayer = myGobj.GetComponent<Rigidbody2D> ();
		}
	}
}
