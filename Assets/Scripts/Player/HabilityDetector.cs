using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HabilityDetector : MonoBehaviour
{
	public HabilityManager Manager;
	public PlayerMovement PlayerRef;
	public GameObject HurtDesactive;
	public GameObject[] ActivePower;
	public float TimerPW;
	public bool Activated;
	public AudioSource Audio;

	private void Update()
	{
		if (Activated)
		{
			if(TimerPW > 0)
			{
				TimerPW -= Time.deltaTime;
			}
			else
			{
				TimerPW = 0;
			}
		}
		else
		{
			TimerPW = 0;
		}
	}

	public void useHability(HabilitysPlayer.Powers  PowersUse)
	{
		TimerPW = Manager.HabilitysPlayerNow[(int)PowersUse].Duration;
		HudControl.instance.TempTime = Manager.HabilitysPlayerNow[(int)PowersUse].Duration;
		StartCoroutine(UseNowPower(HurtDesactive, ActivePower[(int)PowersUse]));
	}


	IEnumerator UseNowPower(GameObject Hurt, GameObject PowerActivated)
	{
		Activated = true;
		Hurt.SetActive(false);
		PowerActivated.SetActive(true);
		PlayerRef.PlayerStatesNow = PlayerMovement.PlayerStates.Isattack;
		Audio.Play();

		yield return new WaitForSeconds(TimerPW);
	
		Hurt.SetActive(true);
		PowerActivated.SetActive(false);
		Activated = false;
		PlayerRef.PlayerStatesNow = PlayerMovement.PlayerStates.Iswating;
		Audio.Stop();
	}
}
