using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class invecibleActivate : MonoBehaviour
{
	

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if(collision.gameObject.layer == 7)
		{
			collision.gameObject.GetComponent<BaseEnemy>().DoDead();
			PointsManager.instance.GetPoints(200);
		}
	}
}
