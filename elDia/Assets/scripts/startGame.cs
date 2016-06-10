using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class startGame : MonoBehaviour {

	public int level = 1;

	public void FixedUpdate()
	{
		if (Input.GetKey (KeyCode.R)) {
			SceneManager.LoadScene (level);
		}
	}


}
