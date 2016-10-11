using UnityEngine;
using System.Collections;

public class DestroyByBoundary : MonoBehaviour {

	void OnTriggerExit(Collider other)
	{
		if (other.CompareTag ("Floors") || other.CompareTag ("Boundary")) 
		{
			return;
		}
			
		if (other.CompareTag ("Player")) 
		{
			Destroy (other.gameObject);
		}
	}
}
