using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseEnemy : MonoBehaviour
{
    // Start is called before the first frame update
    public virtual void Start()
    {
        
    }

    // Update is called once per frame
    public virtual void Update()
    {
		Domove();
	}

	public virtual void Domove()
	{

	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		
	}
}
