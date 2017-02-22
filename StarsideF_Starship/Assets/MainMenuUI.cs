using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Text;

/*
 * This class is to manage the UI for the Starside F application
 * 
 * Created by Andrew Smith 2/21/2017
*/

public class MainMenuUI : MonoBehaviour {

	/*UI Variables/**/
	public Canvas designCanvas;

	// Use this for initialization
	void Start () {
		designCanvas.gameObject.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	//================================================= UI BUTTON ACTIONS
	/*These methods are called when the various buttons on the screen are clicked/**/

	public void createFleet () {
		/*TODO: Develop code for creating a Starship Fleet*/
		return;
	}

	public void designStarship () {
		designCanvas.gameObject.SetActive(true);
	}

	public void exitApp () {
		Application.Quit ();
	}

	//---------------------------- Starship Design Buttons
	public void newDesign () {
		/*TODO: Load the Starship design scene without any preset information*/
		UnityEngine.SceneManagement.SceneManager.LoadScene ("starshipDesigner");
		return;
	}

	public void loadDesign () {
		/*TODO: load the scene that displays all available Starships*/
		return;
	}

	public void exitDesign () {
		designCanvas.gameObject.SetActive(false);
	}

	//---------------------------- Starship Design Buttons (END)

	//================================================= UI BUTTON ACTIONS (END)

}
