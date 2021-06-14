using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HudControl : MonoBehaviour
{
	
	public TextMeshProUGUI PT;
	public TextMeshProUGUI HB;
	public TextMeshProUGUI HBQT;
	public TextMeshProUGUI PW;
	public TextMeshProUGUI KY;

	public Image HpBar;
	public Image TmBar;

	public Image[] HbImagens;

	public HurtDetector Hurt;
	public HabilityDetector Hability;
	public PointsManager Points;
	public PlayerMovement PlayerRef;
	public string[] HabilitysText;


	private void Update()
	{
		HpBar.fillAmount = Hurt.Hp / 10;
		PT.text = Points.TotalPoint.ToString("00000000");
		TmBar.fillAmount = Hability.TimerPW / 10;
		HBQT.text = Hability.Manager.HabilitysPlayerNow[PlayerRef.Controlhability].Quant.ToString("00");
		

			
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

	public void AddKeyHas()
	{
		Debug.Log("AQUI");
		for (int i = 0; i < KeysManager.instance.KeysPlayerNow.Count; i++)
		{
			if (KeysManager.instance.KeysPlayerNow[i].Haskey)
			{
				Debug.Log("AQUI  1");
				KY.text = KeysManager.instance.KeysPlayerNow[i].KeysNow.ToString();
				break;
			}			
		}
	}
}
