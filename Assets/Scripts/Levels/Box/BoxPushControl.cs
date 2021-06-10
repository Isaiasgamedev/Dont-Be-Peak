using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxPushControl : MonoBehaviour
{
	private void OnCollisionEnter2D(Collision2D collision)
	{
		if(collision.gameObject.tag == "Player")
		{
			var x = collision.gameObject.GetComponent<PlayerMovement>();
			if (x)
			{
				transform.position
			}
		}
	}
}
