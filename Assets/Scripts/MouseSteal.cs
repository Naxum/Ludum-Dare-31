using UnityEngine;
using System.Collections;

public class MouseSteal : MonoBehaviour 
{
	bool mouseStolen = false;

	void Start () 
	{
		StealMouse(true);
	}
	
	void Update () 
	{
		if (Input.GetKeyDown(KeyCode.Escape))
		{
			StealMouse(false);
		}
		else if (Input.GetAxis("Fire1") != 0) //or controller?
		{
			StealMouse(true);
		}
	}

	void StealMouse(bool steal)
	{
		Screen.lockCursor = steal;

		foreach (MouseLook ml in GetComponentsInChildren<MouseLook>())
		{
			ml.enabled = steal;
		}

		GetComponentInChildren<Movement>().enabled = steal;
	}
}
