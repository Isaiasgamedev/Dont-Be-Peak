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

	void Start()
    {
		 
    }
    
    void Update()
    {
		if(PlayerStatesNow != PlayerStates.Isdamage)
		{
			Movement.x = Input.GetAxisRaw("Horizontal");
			Movement.y = Input.GetAxisRaw("Vertical");
			DetectSide();
		}
		else
		{
			Movement = Vector2.zero;
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
		Debug.Log("HURT");
		HurtDetectorRef.Hp--;
		PlayerStatesNow = PlayerStates.Isdamage;
		
		yield return new WaitForSeconds(5);
		
		PlayerStatesNow = PlayerStates.Iswating;
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
