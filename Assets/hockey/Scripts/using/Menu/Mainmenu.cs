using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Mainmenu : MonoBehaviour {

    // Use this for initialization
    void Start() {
        Screen.orientation = ScreenOrientation.Portrait;
    }

    // Update is called once per frame
    void Update() {
        Invoke("nextMenu",3f);
    }
    void nextMenu()
    {
        SceneManager.LoadScene("Menu");

    }
}
