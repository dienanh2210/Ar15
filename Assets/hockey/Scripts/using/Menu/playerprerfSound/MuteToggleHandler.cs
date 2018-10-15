using UnityEngine;
using UnityEngine.UI;
using DataService = EX1.DataService;

[RequireComponent(typeof(Toggle))]
public class MuteToggleHandler : MonoBehaviour
{
	void Start()
	{		
		Toggle toggle = GetComponent<Toggle>();
		toggle.isOn = DataService.Instance.prefs.GetIsMuted();

		
		toggle.onValueChanged.AddListener(
			(bool value) => 
			{
				DataService.Instance.prefs.SetMuted(value);
			});

	}
}
