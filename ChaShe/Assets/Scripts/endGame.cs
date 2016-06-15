using UnityEngine;
using System.Collections;

public class endGame : MonoBehaviour {

	// If the player ever presses escape the game will exit
	void Update () {
		if (Input.GetKey ("escape"))
			Application.Quit ();
	}
}
