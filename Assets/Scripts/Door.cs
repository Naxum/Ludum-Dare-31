using UnityEngine;
using System.Collections;

public class Door : MonoBehaviour 
{
	public Vector3 slidePosition = new Vector3(5, 0, 0);
	public Transform doorToSlide;

	public float slideDuration = 0.25f;
	public AnimationCurve slideCurve = AnimationCurve.EaseInOut(0, 0, 1, 1);
	public bool accessGranted = false;

	private bool sliding = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider other)
	{
		accessGranted = true;

		if (!sliding && accessGranted)
		{
			sliding = true;

			StartCoroutine(SlideDoor());
		}
	}

	void OnTriggerExit(Collider other)
	{
		accessGranted = false;
	}

	IEnumerator SlideDoor()
	{
		float progress = 0;

		while (true)
		{
			progress = Mathf.Clamp(progress + Time.deltaTime * (accessGranted ? 1 : -1), 0, 1);

			doorToSlide.transform.localPosition = Vector3.Lerp(Vector3.zero, slidePosition, slideCurve.Evaluate(progress));

			if (progress < 0)
			{
				break;
			}

			yield return null;
		}
		
		doorToSlide.transform.localPosition = Vector3.zero;
		sliding = false;
	}
}
