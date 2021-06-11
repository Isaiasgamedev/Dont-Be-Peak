using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoleDetector : MonoBehaviour
{
	public GameObject Fixed;

	private void OnTriggerStay2D(Collider2D collision)
	{
		if(collision.tag == "Box")
		{
			var x = collision.GetComponent<BoxPushControl>();
			if (x)
			{
				if (!x.Ismoving)
				{
					Fixed.transform.position = x.transform.position;
					x.gameObject.SetActive(false);
					Fixed.SetActive(true);
				}
			}
		}
	}
}
