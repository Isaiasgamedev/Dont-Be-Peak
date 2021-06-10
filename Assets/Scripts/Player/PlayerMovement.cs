using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
	[Header("MOVEMENT PLAYER")]
	public PlayerStates PlayerStatesNow;
	public enum PlayerStates { Ismoving, Iswating, Isdamage, Isattack}
	public PlayerSide PlayerSideNow;
	public enum PlayerSide { up, down, left, right}
	PlayerSide OlderSideNow;
	public float Movespeed;
	public int tempts;
	public Transform Movepoint;
	public WallDetectSide SidesBlockeds;
	Vector3 LastPosition;
	public SpriteRenderer spr;

	// Start is called before the first frame update
	void Start()
    {
		Movepoint.parent = null;  
    }

    // Update is called once per frame
    void Update()
    {
		

		if (PlayerStatesNow == PlayerStates.Iswating)
		{
			//side is Right
			if ((Input.GetAxisRaw("Horizontal")) == 1f)
			{
				if (tempts == 0)
				{
					LastPosition = transform.position;
					Movepoint.position += new Vector3(Input.GetAxisRaw("Horizontal"), 0f, 0f);
					PlayerStatesNow = PlayerStates.Ismoving;
				}
				else if (tempts != 0 && OlderSideNow != PlayerSide.right)
				{					
					LastPosition = transform.position;
					Movepoint.position += new Vector3(Input.GetAxisRaw("Horizontal"), 0f, 0f);
					PlayerStatesNow = PlayerStates.Ismoving;
					tempts = 0;					
				}
				DetectSide();
			}

			//side is Left
			else if ((Input.GetAxisRaw("Horizontal")) == -1f)
			{
				if (tempts == 0)
				{
					LastPosition = transform.position;
					Movepoint.position += new Vector3(Input.GetAxisRaw("Horizontal"), 0f, 0f);
					PlayerStatesNow = PlayerStates.Ismoving;
				}
				else if (tempts != 0 && OlderSideNow != PlayerSide.left)
				{
					LastPosition = transform.position;
					Movepoint.position += new Vector3(Input.GetAxisRaw("Horizontal"), 0f, 0f);
					PlayerStatesNow = PlayerStates.Ismoving;
					tempts = 0;
				}
				DetectSide();
			}

			//side is Up
			else if ((Input.GetAxisRaw("Vertical")) == 1f)
			{
				if (tempts == 0)
				{
					LastPosition = transform.position;
					Movepoint.position += new Vector3(0f, Input.GetAxisRaw("Vertical"), 0f);
					PlayerStatesNow = PlayerStates.Ismoving;
				}

				else if (tempts != 0 && OlderSideNow != PlayerSide.up)
				{
					LastPosition = transform.position;
					Movepoint.position += new Vector3(0f, Input.GetAxisRaw("Vertical"), 0f);
					PlayerStatesNow = PlayerStates.Ismoving;
					tempts = 0;
				}
				DetectSide();
			}

			//side is Down
			else if ((Input.GetAxisRaw("Vertical")) == -1f)
			{
				if (tempts == 0)
				{
					LastPosition = transform.position;
					Movepoint.position += new Vector3(0f, Input.GetAxisRaw("Vertical"), 0f);
					PlayerStatesNow = PlayerStates.Ismoving;
				}

				else if (tempts != 0 && OlderSideNow != PlayerSide.down)
				{
					LastPosition = transform.position;
					Movepoint.position += new Vector3(0f, Input.GetAxisRaw("Vertical"), 0f);
					PlayerStatesNow = PlayerStates.Ismoving;
					tempts = 0;
				}
				DetectSide();
			}

		}





		if(PlayerStatesNow == PlayerStates.Ismoving)
		{
			if (Vector3.Distance(transform.position, Movepoint.position) <= 0.05f)
			{
				PlayerStatesNow = PlayerStates.Iswating;
			}
			else
			{				
				if (!SidesBlockeds.Blocked)
				{
					transform.position = Vector3.MoveTowards(transform.position, Movepoint.position, Movespeed * Time.deltaTime);
				}
				else
				{
					if (tempts == 0)
					{
						Movepoint.position = LastPosition;
						transform.position = LastPosition;
						PlayerStatesNow = PlayerStates.Iswating;
						tempts++;
					}
					
				}
			}
		}

	}

	public void DetectSide()
	{
		if (Input.GetAxisRaw("Horizontal") < 0)
		{
			
			PlayerSideNow = PlayerSide.left;
			spr.flipX = true;
		}

		else if (Input.GetAxisRaw("Horizontal") > 0)
		{
			
			PlayerSideNow = PlayerSide.right;
			spr.flipX = false;
		}
		else if (Input.GetAxisRaw("Vertical") > 0)
		{
			PlayerSideNow = PlayerSide.up;
		}

		else if(Input.GetAxisRaw("Vertical") < 0)
		{
			PlayerSideNow = PlayerSide.down;
		}

		OlderSideNow = PlayerSideNow;
	}

	
}
