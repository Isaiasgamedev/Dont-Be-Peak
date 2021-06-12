using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HabilityDetector : MonoBehaviour
{
	public GameObject HurtDesactive, InvencibleDesactive;
	public enum Powers { Invencible, Inactive}
	public Powers PowersNow;    

	public void ActiveIvencible()
	{
		StartCoroutine(TimerPower(20));
	}	

	IEnumerator TimerPower(float Timer)
	{
		PowersNow = Powers.Invencible;
		HurtDesactive.SetActive(false);
		InvencibleDesactive.SetActive(true);
		yield return new WaitForSeconds(Timer);
		HurtDesactive.SetActive(true);
		InvencibleDesactive.SetActive(false);
		PowersNow = Powers.Inactive;
	}

}
