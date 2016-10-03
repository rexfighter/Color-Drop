using UnityEngine;
using System.Collections;

//This is script will be the main script for the floor color match ONLY!
//Creating new floors and random colors for floor will be in another script

public class DestroyIfMatch : MonoBehaviour 
{
	//Created shortcut for renderer
	public Renderer rend;

	//Renderer is now the same as rend
	void Start()
	{
		rend = GetComponent<Renderer> ();
	}

	//When player touches the floor...
	void OnCollisionEnter (Collision collision)
	{
		//... and if the players color is the same as the floors color...
		if (rend.material.color == collision.gameObject.GetComponent<Renderer>().material.color)
		{
			//... floor is destroyed!
			Destroy(gameObject);
		}
	}

	void OnTriggerStay (Collider trigger)
	{
		if (rend.material.color == trigger.gameObject.GetComponent<Renderer> ().material.color) 
		{
			Destroy (gameObject);
		}
	}
	//void OnCollisionStay (Collision collision)
	//{
	//
	//	Debug.Log ("The cube touched it");
	//		if (rend.material.color == collision.gameObject.GetComponent<Renderer> ().material.color) {
	//			Destroy (gameObject);
	//			Debug.Log ("It matched!");
	//		}
	//	Debug.Log ("On collision staying");
	//}
			
}
