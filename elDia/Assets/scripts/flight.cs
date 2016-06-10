using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class flight : MonoBehaviour {

	public float flyspeed = 4f;
	public float vspeed = 4f;
	public float brakePower = 2f;
	public Camera world;

	private Rect cameraRect = new Rect();

	// Use this for initialization
	void Start () {
		var bottomLeft = world.ScreenToWorldPoint (Vector3.zero);
		var topRight = world.ScreenToWorldPoint (new Vector3 (world.pixelWidth, world.pixelHeight));

		cameraRect = new Rect (
		                 bottomLeft.x,
		                 bottomLeft.y,
		                 topRight.x - bottomLeft.x,
		                 topRight.y - bottomLeft.y);
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 move = new Vector3(Input.GetAxis ("Horizontal") * flyspeed, Input.GetAxis ("Vertical") * vspeed, 0);
		if (move.x < 0) {
			move.x = move.x * brakePower;
		}

		transform.position = transform.position + move;
		transform.position = new Vector3 (
			Mathf.Clamp (transform.position.x, cameraRect.xMin, cameraRect.xMax),
			Mathf.Clamp (transform.position.y, cameraRect.yMin, cameraRect.yMax),
			transform.position.z);

		if (transform.position.x < 0) {
			/*End game*/
			LoadScene (2);
		}
	}

	public void LoadScene(int level)
	{
		PlayerPrefs.SetFloat ("finalScore", DisplayScore.time);
		SceneManager.LoadScene (level);
	}
}
