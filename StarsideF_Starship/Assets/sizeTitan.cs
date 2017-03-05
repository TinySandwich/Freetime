using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sizeTitan : Size {
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

	public sizeTitan () {
		maxSubSyst = 7;
		slotsBrig = 3;
		slotsInf = 3;
		armorTierLevel = new armorTier(4); 
		mountSizeAdj = 3;
		speed = 4;
		diceEva = new Dice (0, 6);
		diceMass = new Dice (0, 12);
		specials = new List<Special>();
		minArea = 8;
		maxArea = 16;
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
