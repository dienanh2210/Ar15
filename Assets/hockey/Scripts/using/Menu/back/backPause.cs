using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Com.MyCompany.MyGame
{
    public class backPause : MonoBehaviour
    {

        public GameObject pause;
        public GameObject setpause;
        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetKey("escape"))
            {


                Invoke("setback", 0.1f);


            }

        }
        public void setback()
        {
            pause.SetActive(false);
            setpause.SetActive(true);


        }

    }
}
