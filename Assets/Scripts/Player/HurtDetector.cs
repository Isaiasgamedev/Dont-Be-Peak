using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtDetector : MonoBehaviour
{
	public int Hp;
	public PlayerMovement Playref;

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if(collision.tag == "DamagePlayer")
		{					
			StartCoroutine(Playref.HurtState());
		}
	}
}
