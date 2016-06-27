using UnityEngine;
using System.Collections;

public class ExitShe : MonoBehaviour {

	public GameObject saveMenu;
	public GameObject myMenu;

	public void onClick() {
		//Check saved
		if (PlayerPrefs.GetInt ("saved") == 0) {
			saveMenu.SetActive(true);
			myMenu.SetActive(false);
			//DISABLE THE MENU OPTIONS
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