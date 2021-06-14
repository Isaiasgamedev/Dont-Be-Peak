using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadomEnemy : BaseEnemy
{
	public EnemyStates EnemyStatesNow;
	public enum EnemyStates { Ismoving, Iswating, Isdamage, Isattack }
	public EnemySide EnemySideNow;
	public enum EnemySide { up, down, left, right }
	
	public float Movespeed;
	public int Tempts;
	public int ControlMoves;
	public int Moves;
	public Transform Movepoint;
	
	Vector3 LastPosition;
	public SpriteRenderer spr;
	public int Choice;
	public LayerMask StopMoment;

	public override void Start()
	{
		Movepoint.parent = null;
		ControlMoves = Moves;
		RadomMoveInt();
	}

	public override void Domove()
	{
		if (DialogueManager.instance.DialogueStatesNow == DialogueManager.DialogueStates.Indialogue) return;
		if (ControlMoves != 0)
		{
			if (EnemyStatesNow == EnemyStates.Iswating)
			{
				//side is Right
				if (EnemySideNow == EnemySide.up)
				{
					if(!Physics2D.OverlapCircle(Movepoint.position + new Vector3(0f, 1f, 0f), 0.2f, StopMoment))
					{
						LastPosition = transform.position;
						Movepoint.position += new Vector3(0f, 1f, 0f);
						ControlMoves--;
						EnemyStatesNow = EnemyStates.Ismoving;
					}
					else
					{
						if (Tempts == 0)
						{
							EnemySideNow = EnemySide.down;
							Tempts++;
						}
						else
						{

							RadomMoveInt();
						}
						
					}

				}

				//side is Left
				else if (EnemySideNow == EnemySide.down)
				{
					if (!Physics2D.OverlapCircle(Movepoint.position + new Vector3(0f, -1f, 0f), 0.2f, StopMoment))
					{
						LastPosition = transform.position;
						Movepoint.position += new Vector3(0f, -1f, 0f);
						ControlMoves--;
						EnemyStatesNow = EnemyStates.Ismoving;
					}
					else
					{
						if (Tempts == 0)
						{
							EnemySideNow = EnemySide.up;
							Tempts++;
						}
						else
						{
							RadomMoveInt();
						}
						
					}


				}

				//side is Up
				else if (EnemySideNow == EnemySide.right)
				{
					if (!Physics2D.OverlapCircle(Movepoint.position + new Vector3(1f, 0f, 0f), 0.2f, StopMoment))
					{
						LastPosition = transform.position;
						Movepoint.position += new Vector3(1f, 0f, 0f);
						ControlMoves--;
						EnemyStatesNow = EnemyStates.Ismoving;

					}
					else
					{
						if(Tempts == 0)
						{
							Tempts++;
							EnemySideNow = EnemySide.left;
						}
						else
						{
							RadomMoveInt();
						}


					}


				}

				//side is Down
				else if (EnemySideNow == EnemySide.left)
				{
					if (!Physics2D.OverlapCircle(Movepoint.position + new Vector3(-1f, 0f, 0f), 0.2f, StopMoment))
					{
						LastPosition = transform.position;
						Movepoint.position += new Vector3(-1f, 0f, 0f);
						ControlMoves--;
						EnemyStatesNow = EnemyStates.Ismoving;
					}
					else
					{
						if (Tempts == 0)
						{
							Tempts++;
							EnemySideNow = EnemySide.right;
						}
						else
						{
							RadomMoveInt();
						}
						
					}

					

				}

			}
		}
		else
		{
			RadomMoveInt();
		}








		if (EnemyStatesNow == EnemyStates.Ismoving)
		{
			if (Vector3.Distance(transform.position, Movepoint.position) <= 0.05f)
			{
				ControlMoves--;
				EnemyStatesNow = EnemyStates.Iswating;
			}
			else
			{				
				transform.position = Vector3.MoveTowards(transform.position, Movepoint.position, Movespeed * Time.deltaTime);				
			}
		}

	}

	

	public void RadomMoveInt()
	{
		float OldChoice = Choice;
		Choice = Random.Range(0, 4);
		
		if(OldChoice != Choice)
		{
			if (Choice == 0)
			{
				EnemySideNow = EnemySide.up;
			}

			else if (Choice == 1)
			{
				EnemySideNow = EnemySide.down;
			}

			else if (Choice == 2)
			{
				EnemySideNow = EnemySide.right;
				spr.flipX = false;
			}

			else if (Choice == 3)
			{
				EnemySideNow = EnemySide.left;
				spr.flipX = true;
			}

			ControlMoves = Moves;
			EnemyStatesNow = EnemyStates.Iswating;
		}

		else
		{
			RadomMoveInt();
		}

		
	}
}
