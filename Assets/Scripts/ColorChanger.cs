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
		//when you press A, the cube changes color to red
		if(Input.GetKeyDown(KeyCode.A))
		{
			rend.material.color = Color.red;
		}

		//when you press S, the cube changes color to blue
		if (Input.GetKeyDown (KeyCode.S))
		{
			rend.material.color = Color.blue;
		}

		//when you press D, the cube changes color to yellow
		if(Input.GetKeyDown(KeyCode.D))
		{
			rend.material.color = Color.yellow;
		}
	}
}
