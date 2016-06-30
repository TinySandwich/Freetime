using UnityEngine;
using System.Collections;

public class ExitSplash : MonoBehaviour {
	public void onClick() {
		PlayerPrefs.DeleteAll ();
		Application.Quit ();
	}
}
