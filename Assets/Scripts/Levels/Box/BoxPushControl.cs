using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxPushControl : MonoBehaviour
{
	public bool Ismoving;
	public Vector3 Oringpos, Targetpos;
	public float timetomove;
	public WallDetectSide[] SideBlocked;

	private void OnCollisionEnter2D(Collision2D collision)
	{
		if(collision.gameObject.tag == "Player")
		{

			

		}
	}

	

	IEnumerator MovingBox(Vector3 direction)
	{
		Debug.Log("TESTE");
		Ismoving = true;
		float elepsedTime = 0;
		Oringpos = transform.position;
		Targetpos = Oringpos + direction;

		while(elepsedTime < timetomove)
		{
			transform.position = Vector3.Lerp(Oringpos, Targetpos, (elepsedTime / timetomove));
			elepsedTime += Time.deltaTime;
			yield return null;
		}

		transform.position = Targetpos;

		Ismoving = false;
	}

	private void OnTriggerStay2D(Collider2D collision)
	{
		if (collision.tag == "Player")
		{
			//Debug.Log("Player");
			var x = collision.gameObject.GetComponent<PlayerMovement>();
			if (x)
			{
				if (x.PlayerSideNow == PlayerMovement.PlayerSide.up && !Ismoving)
				{
					if (Input.GetButton("Fire1"))
					{
						if (!SideBlocked[0].Blocked)
						{
							//Debug.Log("SIDE = " + x.PlayerSideNow);
							StartCoroutine(MovingBox(Vector3.up));
						}
					}
					
				}

				else if (x.PlayerSideNow == PlayerMovement.PlayerSide.down && !Ismoving)
				{
					if (Input.GetButton("Fire1"))
					{
						if (!SideBlocked[1].Blocked)
						{
							//Debug.Log("SIDE = " + x.PlayerSideNow);
							StartCoroutine(MovingBox(Vector3.down));
						}
					}
						

				}

				else if (x.PlayerSideNow == PlayerMovement.PlayerSide.left && !Ismoving)
				{
					if (Input.GetButton("Fire1"))
					{
						if (!SideBlocked[3].Blocked)
						{
							//Debug.Log("SIDE = " + x.PlayerSideNow);
							StartCoroutine(MovingBox(Vector3.left));
						}
					}
						

				}

				else if (x.PlayerSideNow == PlayerMovement.PlayerSide.right && !Ismoving)
				{
					if (Input.GetButton("Fire1"))
					{
						if (!SideBlocked[2].Blocked)
						{
							//Debug.Log("SIDE = " + x.PlayerSideNow);
							StartCoroutine(MovingBox(Vector3.right));
						}
					}
						

				}
			}

		}
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		
	}
}
