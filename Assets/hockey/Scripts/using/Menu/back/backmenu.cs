using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Com.MyCompany.MyGame
{
    public class backmenu : MonoBehaviour
    {
        public MenuManager menumanager;
        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            if (Application.platform == RuntimePlatform.Android)
            {
                if (Input.GetKeyDown(KeyCode.Escape))
                    //  Application.Quit();
                    menumanager.Back();

            }


        }
        void setback() {
           
        }
    }
}
