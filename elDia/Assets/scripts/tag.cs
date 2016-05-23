using UnityEngine;
using System.Collections;

public class tag : MonoBehaviour {

	public string myTag = "none";

	// Use this for initialization
	void Start () {
		gameObject.tag = myTag;
	}
}
