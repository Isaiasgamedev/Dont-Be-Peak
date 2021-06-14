using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spike : MonoBehaviour
{
	public Transform Return;
	public Animator anim;
	public float StartTimer;


	private void Start()
	{
		StartCoroutine(StartSpike());
	}

	public IEnumerator StartSpike()
	{
		yield return new WaitForSeconds(StartTimer);

		StartCoroutine(Desactivatedspike());
	}

	public IEnumerator Activatedspike()
	{

		anim.Play("Activated");

		yield return new WaitForSeconds(8);

		StartCoroutine(Desactivatedspike());		
	}

	public IEnumerator Desactivatedspike()
	{

		anim.Play("Desactivated");

		yield return new WaitForSeconds(8);

		StartCoroutine(Activatedspike());

	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if(collision.tag == "Player")
		{
			var x = collision.gameObject.GetComponent<PlayerMovement>();
			if (x)
			{				
				x.LastPositionReturn(Return);
				StartCoroutine(x.HurtState());
				x.PointsRef.LessPoints(100);
			}
		}
	}
}
