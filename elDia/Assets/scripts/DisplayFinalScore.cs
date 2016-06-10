using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class DisplayFinalScore : MonoBehaviour {

	public float myTime;
	private string output = "";
	public string levelName = "";

	void OnGUI(){
		Texture2D textBG = new Texture2D (1, 1);
		textBG.SetPixel (0, 0, Color.black);
		textBG.wrapMode = TextureWrapMode.Repeat;
		textBG.Apply ();

		GUIStyle myStyle = new GUIStyle();
		myStyle.normal.textColor = Color.white;
		myStyle.normal.background = textBG;
		myStyle.fontSize = 24;
		myStyle.fontStyle = FontStyle.Bold;
		myStyle.clipping = TextClipping.Overflow;
		myStyle.padding = new RectOffset (10, 5, 10, 10);
		GUI.Label (new Rect (55, 200, 145, 75), output, myStyle);/**/
		//GUI.Label (new Rect (10, 25, 1000, 20), output);
	}

	void Start() {
		myTime = PlayerPrefs.GetFloat ("finalScore");
		output = "Your Time: \n  " + myTime.ToString();
	}
}
