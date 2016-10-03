using UnityEngine;
using System.Collections;

public class FloorMovement : MonoBehaviour 
{
	private Rigidbody rb;
	public float speed;


	//Changes the speed of the floor

	void Start ()
	{
		rb = GetComponent<Rigidbody> ();
		rb.velocity = transform.up * speed;
	}
}

// create code that increases the speed of the floor over time