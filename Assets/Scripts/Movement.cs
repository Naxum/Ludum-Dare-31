using UnityEngine;
using System.Collections;

[RequireComponent(typeof(CharacterController))]
public class Movement : MonoBehaviour 
{
	[HideInInspector]
	public CharacterController cc;

	public Vector3 moveDir = Vector3.zero;
	public float speed = 1;

	void Start () 
	{
		this.cc = GetComponent<CharacterController>();
	}
	
	void Update () 
	{
		moveDir = new Vector3(Input.GetAxis("Horizontal"), -1, Input.GetAxis("Vertical"));
		this.cc.Move(Quaternion.LookRotation(transform.forward) * moveDir * Time.deltaTime * speed * 2.5f);
	}
}
