using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialoguesNow : MonoBehaviour
{
	public string[] Sentences;
	public DialogueManager Manager;

	private void Start()
	{
		Manager = DialogueManager.instance;
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if(collision.tag == "Player")
		{
			Manager.DialogueStatesNow = DialogueManager.DialogueStates.Indialogue;
			Manager.StarDialogueVoid(Sentences);
			this.gameObject.SetActive(false);
		}
	}
}
