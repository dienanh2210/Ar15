using UnityEngine;


public class PlayerPrefsHandler
{
	
	#region PlayerPrefs keys
	public const string MUTE_INT = "mute";
	public const string VOLUME_F = "volume";
	#endregion

	private const bool DEBUG_ON = true;

	
	public void RestorePreferences()
	{
		SetMuted(GetIsMuted());
		SetVolume(GetVolume());
	}

	public void SetMuted(bool muted)
	{
		
		PlayerPrefs.SetInt(MUTE_INT, muted ? 1 : 0);

		
		AudioListener.pause = muted;

		if (DEBUG_ON)
			Debug.LogFormat("SetMuted({0})", muted);
	}


	public bool GetIsMuted()
	{
		
		return PlayerPrefs.GetInt(MUTE_INT, 0) == 1;
	}


	public void SetVolume(float volume)
	{
		
		volume = Mathf.Clamp(volume, 0, 1);

		PlayerPrefs.SetFloat(VOLUME_F, volume);
		AudioListener.volume = volume;
	}

	public float GetVolume()
	{
		return Mathf.Clamp(PlayerPrefs.GetFloat(VOLUME_F, 1), 0, 1);
	}
}
