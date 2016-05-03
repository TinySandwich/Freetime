using UnityEngine;
using System.Collections;

public class pulse : MonoBehaviour {

	public float scaleFactor;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		float myScale = Random.Range (1f * scaleFactor, 1.5f * scaleFactor);
		this.transform.localScale = new Vector3 (myScale, myScale, 1);
	}
}
