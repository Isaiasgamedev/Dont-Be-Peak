using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseEnemy : MonoBehaviour
{
	public enum EnemyState { Inwait, inMove, Indamage, InDead}
	public EnemyState EnemyStateNow;
	public Animator anim;
	public AudioSource Audio;

	// Start is called before the first frame update
	public virtual void Start()
    {
        
    }

    // Update is called once per frame
    public virtual void Update()
    {
		if (DialogueManager.instance.DialogueStatesNow == DialogueManager.DialogueStates.Indialogue) return;

		if(EnemyStateNow != EnemyState.InDead)
		{
			Domove();
		}
		
	}

	public virtual void Domove()
	{

	}

	public virtual void DoDead()
	{
		EnemyStateNow = EnemyState.InDead;
		Audio.Play();
		anim.Play("Dead");
	}

	public void SetDesactive()
	{
		this.gameObject.SetActive(false);
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		
	}
}
