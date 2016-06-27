using UnityEngine;
using System.Collections;

public class confirmSaveMenu : MonoBehaviour {

	private bool paused = false;
	public GameObject saveMenu;

	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown ("escape")) {
			saveMenu.SetActive(false);
			paused = false;
		}
	}
}
