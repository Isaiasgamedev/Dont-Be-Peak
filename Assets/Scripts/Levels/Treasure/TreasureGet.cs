using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreasureGet : MonoBehaviour
{
	public int Points;
	public Animator anim;
	public AudioSource Audio;

	public void GetTreasure()
	{
		anim.Play("treasure");
		Audio.Play();
	}

	public void DesactiveTreasure()
	{
		this.gameObject.SetActive(false);
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if(collision.tag == "Player")
		{
			var x = collision.gameObject.GetComponentInChildren<PointsManager>();
			if (x)
			{
				x.GetPoints(Points);
			}
			GetTreasure();
		}
	}
}
