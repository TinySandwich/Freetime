using UnityEngine;
using System.Collections;

public class SaveShe : MonoBehaviour {

	public void onClick() {
		//Check to see if she has been loaded
		if (PlayerPrefs.GetInt ("active") == 0) {
			//string myPath = PlayerPrefs.GetString ("savePath");
			//if (myPath != "") //If myPath is not empty
			// Save to myPath
			// if (successful)
			PlayerPrefs.SetInt ("saved", 1);
			//else //Run Save As
			// SaveSheAs
		}

		//Save the .chashe to the savePath location
	}
}
