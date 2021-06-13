using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerInvencible : MonoBehaviour
{
	public Animator anim;
	public HabilitysPlayer.Powers PowerRef;

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.tag == "Player")
		{
			anim.Play("GetSkull");
			HabilityManager.instance.AddPower(PowerRef);
		}
	}	

	public void desactive()
	{
		this.gameObject.SetActive(false);
	}
}
