using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class fireScript : MonoBehaviour {

	public float bulletSpeed = 50;
	public Rigidbody2D Voltage;
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

	public AudioClip charging1;
	public AudioClip charging2;
	public AudioClip charging3;
	public AudioClip fire;

	Animator animator;

	void Start() {
		animator = GetComponent<Animator> ();
	}

	void OnGUI(){
		GUI.Label (new Rect (10, 10, 1000, 20), output);
	}

	/*=================================================================================================*/
	/*Firing plasma*/
	/*=================================================================================================*/
	void Fire(Rigidbody2D bulletClone)
	{
		/* Determine vector between mouse and player */
		Vector3 mouse = Input.mousePosition;
		Vector3 screenPoint = Camera.main.WorldToScreenPoint (transform.position);
		Vector2 offset = setOffset (mouse, screenPoint);
		//var offset = new Vector2 (mouse.x - screenPoint.x, mouse.y - screenPoint.y);

		offset = offset.normalized;

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

	Vector2 setOffset (Vector3 mouse, Vector3 screenPoint)
	{
		float myX = mouse.x - screenPoint.x;
		float myY = mouse.y - screenPoint.y;
		/* 
		 * Try to find a way to determine mouse vs Voltage location from that fix the backward plasma.
		 *
		if ((mouse.x < 230f && mouse.x > screenPoint.x) || (mouse.x >= 230f && mouse.x < screenPoint.x))
			myX = screenPoint.x - mouse.x;
		if ((mouse.y < 330f && mouse.y > screenPoint.y) || (mouse.y >= 330f && mouse.y < screenPoint.y))
			myY = screenPoint.y - mouse.y;
		/**/

		Vector2 myVector = new Vector2(myX, myY);
		return myVector;
	}

	/*=================================================================================================*/
	/*Update*/
	/*=================================================================================================*/
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
		/*
		output = " curCharge: " + curCharge +
			" curStage: " + curStage + 
			" light.intensity: " + plasmaLight.intensity +
			" light.position: " + plasmaLight.transform.position.x;/**/
		var mouse = Input.mousePosition;
		var screenPoint = Camera.main.WorldToScreenPoint (transform.position);
		output = "VolX: " + Voltage.centerOfMass.x +
			" VolY: " + Voltage.transform.position.y +
			" mouseX: " + mouse.x +
			" screenX: " + screenPoint.x +
			" mouseY: " + mouse.y +
			" screenY: " + screenPoint.y;
	}
}