using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DataService = EX1.DataService;

[RequireComponent(typeof(Toggle))]
public class MuteToggleHandlerSound : MonoBehaviour {

    void Start()
    {
        Toggle toggle = GetComponent<Toggle>();
        toggle.isOn = DataService.Instance.prefs.GetIsMuted();


        toggle.onValueChanged.AddListener(
            (bool value) =>
            {
              //  DataService.Instance.prefs.SetMuted(value);

            });

    }
}
