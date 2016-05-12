using UnityEngine;
using System.Collections;

public class loadTimer : MonoBehaviour {
	float timeLeft = 3.0f;
	public int NextScene;

	void Update () {
		timeLeft -= Time.deltaTime;
		if (timeLeft < 0) {
			LoadScene (NextScene);
		}
	}

	public void LoadScene(int level)
	{
		Application.LoadLevel (level);
	}
}
