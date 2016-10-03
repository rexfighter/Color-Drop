using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour 
{

	public GameObject floor;
	public Vector3 spawnValues;
	public int floorCount;
	public float spawnWait;
	public float startWait;
	public float waveWait;

	void Start() 
	{
		StartCoroutine (FloorWaves ());
	}

	IEnumerator FloorWaves ()
	{
		Debug.Log ("Floor Waves Start");
		//start wait so that player has time to get ready, no decreasing value here
		yield return new WaitForSeconds (startWait);
		while (true)
		{
			Debug.Log ("While Statement Activates");
			for (int i = 0; i < floorCount; i++)
			{
				Debug.Log ("Floor Generator Starts?");
			//enter random color code here
			//GameObject hazard = hazards Random
			Vector3 spawnPosition = new Vector3 (spawnValues.x, spawnValues.y, spawnValues.z); //spawn position for floors
			Quaternion spawnRotation = Quaternion.identity; //needed quaternion values for the instatiate? Not sure if used
			Instantiate (floor, spawnPosition, spawnRotation); //I believe this spawns the floors
			yield return new WaitForSeconds (spawnWait); //needs to add a decreasing spawnWait timer
			}
		yield return new WaitForSeconds (waveWait); //needs to add a decreasing waveWait timer
		}
	}
}
