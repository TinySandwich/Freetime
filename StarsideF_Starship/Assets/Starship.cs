using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;
using System.Xml.Serialization;

/*
 * This is a Starship object
 * 
 * Created by Andrew Smith 2/23/2017
*/

public class Starship {
	/*internal Variables*/
	/*
	private Mount[] myMounts;
	private Subsystem[] mySubsys;
	/**/
	[XmlAttribute("chassis")]
	public string myChassis; 
	[XmlAttribute("company")]
	public string myCompany;

	public string desc;


	public Starship () {
		myChassis = "TODO:Starship";
	}

	public Starship (string StarshipChassis) {
		setChassis (StarshipChassis);
	}

	/*public Starship (Mount[] newMounts, Subsystem[] mySubsys, Starship newStarship, int size) {
	 * 
	 * }
	 * 
	 * /**/

	/*======================================SETS & GETS*/
	public void setChassis (string newChassis) {
		myChassis = newChassis;
	}
	public string getChassis () {
		return myChassis;
	}



	/*======================================SETS & GETS (END)*/
}
