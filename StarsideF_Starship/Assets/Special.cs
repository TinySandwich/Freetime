using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Special {
	private string myName; //The Special's name
	private string myDesc; //The Special's description

	public Special () {
		myName = "";
		myDesc = "";
	}

	public Special (string newName, string newDesc) {
		myName = newName;
		myDesc = newDesc;
	}

	public void setName (string newName) {
		myName = newName;
	}

	public string getName () {
		return myName;
	}

	public void setDesc (string newDesc) {
		myDesc = newDesc;
	}

	public string getDesc () {
		return myDesc;
	}
}
