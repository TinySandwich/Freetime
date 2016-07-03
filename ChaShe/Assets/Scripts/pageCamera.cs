using UnityEngine;
using System.Collections;

public class pageCamera : MonoBehaviour {

	public GameObject myPage;

	// Use this for initialization
	void Start () {
		Camera.current.orthographicSize = (myPage.GetComponent<Renderer> ().bounds.size.y-500) / 2;
		Camera.current.aspect = .65f;

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
