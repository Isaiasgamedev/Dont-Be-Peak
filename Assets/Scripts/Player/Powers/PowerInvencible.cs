using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerInvencible : MonoBehaviour
{
	public Animator anim;
	public HabilitysPlayer.Powers PowerRef;
	public AudioSource Audio;

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.tag == "Player")
		{
			anim.Play("GetSkull");
			var x = collision.GetComponent<PlayerMovement>();
			x.Controlhability = 0;
			HudControl.instance.SetImageHability();
			HabilityManager.instance.AddPower(PowerRef);
			Audio.Play();
		}
	}	

	public void desactive()
	{
		this.gameObject.SetActive(false);
	}
}
