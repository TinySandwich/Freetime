using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class OpenMenu : MonoBehaviour {

	private bool paused = false;
	private bool showGUI = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey ("escape"))
			SceneManager.LoadScene (2);
	}
}
