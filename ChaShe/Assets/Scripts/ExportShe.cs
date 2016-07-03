using UnityEngine;
using System.Collections;
using System.IO;

public class ExportShe : MonoBehaviour {

	public GameObject myUI;
	public int resWidth = 2550;
	public int resHeight = 3300;
	public Camera myCamera;

	//private bool takeHiResShot = false;

	private string output = "";

	void OnGUI() {
		GUIStyle myStyle = new GUIStyle();
		myStyle.fontSize = 24;
		myStyle.fontStyle = FontStyle.Bold;
		myStyle.clipping = TextClipping.Overflow;
		GUI.color = Color.black;
		GUI.Label (new Rect (10, 25, 1000, 20), output, myStyle);
	}

	public void ShowExplorer(string itemPath)
	{
		itemPath = itemPath.Replace (@"/", @"\");
		System.Diagnostics.Process.Start ("explorer.exe", "/select," + itemPath);
	}

	public static string ScreenShotName (int width, int height) {
		#if UNITY_EDITOR
		return UnityEditor.EditorUtility.SaveFilePanel ("screenShot", "{0}", "mySheet", "png");
		#endif

		return Application.dataPath + "/myScreen.png";
		/*return string.Format ("{0}/saves/screen_{1}x{2}_{3}.png,
			Application.dataPath,
			width, height,
			System.DateTime.Now.ToString ("yyyy-MM-dd_HH-mm-ss"));/**/
	}

	public void onClick() {
		string filename = "";
		filename = ScreenShotName (resWidth, resHeight);

		if (filename != "") {
			myCamera.gameObject.SetActive (true);
			myUI.SetActive (false);
			RenderTexture rt = new RenderTexture (resWidth, resHeight, 24);
			myCamera.targetTexture = rt;
			Texture2D screenShot = new Texture2D (resWidth, resHeight, TextureFormat.RGB24, false);
			myCamera.Render ();
			RenderTexture.active = rt;
			screenShot.ReadPixels (new Rect (0, 0, resWidth, resHeight), 0, 0);
			myCamera.targetTexture = null;
			RenderTexture.active = null;
			Destroy (rt);
			byte[] bytes = screenShot.EncodeToPNG ();
			System.IO.File.WriteAllBytes (filename, bytes);
			Debug.Log (string.Format ("Saved worspace to: {0}", filename));

			myUI.SetActive (true);
			myCamera.gameObject.SetActive (false);
			//output = "File saved to: " + filename;
		}
	}

/*	public IEnumerator onClick () {
		//Create texture for export
		yield return UploadPNG();

		//Save exported .png to computer
	}

	IEnumerator UploadPNG() {
		yield return new WaitForEndOfFrame ();

		int width = Screen.width;
		int height = Screen.height;
		Texture2D tex = new Texture2D (width, height, TextureFormat.RGB24, false);

		//Hide the menu and UI
		myUI.SetActive(false);

		// Read the screen's contents
		tex.ReadPixels (new Rect (0, 0, width, height), 0, 0);
		tex.Apply ();

		// Display menu and UI
		myUI.SetActive(true);

		byte[] bytes = tex.EncodeToPNG ();
		Object.Destroy (tex);

		// For testing, save it to the application location
		File.WriteAllBytes (Application.dataPath + "/../SavedScreen.png", bytes);

		WWWForm form = new WWWForm ();
		form.AddField ("frameCount", Time.frameCount.ToString ());
		form.AddBinaryData ("fileUpload", bytes);

		WWW w = new WWW ("http://localhost/cgi-bin/env.cgi?post", form);
		yield return w;

		if (w.error != null) {
			Debug.Log (w.error);
		} else {
			Debug.Log ("Finished Uploading Screenshot");
		}
	}/**/
}
