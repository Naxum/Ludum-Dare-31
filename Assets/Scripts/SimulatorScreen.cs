using UnityEngine;
using System.Collections;

public class SimulatorScreen : MonoBehaviour 
{
	private Player player;

	private bool playerInside = false;
	private bool simulationLocked = false;

	public Transform playerCrosshair;

	void Start () 
	{
		player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
	}
	
	void Update () 
	{
		if (playerInside && Input.GetButtonDown("Fire1") && !simulationLocked)
		{
			LockPlayerToSimulator();
		}

		if (simulationLocked)
		{
			var movement = Vector2.ClampMagnitude(new Vector2(Input.GetAxis("Horizontal") + Input.GetAxis("Mouse X"), Input.GetAxis("Vertical") + Input.GetAxis("Mouse Y")), 1);
			playerCrosshair.localPosition = new Vector2(Mathf.Clamp(playerCrosshair.localPosition.x + movement.x * Time.deltaTime * 5, -2.3f, 2.3f), Mathf.Clamp(playerCrosshair.localPosition.y + movement.y * Time.deltaTime * 5, -1, 1));
		}
	}

	public void LockPlayerToSimulator()
	{
		simulationLocked = true;

		Debug.Log("Simulation locked!");

		player.LockToSimulation();
	}

	public void BreakPlayerFromSimulator()
	{
		simulationLocked = false;
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.tag != "Player") return;

		playerInside = true;
	}

	void OnTriggerExit(Collider other)
	{
		if (other.tag != "Player") return;

		playerInside = false;
	}
}
