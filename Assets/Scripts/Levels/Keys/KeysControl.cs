using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeysControl : MonoBehaviour
{
	public DoorsBehavior[] DoortoOpen;
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
		if(anim != null)
		{
			anim.Play("Get");
		}
		else
		{
			OpendDoor();
		}
		
	}

	public void OpendDoor()
	{
		for (int i = 0; i < DoortoOpen.Length; i++)
		{
			DoortoOpen[i].OpendDoor();
		}
		
	}
}
