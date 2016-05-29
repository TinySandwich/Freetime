using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class DisplayFinalScore : MonoBehaviour {

	public float myTime;
	private string output = "";
	public string levelName = "";

	void OnGUI(){
		GUI.Label (new Rect (10, 25, 1000, 20), output);
	}

	void Start() {
		myTime = PlayerPrefs.GetFloat ("finalScore");
		output = "Time played: " + myTime.ToString();
	}
}
