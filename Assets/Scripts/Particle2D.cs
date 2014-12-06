using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
public class Particle2D : MonoBehaviour 
{

	void Start () 
	{
		GetComponent<ParticleSystem>().renderer.sortingLayerName = "FX";
		GetComponent<ParticleSystem>().renderer.sortingOrder = 2;
	}
	
}
