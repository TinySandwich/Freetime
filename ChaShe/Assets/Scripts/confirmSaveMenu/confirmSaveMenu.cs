using UnityEngine;
using System.Collections;
using System.IO;

public class confirmSaveMenu : MonoBehaviour {

	private bool paused = false;
	public GameObject saveMenu;

	public Camera myCamera;
	public GameObject myUI;
	public int resWidth = 2550;
	public int resHeight = 3300;
	public GameObject bg;

	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown ("escape")) {
			saveMenu.SetActive(false);
			paused = false;
		}
	}

	public void onClick() {
		string filename = "";
		filename = GetComponent<ExportShe> ().getScreenShotName (resWidth, resHeight);

		// This check is to make sure the method above did not fail.
		if (filename != "") {
			/*Remove background clutter*/
			myCamera.gameObject.SetActive (true);
			myUI.SetActive (false);
			bg.SetActive (false);

			/*Create the texture itself by taking a rendered screenshot*/
			RenderTexture rt = new RenderTexture (resWidth, resHeight, 24);
			myCamera.targetTexture = rt;
			Texture2D screenShot = new Texture2D (resWidth, resHeight, TextureFormat.RGB24, false);
			myCamera.Render ();
			RenderTexture.active = rt;
			screenShot.ReadPixels (new Rect (0, 0, resWidth, resHeight), 0, 0);
			myCamera.targetTexture = null;
			RenderTexture.active = null;

			/*Memory management, not sure it's necessary*/
			Destroy (rt);
			byte[] bytes = screenShot.EncodeToPNG ();
			System.IO.File.WriteAllBytes (filename, bytes);
			Debug.Log (string.Format ("Saved worspace to: {0}", filename));

			/*Reactivate the background objects*/
			bg.SetActive (true);
			myUI.SetActive (true);
			myCamera.gameObject.SetActive (false);
			Camera newCam = Camera.main.GetComponent<Camera> ();
			RayClick mySelector = newCam.GetComponent<RayClick>();
		}

		PlayerPrefs.DeleteAll ();
		Application.Quit ();
	}
}
