using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueManager : MonoBehaviour
{
	public TextMeshProUGUI DialogueText;
	public string[] Sentences;
	private int index = 0;
	public float DialogueSpeed;
	public Animator anim;
	public bool StartDialogue = true;

	

	public enum DialogueStates { Indialogue, Inwaiting}
	public DialogueStates DialogueStatesNow;

	public AudioSource Audio;

	public static DialogueManager instance;

	private void Awake()
	{
		if (instance != null && instance != this)
		{
			Destroy(gameObject);
		}
		else
		{
			instance = this;
		}
	}

	void Update()
    {
		if(DialogueStatesNow == DialogueStates.Indialogue)
		{
			if (Input.GetButtonDown("Fire1"))
			{
				if (StartDialogue)
				{
					NextSentece();
				}				
			}
		}
		
    }

	public void StarDialogueVoid(string[] Sentencenow)
	{
		Sentences = Sentencenow;
		anim.Play("Entry");
		StartDialogue = true;
	}

	void NextSentece()
	{
		Audio.Play();
		if (index <= Sentences.Length - 1)
		{
			DialogueText.text = "";
			StartCoroutine(WriteSentece());
		}
		else
		{
			DialogueText.text = "";
			anim.Play("Exit");
			index = 0;
			DialogueStatesNow = DialogueStates.Inwaiting;
		}
	}

	IEnumerator WriteSentece()
	{
		StartDialogue = false;
		foreach (char chararecter in Sentences[index].ToCharArray())
		{
			DialogueText.text += chararecter;
			yield return new WaitForSeconds(DialogueSpeed);
		}
		index++;
		StartDialogue = true;
	}
}
