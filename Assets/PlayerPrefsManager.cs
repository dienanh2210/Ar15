using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPrefsManager : MonoBehaviour {

    public static PlayerPrefsManager Instance;

    public List<VibrateToggle> VibrateToggles;
    private void Awake()
    {
        Instance = this;
        _vibrate = PlayerPrefsX.GetBool("Vibrate");
        OnVibrateChanged();
        VibrateToggles.ForEach(x =>
        {
            x._button.onClick.AddListener(() =>
            {
                Vibrate = !Vibrate;
            });
        });
    }

    public bool _vibrate;
    public bool Vibrate
    {
        get
        {
            return _vibrate;
        }
        set
        {
            PlayerPrefsX.SetBool("Vibrate",value);
            _vibrate = value;
            OnVibrateChanged();
        }
    }

    public void OnVibrateChanged()
    {
        VibrateToggles.ForEach(x =>
        {
            x.OnChange(_vibrate);
        });
    }
}
