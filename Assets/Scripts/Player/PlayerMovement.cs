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
	public float Movespeed;	
	public SpriteRenderer spr;
	public Rigidbody2D rb2D;
	Vector2 Movement;

	[Header("DAMAGE PLAYER")]

	public HurtDetector HurtDetectorRef;

	[Header("HABILITYS PLAYER")]

	public HabilityManager ManagerHabilitys;
	public int Controlhability;

	void Start()
    {
		 
    }
    
    void Update()
    {
		if(PlayerStatesNow != PlayerStates.Isdamage)
		{

			if (Movement.y == 0)
			{
				Movement.x = Input.GetAxisRaw("Horizontal");
			}
				
			if(Movement.x == 0)
			{
				Movement.y = Input.GetAxisRaw("Vertical");
			}
			
			DetectSide();
		}
		else
		{
			Movement = Vector2.zero;
		}

		if (Input.GetButtonDown("LS"))
		{
			if(Controlhability > 0)
			{
				Controlhability--;				
			}
		}
		else if (Input.GetButtonDown("RS"))
		{
			if (Controlhability < 2)
			{
				Controlhability++;
			}
		}

		if (Input.GetButtonDown("Fire2"))
		{
			if (Controlhability > -1)
			{
				ManagerHabilitys.PowerUseControl((HabilitysPlayer.Powers)Controlhability);
			}
		}
	}

	private void FixedUpdate()
	{
		if (PlayerStatesNow != PlayerStates.Isdamage)
		{
			rb2D.MovePosition(rb2D.position + Movement * Movespeed * Time.fixedDeltaTime);
		}			
	}

	public IEnumerator MoveAgain()
	{
		
		PlayerStatesNow = PlayerStates.Isdamage;
		
		yield return new WaitForSeconds(1);
		
		PlayerStatesNow = PlayerStates.Iswating;
	}

	public IEnumerator HurtState()
	{
		if(PlayerStatesNow == PlayerStates.Isdamage)
		{
			yield return null;
		}
		else
		{
			HurtDetectorRef.Hp--;
			PlayerStatesNow = PlayerStates.Isdamage;

			yield return new WaitForSeconds(3);

			PlayerStatesNow = PlayerStates.Iswating;
		}
		
		
	}

	public void LastPositionReturn(Transform returnposition)
	{		
		transform.position = returnposition.position;		
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
		
	}	
}
