using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorsBehavior : MonoBehaviour
{
	public GameObject Closed, Opend;

	public void OpendDoor()
	{
		Closed.SetActive(false);
		Opend.SetActive(true);
	}   
}
