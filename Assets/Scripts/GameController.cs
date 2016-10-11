using UnityEngine;
using UnityEngine.SceneManagement; // Needed to load Scenes, as opposed to obsolete Application class (see Update())
using System.Collections;

public class GameController : MonoBehaviour 
{

	public GameObject[] floors;
	public Vector3 spawnValues;
	public int floorCount;
	public float spawnWait;
	public float startWait;
	public float waveWait;

	private bool gameOver;
	private bool restart;

	public float restartFloorSpeed = 2;

	// Method called before the frames are loaded
	void Start() 
	{
		gameOver = false;
		restart = false;
		StartCoroutine (FloorWaves ()); // Note: Coroutine used with IEnumerator
	}

	void Update()
	{
		if (restart)
		{
			if (Input.GetKeyDown (KeyCode.R))
			{
				for (int i = 0; i < floors.Length; i++)
				{
					floors [i].GetComponent<FloorMovement> ().floorSpeed = restartFloorSpeed;
				}

				SceneManager.LoadScene ("ColorDrop", LoadSceneMode.Single);
				//SceneManager.LoadScene (SceneManager.GetActiveScene ().name); // or .buildIndex
				//Application.LoadLevel (Application.loadedLevel); // Obsolete method
			}
		}
	}

	IEnumerator FloorWaves ()
	{
		Debug.Log ("Floor Waves Start");
		//start wait so that player has time to get ready, no decreasing value here
		yield return new WaitForSeconds (startWait);
		while (true)
		{
			GameObject floor = floors[0]; // Instantiating the floor to stop the compiler from screaming!
			Debug.Log ("While Statement Activates");
			for (int i = 0; i < floorCount; i++)
			{
				Debug.Log ("Floor Generator Starts?");
				// Here occurs the more important instantiation (grabbing a random floor from the array of floors)
				floor = floors[Random.Range(0, floors.Length)];
				Vector3 spawnPosition = new Vector3 (spawnValues.x, spawnValues.y, spawnValues.z); //spawn position for floors
				Quaternion spawnRotation = Quaternion.identity; //needed quaternion values for the instatiate? Not sure if used
				Instantiate (floor, spawnPosition, spawnRotation); //I believe this spawns the floors
				yield return new WaitForSeconds (spawnWait); //needs to add a decreasing spawnWait timer
			}
			yield return new WaitForSeconds (waveWait); //needs to add a decreasing waveWait timer

			Debug.Log ("Floor Speed Increasing by:" + floor.GetComponent<FloorMovement>().speedIncrement);
			// Increase the speed of the floors for the following wave by affecting the prefab's
			// attached script directly.
			for (int i = 0; i < floors.Length; i++) 
			{
				// Getting the GameObject floor's attached Script component
				// and incrementing the floor speed by a fixed amount for each floor
				// at each index 'i' of the array 'floors'
				floors[i].GetComponent<FloorMovement>().IncreaseFloorSpeed();
			}

			if (gameOver)
			{
				restart = true;
				break;
			}
		}
	}

	public void GameOver()
	{
		gameOver = true;
	}

	// Note: that floor has to be public
//	GameObject RandomFloorColor(GameObject floor)
//	{
//		Debug.Log ("Enter RandomFloorColor method");
//		if (!floor.Equals(null)) {
//			floor.GetComponent<Renderer> ().material.color = Color.green;
//			return floor;
//		}
//		return floor;
//	}
}
