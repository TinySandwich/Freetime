using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class DisplayScore : MonoBehaviour {

	public static float time;
	private string output = "";

	void OnGUI(){
		/*GUIStyle myStyle = new GUIStyle();
		myStyle.fontSize = 24;
		myStyle.fontStyle = FontStyle.Bold;
		myStyle.clipping = TextClipping.Overflow;
		GUI.color = Color.white;
		GUI.Label (new Rect (10, 25, 1000, 20), output, myStyle);*/
		GUI.Label (new Rect (10, 25, 1000, 20), output);
	}

	// Update is called once per frame
	void Update () {
		time = Time.timeSinceLevelLoad;
		output = "Time played: " + time.ToString();
	}
}
