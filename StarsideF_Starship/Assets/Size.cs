using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface Size {
	int maxSubSyst { get; set; }
	int slotsBrig { get; set; }
	int slotsInf { get; set; }
	armorTier armorTierLevel { get; set; }
	int mountSizeAdj { get; set; }
	int speed { get; set; }
	Dice diceEva { get; set; }
	Dice diceMass { get; set; }
	List<Special> specials { get; set; }
	int minArea { get; set; }
	int maxArea { get; set; }

	int getDamRed (); //Get Damage reduction, which is determined by the armorLevel
	double getDamPD (); //Returns the amount of damage the Starship would take against PD weapons
	double getMinArea (int ratio);
	double getMaxArea (int ratio);
}
