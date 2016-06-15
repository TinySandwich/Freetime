using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class NewShe : MonoBehaviour {

	public void onClick () {
		//Check saved

		SceneManager.LoadScene (1);
		CreateNewSheet ();

		//Update saved as false
		//Update loaded as true
	}

	public void CreateNewSheet(){
		//Load an empty WorkSpace


		return;
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	}
}
