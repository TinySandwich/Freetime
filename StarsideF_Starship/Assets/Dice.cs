using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dice {
	int numDice;
	int sizeDice;

	public Dice () {
		numDice = 0;
		sizeDice = 0;
	}

	public Dice(int num, int type) {
		numDice = num;
		sizeDice = type;
	}

	public int rollDice() {
		int total = 0;
		for (int i = 0; i < numDice; i++) {
			total += Random.Range (1, sizeDice); //each die has a value between 1 and the size
		}
		return total;
	}

	public string toString () {
		return numDice.ToString() + "d" + sizeDice.ToString ();
	}
}
