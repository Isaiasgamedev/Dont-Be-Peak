using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HudControl : MonoBehaviour
{
	
	public TextMeshProUGUI PT;	
	public TextMeshProUGUI HBQT;
	public TextMeshProUGUI TimerFase;


	public float TimerFaseCount;
	public float TempTime;
	public bool StartCount;
	public bool TimerNow;

	public Image HpBar;
	public Image TmBar;

	public Image[] HbImagens;
	public Image[] KeysImagens;


	public HurtDetector Hurt;
	public HabilityDetector Hability;
	public PointsManager Points;
	public PlayerMovement PlayerRef;

	public static HudControl instance;

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

	private void Start()
	{
		StartCount = true;
	}

	private void Update()
	{
		if (DialogueManager.instance.DialogueStatesNow == DialogueManager.DialogueStates.Indialogue) return;
		if (StartCount)
		{
			TimerFaseCount += Time.deltaTime;					
		}

		float minutes = Mathf.FloorToInt(TimerFaseCount / 60);
		float seconds = Mathf.FloorToInt(TimerFaseCount % 60);
		TimerFase.text = string.Format("{0:00}:{1:00}", minutes, seconds);


		HpBar.fillAmount = Hurt.Hp / 10;
		PT.text = Points.TotalPoint.ToString("00000000");		

		TmBar.fillAmount = Hability.TimerPW / TempTime;
		if(PlayerRef.Controlhability > -1)
		{
			HBQT.text = Hability.Manager.HabilitysPlayerNow[PlayerRef.Controlhability].Quant.ToString("0");
		}
			
	}

	public void SetImageHability()
	{
		if(PlayerRef.Controlhability >= 0)
		{
			for (int i = 0; i < HbImagens.Length; i++)
			{
				if (HbImagens[i].gameObject.activeSelf == true)
				{
					HbImagens[i].gameObject.SetActive(false);
				}
			}

			HbImagens[PlayerRef.Controlhability].gameObject.SetActive(true);
		}		
	}

	
}
