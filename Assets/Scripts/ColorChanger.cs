using UnityEngine;
using System.Collections;

public class ColorChanger : MonoBehaviour {

	public Renderer rend;

	void Start()
	{
		rend = GetComponent<Renderer> ();
	}

	void Update()
	{
		// When you press A, the cube changes color to red
		if(Input.GetKeyDown(KeyCode.A))
		{
			rend.material.color = Color.red;
		}

		// When you press S, the cube changes color to blue
		if (Input.GetKeyDown (KeyCode.S))
		{
			rend.material.color = Color.blue;
		}

		// When you press D, the cube changes color to yellow
		// For some reason the RGBA values of yellow dont match the RGBA values that occur in the Unity Inspector
		// Not sure how to get the exact yellow...or is it a bug?
		// Note: Yellow RGBA values are (1, 0.92, 0.016, 1); how the hell to convert to a 0-255 scale?
		if(Input.GetKeyDown(KeyCode.D))
		{
			rend.material.color = Color.yellow;
			//rend.material.color = new Color(1f, 0.92f, 0.016f, 1f);
		}

		// When you press E, the cube changes color to green
		// Note; The location of E is like saying by combining S and D (blue and yellow) you get green!
		if (Input.GetKeyDown (KeyCode.E))
		{
			rend.material.color = Color.green;
		}

		// Press Q = magenta cube; note: RGBA values are (1, 0, 1, 1), thus, easy to convert from (255, 0, 255, 255)
		if (Input.GetKeyDown (KeyCode.Q)) 
		{
			rend.material.color = Color.magenta;
		}
	}
}
