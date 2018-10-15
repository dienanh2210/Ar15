using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
namespace Com.MyCompany.MyGame
{
    public class ActivarModelos : MonoBehaviour
    {
        public Image horizontal;
        public float timepo = 5f;
        public float ContadorTiempo;
        public Text Horizontal;
        // Use this for initialization
        void Start()
        {
            ContadorTiempo = 0;

        }

        // Update is called once per frame
        void Update()
        {
            if (ContadorTiempo <= timepo)
            {
                ContadorTiempo = ContadorTiempo + Time.deltaTime;
                horizontal.fillAmount = ContadorTiempo / timepo;
                Horizontal.text = (System.Convert.ToInt32(100 * horizontal.fillAmount)).ToString() + "%";

            }


        }

    }


    
       


}
