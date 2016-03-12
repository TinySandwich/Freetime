using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class fireScript : MonoBehaviour {

	public float bulletSpeed = 50;
	public Rigidbody2D bCharge1;
	public Rigidbody2D bCharge2;
	public Rigidbody2D bCharge3;
	public Rigidbody2D bullet1;
	public Rigidbody2D bullet2;
	public Rigidbody2D bullet3;
	public Light plasmaLight;
	private bool charging = false;
	private Rigidbody2D bulletClone = new Rigidbody2D ();
	private int curCharge = 0;
	private int curStage = 1;
	public int stage2 = 250;
	public int stage3 = 500;
	string output = "";

	void OnGUI(){
		GUI.Label (new Rect (10, 10, 1000, 20), output);
	}

	void Fire(Rigidbody2D bulletClone)
	{
		// Determine vector between mouse and player
		var mouse = Input.mousePosition;
		var screenPoint = Camera.main.WorldToScreenPoint (transform.position);
		var offset = new Vector2 (mouse.x - screenPoint.x, mouse.y - screenPoint.y);

		// Normalize vector
		float length = Mathf.Sqrt ((offset.x * offset.x) + (offset.y * offset.y));
		offset.x = offset.x / length;
		offset.y = offset.y / length;

		// Destroy the charging object
		Destroy(bulletClone.gameObject);
		if (curStage == 1)
			bulletClone = (Rigidbody2D)Instantiate (bullet1, transform.position, transform.rotation);
		else if (curStage == 2)
			bulletClone = (Rigidbody2D)Instantiate (bullet2, transform.position, transform.rotation);
		else if (curStage == 3)
			bulletClone = (Rigidbody2D)Instantiate (bullet3, transform.position, transform.rotation);
		
		// Multiply vector by speed of bullet
		bulletClone.velocity = offset * bulletSpeed;
		Physics.IgnoreLayerCollision (2, 3, true);
	}

	void Update () 
	{
		/*When the fire button is click start charging*/
		if (Input.GetButtonDown ("Fire1")) { 
			charging = true;
			bulletClone = (Rigidbody2D)Instantiate (bCharge1, transform.position, transform.rotation);
			//plasmaLight.transform.position = transform.position;
			plasmaLight.intensity = 2;
		} 

		/*When the fire button is released fire the charged bolt*/
		else if (Input.GetButtonUp ("Fire1")) { 
			charging = false;
			Fire (bulletClone);
			curStage = 1;
			curCharge = 0;
			plasmaLight.intensity = 0;
		} 

		/*As the plasma is charged it begins to grow/**/
		else if (charging) { 
			curCharge++;
			bulletClone.transform.position = transform.position;
			//plasmaLight.transform.position = transform.position;
			plasmaLight.intensity = curStage * 2;

			if (curCharge >= stage2 && curCharge < stage3 && curStage != 2) { 
				curStage = 2;
				Destroy (bulletClone.gameObject);
				bulletClone = (Rigidbody2D)Instantiate (bCharge2, transform.position, transform.rotation);

			} else if (curCharge >= stage3 && curStage != 3) {
				curStage = 3;
				Destroy (bulletClone.gameObject);
				bulletClone = (Rigidbody2D)Instantiate (bCharge3, transform.position, transform.rotation);
			}
		}

		// Debugging info
		output = " curCharge: " + curCharge +
			" curStage: " + curStage + 
			" light.intensity: " + plasmaLight.intensity +
			" light.position: " + plasmaLight.transform.position.x;
	}
}