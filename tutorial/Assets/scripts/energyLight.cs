using UnityEngine;
using System.Collections;

public class energyLight : MonoBehaviour {
	public Light myLight;
	private Light moveLight = new Light();

	// Use this for initialization
	void Start () {
		moveLight = (Light)Instantiate (myLight, transform.parent.position, transform.parent.rotation);
		moveLight.intensity = 4;
	}
	
	// Update is called once per frame
	void Update () {
		//if(moveLight.transform.parent.

		//moveLight.transform.position = moveLight.transform.parent.transform.position;
	}
}
