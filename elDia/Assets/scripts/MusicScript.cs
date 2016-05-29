using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MusicScript : MonoBehaviour 
{
	static MusicScript instance;
	bool doneFading;
	public float timer = 5f;
	public int nextLevel = 0;
	public AudioSource myAudio;

	void Start()
	{
		if(instance == null)
		{
			instance = this;
			DontDestroyOnLoad(gameObject);
		}

		else if (instance != this)
		{
			Destroy(gameObject);
		}
	}

	void OnLevelWasLoaded(int Level){
		if (Level == nextLevel){
			FadeOutMusic ();
		}
	}

	public void FadeOutMusic()
	{
		StartCoroutine (FadeMusic ());
	}

	IEnumerator FadeMusic()
	{
		while (myAudio.volume > .1F) {
			myAudio.volume = Mathf.Lerp (myAudio.volume, 0F, Time.deltaTime);
			yield return 0;
		}

		myAudio.volume = 0;
	}

	/*void Update()
	{
		if (doneFading == true) {
			Destroy (gameObject);
			Debug.Log ("Music destroyed.");
		}
	}

	void FadeMusic()
	{
		if (timer > 0)
		{
			instance.GetComponent<AudioSource>().volume -= 0.015f;
			timer -= Time.deltaTime;
		}
		if (instance.GetComponent<AudioSource>().volume == 0)
		{
			doneFading = true;
		}

	}*/
}