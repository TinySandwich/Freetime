using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class loadOnClick : MonoBehaviour {

	static MusicScript instance;
	bool doneFading;
	public float timer = 5f;
	public static float finalScore = 0f;
	//public AudioSource myAudio;

	public void LoadScene(int level)
	{
		SceneManager.LoadScene (level);
	}

	public void FadeOutMusic(AudioSource myAudio)
	{
		StartCoroutine (FadeMusic (myAudio));
	}

	IEnumerator FadeMusic(AudioSource myAudio)
	{
		while (myAudio.volume > .1F) {
			myAudio.volume = Mathf.Lerp (myAudio.volume, 0F, Time.deltaTime);
			yield return myAudio.volume;
		}

		if (myAudio.volume < .1F) {
			myAudio.volume = 0;
		}
	}
}
