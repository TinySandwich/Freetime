using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sizeDestroyer : Size {
	public int maxSubSyst { get; set; }
	public int slotsBrig { get; set; }
	public int slotsInf { get; set; }
	public armorTier armorTierLevel { get; set; }
	public int mountSizeAdj { get; set; }
	public int speed { get; set; }
	public Dice diceEva { get; set; }
	public Dice diceMass { get; set; }
	public List<Special> specials { get; set; }
	public int minArea { get; set; } //smallest area for the Starship of this Size Classification
	public int maxArea { get; set; } //largest area for the Starship of this Size Classification

	public sizeDestroyer() {
		maxSubSyst = 3;
		slotsBrig = 1;
		slotsInf = 1;
		armorTierLevel = new armorTier(2);
		mountSizeAdj = 0;
		speed = 8;
		diceEva = new Dice (0, 10);
		diceMass = new Dice (0, 8);
		specials = new List<Special>();
		minArea = 1;
		maxArea = 4;
	}

	public int getDamRed () { //Get Damage reduction, which is determined by the armorLevel
		return armorTierLevel.getDamRed();
	}

	public double getDamPD () { //Returns the amount of damage the Starship would take against PD weapons
		return armorTierLevel.getDamPD();
	}

	public double getMinArea (int ratio) {
		return Mathf.Sqrt (minArea / ratio);
	}

	public double getMaxArea (int ratio) {
		return Mathf.Sqrt (maxArea / ratio);
	}
}
