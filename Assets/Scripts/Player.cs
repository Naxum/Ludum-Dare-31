using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Player : MonoBehaviour 
{
	private SimulatorScreen simScreen;
	private bool lockedToSimulation = false;

	private Vector3 cameraRot = Vector3.zero;

	private List<MonoBehaviour> movementControls = new List<MonoBehaviour>();
	private bool movementEnabled = false;

	// Use this for initialization
	void Start () 
	{
		simScreen = GameObject.FindGameObjectWithTag("SimulationScreen").GetComponent<SimulatorScreen>();

		movementControls.Add(GetComponentInChildren<Movement>());

		foreach (MouseLook ml in GetComponentsInChildren<MouseLook>())
		{
			movementControls.Add(ml);
		}

		if (!movementEnabled)
		{
			EnableMovement(true);
			StealMouse(true);
		}

		//Debug.Log("Found " + movementControls.Count + " movement controls."); //should be 3-4
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (lockedToSimulation)
		{
			if (Input.GetButtonDown("Cancel"))
			{
				BreakFromSimulation();
			}
		}
		else
		{
			if (Input.GetButtonDown("Cancel"))
			{
				StealMouse(false);
				EnableMovement(false);
			}
			else if (Input.GetButtonDown("Fire1")) //or controller?
			{
				EnableMovement(true);
				StealMouse(true);
			}
		}
	}

	public void StealMouse(bool steal)
	{
		Screen.lockCursor = steal;
	}

	void LateUpdate()
	{
		if (lockedToSimulation)
		{
			Camera.main.transform.LookAt(simScreen.playerCrosshair);
		}
	}

	public void LockToSimulation()
	{
		lockedToSimulation = true;
		EnableMovement(false);
		cameraRot = Camera.main.transform.rotation.eulerAngles;
	}

	public void BreakFromSimulation()
	{
		lockedToSimulation = false;
		simScreen.BreakPlayerFromSimulator();
		EnableMovement(true);
		StealMouse(true);
		Camera.main.transform.rotation = Quaternion.Euler(cameraRot);
	}

	void EnableMovement(bool enable)
	{
		foreach(MonoBehaviour mc in movementControls)
		{
			mc.enabled = enable;
		}
	}
}
