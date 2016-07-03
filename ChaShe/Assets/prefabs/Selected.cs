using UnityEngine;
using System.Collections;

public class Selected : MonoBehaviour {

	public bool _bIsSelected = true;
	public bool selected = true;
	//http://answers.unity3d.com/questions/411793/selecting-a-game-object-with-a-mouse-click-on-it.html
	public GameObject mySelect;

	void OnDrawGizmos()
	{
		if (_bIsSelected)
			OnDrawGizmosSelected();
	}


	void OnDrawGizmosSelected()
	{
		Gizmos.color = Color.yellow;
		Gizmos.DrawSphere(transform.position, 0.1f);  //center sphere
		if (GetComponent<Renderer>() != null)
			Gizmos.DrawWireCube(transform.position, GetComponent<Renderer>().bounds.size);
	}

	void Update () {
		if (transform.tag.Equals("select")) {
			mySelect.SetActive (true);
		} else {
			mySelect.SetActive (false);
		}
	}
}
