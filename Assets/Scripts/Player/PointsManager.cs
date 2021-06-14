using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointsManager : MonoBehaviour
{
	public int TotalPoint;

	public static PointsManager instance;

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

	public void GetPoints(int Points)
	{
		TotalPoint += Points;
	}

	public void LessPoints(int Points)
	{

		if(TotalPoint - Points >= 0)
		{
			TotalPoint -= Points;
		}
		else
		{
			TotalPoint = 0;
		}

		HudControl.instance.TimerFaseCount += 5;


	}
}
