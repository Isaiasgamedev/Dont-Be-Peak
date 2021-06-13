using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HudControl : MonoBehaviour
{
	public TextMeshProUGUI HP;
	public TextMeshProUGUI PT;
	public TextMeshProUGUI HB;
	public TextMeshProUGUI HBQT;
	public TextMeshProUGUI PW;

	public HurtDetector Hurt;
	public HabilityDetector Hability;
	public PointsManager Points;
	public PlayerMovement PlayerRef;
	public string[] HabilitysText;


	private void Update()
	{
		HP.text = Hurt.Hp.ToString("00");
		PT.text = Points.TotalPoint.ToString("00000");
		PW.text = Hability.TimerPW.ToString("00");
		HBQT.text = Hability.Manager.HabilitysPlayerNow[PlayerRef.Controlhability].Quant.ToString("00");
		HB.text = HabilitysText[PlayerRef.Controlhability].ToString();
	}
}
