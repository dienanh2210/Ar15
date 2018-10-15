using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


[RequireComponent(typeof(Button))]
public class VibrateToggle : MonoBehaviour {



    public Button _button;

    public GameObject IsOff;
    private void Start()
    {
       
    }

    public void OnChange(bool value)
    {
        IsOff.SetActive(!value);
    }
}
