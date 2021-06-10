using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallDetectSide : MonoBehaviour
{
	public bool Blocked;	

	private void OnTriggerStay2D(Collider2D collision)
	{
		if(collision.gameObject.layer == 3)
		{
			Blocked = true;
		}
	}

	private void OnTriggerExit2D(Collider2D collision)
	{
		if (collision.gameObject.layer == 3)
		{
			Blocked = false;
		}
	}
}
