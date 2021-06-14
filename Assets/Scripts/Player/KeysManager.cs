using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]

public class KeysPlayer
{
	public bool Haskey;	
	public enum Keys { Yellow, Blue, Red, Green }
	public Keys KeysNow;
}

public class KeysManager : MonoBehaviour
{
	public List<KeysPlayer> KeysPlayerNow = new List<KeysPlayer>();
	
	public static KeysManager instance;

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

	public void AddKeyNow(KeysPlayer.Keys Key)
	{
		KeysPlayerNow[(int)Key].Haskey = true;

		for (int i = 0; i < KeysManager.instance.KeysPlayerNow.Count; i++)
		{
			if (KeysManager.instance.KeysPlayerNow[i].Haskey)
			{
				HudControl.instance.KeysImagens[i].gameObject.SetActive(true);
			}
		}
	}
}
