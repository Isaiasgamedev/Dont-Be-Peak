using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeysControl : MonoBehaviour
{
	public DoorsBehavior DoortoOpen;
	public Animator anim;

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if(collision.tag == "Player")
		{
			GetKey();
		}
	}

	public void GetKey()
	{
		anim.Play("Get");
	}

	public void OpendDoor()
	{
		DoortoOpen.OpendDoor();
	}
}
