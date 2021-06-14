using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtDetector : MonoBehaviour
{
	public float Hp;
	public PlayerMovement Playref;
	

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if(collision.tag == "DamagePlayer")
		{
			if(Playref.PlayerStatesNow != PlayerMovement.PlayerStates.Isdamage)
			{
				StartCoroutine(Playref.HurtState());
				Playref.PointsRef.LessPoints(100);
			}			
		}
	}
}
