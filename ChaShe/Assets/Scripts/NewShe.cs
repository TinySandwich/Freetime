using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class NewShe : MonoBehaviour {

	public void onClick () {
		//Check saved if the sheet is already active
		if (PlayerPrefs.GetInt ("saved") == 0 && PlayerPrefs.GetInt ("active") != 0) {
			// ask save
			//if (!canceled) {
			SceneManager.LoadScene (1);

			//Update saved as false
			PlayerPrefs.SetInt ("saved", 0);
			//Update loaded as true
			PlayerPrefs.SetInt ("active", 1);
			//}
		} else {
			SceneManager.LoadScene (1);

			//Update saved as false
			PlayerPrefs.SetInt ("saved", 0);
			//Update loaded as true
			PlayerPrefs.SetInt ("active", 1);
		}
	}
}
