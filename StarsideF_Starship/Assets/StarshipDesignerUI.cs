using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using System.IO;

/*
 * This class is to manage the UI for the Starside F Starship Application
 * 
 * Created by Andrew Smith 2/21/2017
*/

public class StarshipDesignerUI : MonoBehaviour {

	/*UI Variables/**/
	public Dropdown chassisDropdown;
	public Dropdown sizeDropdown;
	public InputField specialField;

	/*internal Variables*/
	private StarshipCollection myStarships;
	private Starship selectedStarship;

	private bool loaded = false;

	// Use this for initialization
	void Start () {
		myStarships = StarshipCollection.Load(Path.Combine(Application.dataPath, "XML/StarshipTemp.xml"));
		selectedStarship = myStarships.Starships [0];
		setChassisDropdown ();
		setSizeDropdown ();

		loaded = true;
	}
	
	// Update is called once per frame
	void Update () {
		if (loaded) {
			specialField.text = selectedStarship.desc;
		}
	}

	//=========================================================================== UI ACTIONS
	/*These methods are called when the various buttons on the screen are clicked/**/
	public void saveDesign () {
		/*TODO: save the Starship stats in XML*/
		return;
	}

	public void loadDesign () {
		/*TODO: load the scene that displays all available Starships*/
		return;
	}

	public void exitDesign () {
		/*TODO: load the previous scene*/
		UnityEngine.SceneManagement.SceneManager.LoadScene ("MainMenuScene");
		return;
	}

	/*If one of the two dropdown menus change do the following:*/
	public void DropdownUpdate () {
		/*Create a new starship using the selected weapons, subsystems, and the new Starship (chassis + size)*/
		/*selectedStarship = new Starship (weapons, subsys, myStarships.Starships[chassisDropdown.value], sizeDropdown.value)/**/
		selectedStarship = myStarships.Starships[chassisDropdown.value];
	}

	//=========================================================================== UI ACTIONS (END)

	//============================= Internal Methods
	private void setChassisDropdown () {
		chassisDropdown.ClearOptions ();

		List<string> myChassis = new List<string>();

		/*After creating the Starship collection run through the array and grab the chassis company + name*/
		foreach(Starship thisStarship in myStarships.Starships) {
			myChassis.Add (thisStarship.myCompany + " " + thisStarship.myChassis);
		}
		//List<string> myChassis = convStarString ();
		chassisDropdown.AddOptions (myChassis);
	}

	private void setSizeDropdown () {
		sizeDropdown.ClearOptions ();
		List<string> mySizes = new List<string> ();
		mySizes.Add ("Destroyer");
		mySizes.Add ("Cruiser");
		mySizes.Add ("Titan");
		sizeDropdown.AddOptions (mySizes);
	}

	//============================= Internal Methods (END)
}
