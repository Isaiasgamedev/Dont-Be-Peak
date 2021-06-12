using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerInvencible : MonoBehaviour
{
	public Animator anim;

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.tag == "Player")
		{
			anim.Play("GetSkull");
			collision.gameObject.GetComponentInChildren<HabilityDetector>().ActiveIvencible();
		}
	}	

	public void desactive()
	{
		this.gameObject.SetActive(false);
	}
}
