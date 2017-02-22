using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Text;

/*
 * This class is to manage the UI for the Starside F Starship Application
 * 
 * Created by Andrew Smith 2/21/2017
*/

public class StarshipDesignerUI : MonoBehaviour {

	/*UI Variables/**/
	public Dropdown chassisDropdown;
	public Dropdown sizeDropdown;

	// Use this for initialization
	void Start () {
		setChassisDropdown ();
		setSizeDropdown ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	//================================================= UI BUTTON ACTIONS
	/*These methods are called when the various buttons on the screen are clicked/**/


	//================================================= UI BUTTON ACTIONS (END)

	//============================= Internal Methods
	private void setChassisDropdown () {
		chassisDropdown.ClearOptions ();
		List<string> myChassis = new List<string> ();
		myChassis.Add ("--CHOOSE--");
		chassisDropdown.AddOptions (myChassis);
	}

	private void setSizeDropdown () {
		sizeDropdown.ClearOptions ();
		List<string> mySizes = new List<string> ();
		mySizes.Add ("--CHOOSE--");
		mySizes.Add ("Destroyer");
		mySizes.Add ("Cruiser");
		mySizes.Add ("Titan");
		sizeDropdown.AddOptions (mySizes);
	}

	//============================= Internal Methods (END)
}
