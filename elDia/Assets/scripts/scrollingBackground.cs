using UnityEngine;
using System.Collections;

public class scrollingBackground : MonoBehaviour {

	public float speed = 1.0f; //Base speed of background
	public float min = 0f; //Lowest speed the background can move. Negative for moving left.
	public float max = 10f; // Highest speed the background can move.
	public Camera gameCam;
	public Transform player;

	public static scrollingBackground current;
	private float pos = 0;

	// Use this for initialization
	void Start () {
		current = this;
	}

	public void Update() {
		pos += speed;
		if (pos > 1.0f) {
			pos = 0f;
		}

		//gameObject.GetComponent<Renderer> ().material.mainTextureOffset = new Vector2 ((Time.time * speed) % 1, 0f);

		gameObject.GetComponent<Renderer>().material.mainTextureOffset = new Vector2 (pos, 0);
	}
}
