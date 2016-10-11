using UnityEngine;
using System.Collections;

public class DestroyByBoundary : MonoBehaviour {

	private GameController gameController;

	void Start()
	{
		// Looks for the GameController (which should be appropriately tagged as such)
		// and if it is found, sets it as a GameObject.
		// Doing this will allow us to use the GameController's script's (public) methods
		// such as for the one needed for the GameOver() methid (see OnTriggerExit below)
		GameObject gameControllerObject = GameObject.FindWithTag ("GameController");
		if (gameControllerObject != null) 
		{
			gameController = gameControllerObject.GetComponent<GameController> ();
		}
		if (gameController == null) 
		{
			Debug.Log ("Cannot find 'GameController' script (within the scene).");
		}
	}

	void OnTriggerExit(Collider other)
	{
		if (other.CompareTag ("Floors") || other.CompareTag ("Boundary")) 
		{
			return;
		}
			
		if (other.CompareTag ("Player")) 
		{
			gameController.GameOver(); // Calls the method of the GameController we retrieved at Start()
			Destroy (other.gameObject);
		}
	}
}
