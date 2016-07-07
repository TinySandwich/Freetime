using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class OpenMenu : MonoBehaviour {

	private bool paused = false;
	public GameObject myMenu;
	public GameObject PanelB;
	public GameObject PanelR;
		
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown ("escape")) {
			if (!paused) {
				//show menu
				PanelB.SetActive (false);
				PanelR.SetActive (false);
				myMenu.SetActive (true);
				paused = true;
			} else {
				//hide menu
				PanelB.SetActive (true);
				PanelR.SetActive (true);
				myMenu.SetActive (false);
				paused = false;
			}
		}
	}
}
