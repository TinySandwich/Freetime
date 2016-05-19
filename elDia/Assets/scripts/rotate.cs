using UnityEngine;
using System.Collections;

public class rotate : MonoBehaviour {

	public float speed = Random.Range(100,300);

	// Use this for initialization
	void Awake () {
		transform.Rotate (0, 0, Random.Range (0.0f, 360.0f));
	}

	void Update () {
		transform.Rotate (Vector3.forward, speed * Time.deltaTime);
	}
}
