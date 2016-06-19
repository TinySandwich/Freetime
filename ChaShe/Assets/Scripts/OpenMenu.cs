using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class OpenMenu : MonoBehaviour {

	private bool paused = false;
	public GameObject myMenu;
		
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown ("escape")) {
			if (!paused) {
				//show menu
				myMenu.SetActive(true);
				paused = true;
			} else {
				//hide menu
				myMenu.SetActive(false);
				paused = false;
			}
		}
	}
}
