using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeysControl : MonoBehaviour
{
	public DoorsBehavior[] DoortoOpen;
	public Animator anim;
	public KeysPlayer.Keys KeyRef;
	public bool NeedKey;
	public AudioSource Audio;

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if(collision.tag == "Player")
		{
			GetKey();
			if (NeedKey)
			{
				KeysManager.instance.AddKeyNow(KeyRef);
			}
				
		}
	}

	public void GetKey()
	{
		if(anim != null)
		{
			anim.Play("Get");
			PointsManager.instance.GetPoints(500);
			Audio.Play();
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
