using UnityEngine;
using System.Collections;
using System.Text;

public class voltMovement : MonoBehaviour {
	/*Variables for jumping*/
	public Vector2 jumpVector = new Vector2( 0f, 60f );
	bool isGrounded;
	bool pressed = false;

	public Transform grounder;
	public float radius = .8415132f;
	public LayerMask foreGround;
	Animator animator;

	public float maxSpeed = 10f;
	bool facingRight = true;
	bool curfacingRight;
	string output = "";
	float hover = -4.5f;

	/*This is voltage's fuel levels*
	public int maxFuel = 100; /*max amount of fuel*
	public int curFuel = 100; /*current fuel level*
	public int lauFuel = 10; /*fuel cost for launching*
	public int hovFuel = 5; /*fuel cost for hovering*
	public int recFuel = 2; /*fuel recovery rate*/

	void OnGUI(){
		GUI.Label (new Rect (10, 10, 1000, 20), output);
	}

	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator> ();
	}

	// Update is called once per frame
	void FixedUpdate () {
		// This provides movement for Voltage
		float move = Input.GetAxis ("Horizontal");
		GetComponent<Rigidbody2D>().velocity = new Vector2 (move * maxSpeed, GetComponent<Rigidbody2D>().velocity.y);

		isGrounded = Physics2D.OverlapCircle (grounder.transform.position, radius, foreGround);

		bool jumping = (Input.GetKey (KeyCode.W) || Input.GetKey (KeyCode.Space));
		bool drop = Input.GetKey (KeyCode.S);

		if (jumping && isGrounded && !pressed) {
			GetComponent<Rigidbody2D> ().AddForce (jumpVector, ForceMode2D.Force);
			pressed = true;
		} else if (jumping && !isGrounded && !pressed) {
			GetComponent<Rigidbody2D> ().velocity = new Vector2 (GetComponent<Rigidbody2D> ().velocity.x, jumpBoost (GetComponent<Rigidbody2D> ().velocity.y));
			pressed = true;
		} else if (drop && !isGrounded && !pressed) {
			GetComponent<Rigidbody2D> ().velocity = new Vector2 (GetComponent<Rigidbody2D> ().velocity.x, dropBoost (GetComponent<Rigidbody2D> ().velocity.y));
			pressed = true;
		} else if (jumping && !isGrounded) {
			GetComponent<Rigidbody2D> ().velocity = new Vector2 (GetComponent<Rigidbody2D> ().velocity.x, hovering (GetComponent<Rigidbody2D> ().velocity.y));
			pressed = true;
		}
		else if (!jumping) {
			pressed = false;
		}

		// This controls the angle the firing arm is point at
		var mouse = Input.mousePosition;
		var screenPoint = Camera.main.WorldToScreenPoint (transform.position);
		var offset = new Vector2 (mouse.x - screenPoint.x, mouse.y - screenPoint.y);
		var angle = Mathf.Atan2 (offset.y, offset.x) * Mathf.Rad2Deg;

		// If Voltage is looking left, the angle of the arm needs to be reversed.
		if (offset.x < 0) {
			curfacingRight = false;
		} 
		// If Voltage is looking right
		else if (offset.x > 0) {
			curfacingRight = true;

		}

		if (curfacingRight != facingRight) {
			facingRight = !facingRight;
			Flip ();
		}

		bool standing = true;

		if (Input.GetKey (KeyCode.D) && facingRight) {
			animator.SetFloat ("Speed", 1); /*Flying forwards to the right*/
		} else if (Input.GetKey (KeyCode.D) && !facingRight) {
			animator.SetFloat ("Speed", -1); /*Flying backwards to the right*/
		} else if (Input.GetKey (KeyCode.A) && facingRight) {
			animator.SetFloat ("Speed", -1); /*Flying backwards to the left*/
		} else if (Input.GetKey (KeyCode.A) && !facingRight) {
			animator.SetFloat ("Speed", 1); /*Flying forwards to the left*/
		} else {
			animator.SetFloat ("Speed", 0); /*Standing Still*/
			standing = true;
		}

		if (standing) {
			animator.SetBool ("Stationary", true);
		}

		// Debugging info
		/*output = /*"offsetX: " + offset.x.ToString() + 
			" thisX: " + transform.position.x.ToString() + 
			" curFace: " + curfacingRight.ToString() + 
			" Face: " + facingRight.ToString() +
			" angle: " + angle.ToString() +s
			" velocity y: " + GetComponent<Rigidbody2D> ().velocity.y;*/
	}

	void Flip(){
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}

	float jumpBoost (float y) {
		if (y > 0)
			return y + .5f;
		return -.5f;
	}

	float hovering (float y) {
		if (y > hover)
			return y;
		return hover;
	}

	float dropBoost (float y) {
		if (y > 0)
			return 0;
		return y - 2;
	}
}
