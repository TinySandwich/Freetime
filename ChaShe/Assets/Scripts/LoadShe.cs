using UnityEngine;
using System.Collections;

public class LoadShe : MonoBehaviour {

	public void onClick() {
		// Check Saved
		if (PlayerPrefs.GetInt ("saved") == 0) {
			// ask save

			//if (!cancelled) {
				//Try to open file
				// if (successful)
				////Update saved as false
				//PlayerPrefs.SetInt ("saved", 0);
				////Update loaded as true
				//PlayerPrefs.SetInt ("active", 1);
			//}
		} else {
			//Try to open file
			// if (successful)
			////Update saved as false
			//PlayerPrefs.SetInt ("saved", 0);
			////Update loaded as true
			//PlayerPrefs.SetInt ("active", 1);
		}
	}
}
