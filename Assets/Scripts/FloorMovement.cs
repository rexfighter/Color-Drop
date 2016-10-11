using UnityEngine;
using System.Collections;

public class FloorMovement : MonoBehaviour 
{
	private Rigidbody rb;
	public float floorSpeed;
	public float speedIncrement;

	//Changes the speed of the floor

	void Start ()
	{
		rb = GetComponent<Rigidbody> ();
		rb.velocity = transform.up * floorSpeed;
	}

	public void IncreaseFloorSpeed()
	{
		floorSpeed = floorSpeed + speedIncrement;
	}
}