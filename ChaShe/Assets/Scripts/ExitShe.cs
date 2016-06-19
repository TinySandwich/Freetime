using UnityEngine;
using System.Collections;

public class ExitShe : MonoBehaviour {

	public void onClick() {
		//Check saved
		if (PlayerPrefs.GetInt ("saved") == 0) {
			// ask save
			// if (!cancelled) {
				//PlayerPrefs.DeleteAll ();
				//Application.Quit ();
			//}
		} else {
			PlayerPrefs.DeleteAll ();
			Application.Quit ();
		}
	}
}
