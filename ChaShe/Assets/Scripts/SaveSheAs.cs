using UnityEngine;
using System.Collections;

public class SaveSheAs : MonoBehaviour {

	public void onClick () {
		//Open up save dialog

		//if (successful)
		PlayerPrefs.SetInt ("saved", 1);
	}
}
