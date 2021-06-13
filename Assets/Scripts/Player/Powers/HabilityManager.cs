using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]

public class HabilitysPlayer
{
	public int Quant;
	public float Duration;
	public enum Powers { Invencible, Invisible, Freezing, Inactive }
	public Powers PowersNow;
}

public class HabilityManager : MonoBehaviour
{
	public List<HabilitysPlayer> HabilitysPlayerNow = new List<HabilitysPlayer>();
	public HabilityDetector Detector;
	public static HabilityManager instance;

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

	public void PowerUseControl(HabilitysPlayer.Powers poweruse)
	{
		if(HabilitysPlayerNow[(int) poweruse].Quant > 0)
		{
			HabilitysPlayerNow[(int)poweruse].Quant--;
			Detector.useHability(poweruse);
		}
	}

	public void AddPower(HabilitysPlayer.Powers poweruse)
	{
		HabilitysPlayerNow[(int)poweruse].Quant++;

	}
}