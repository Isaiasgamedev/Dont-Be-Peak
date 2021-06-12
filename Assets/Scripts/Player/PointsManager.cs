using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointsManager : MonoBehaviour
{
	public int TotalPoint;

    public void GetPoints(int Points)
	{
		TotalPoint += Points;
	}
}
