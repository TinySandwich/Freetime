using UnityEngine;
using System.Collections;

public class kill : MonoBehaviour {
	public float delay = 2.0f;

	// Use this for initialization
	void Start () {
		Destroy (gameObject, delay);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
