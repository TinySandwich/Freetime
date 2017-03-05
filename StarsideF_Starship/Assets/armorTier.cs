using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class armorTier {
	private int level;
	private int[] damRed;
	private double[] damPD;
	private string[] tierTitle;
	private string[] tierAbr;

	public armorTier (int newLevel) {
		level = newLevel;
		damRed = new int[6] {0, 1, 2, 4, 8, 14};
		damPD = new double[6] { 2, 2, 1, .5, .3, .25 };
		tierTitle = new string[6] { "None", "Super Light", "Light", "Medium", "Heavy", "Super Heavy" };
		tierAbr = new string[6] { "-", "SL", "L", "M", "H", "SH" };
	}

	public void setLevel (int newLevel) {
		level = newLevel;
	}

	public int getLevel () {
		return level;
	}

	public int getDamRed () {
		return damRed [level];
	}

	public double getDamPD () {
		return damPD [level];
	}

	public string getTierTitle() {
		return tierTitle [level];
	}

	public string getTierAbr() {
		return tierAbr [level];
	}
}
