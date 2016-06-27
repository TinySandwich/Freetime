using UnityEngine;
using System.Collections;

public class confirmCancel : MonoBehaviour {

	public GameObject saveMenu;
	public GameObject myMenu;

	public void onClick () {
		saveMenu.SetActive(false);
		myMenu.SetActive(true);
	}
}
