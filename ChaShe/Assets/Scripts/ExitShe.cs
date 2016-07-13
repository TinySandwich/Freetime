using UnityEngine;
using System.Collections;

public class ExitShe : MonoBehaviour {

	public GameObject saveMenu;
	public GameObject myMenu;

	public void onClick() {
		saveMenu.SetActive(true);
		myMenu.SetActive(false);
	}
}