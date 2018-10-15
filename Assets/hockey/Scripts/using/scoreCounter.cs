using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace Com.MyCompany.MyGame
{
    public class scoreCounter : MonoBehaviour
    {
       
        public AudioClip goalsound;
        public GameControler GameControler;
        public GameObject puck;
        private GameObject ball;
        public GameObject particel;
        public GameObject playerGoal;    
        public bool isVeb=true;
        public GameObject playerrestart;
        public GameObject Ai;
        public GameObject Ai1;
        public GameObject playerBlue;
        public GameObject playerRed1;
       
        private void Start()
        {
           
            particel.SetActive(false);
            ball = GameObject.FindWithTag("Ball");          
        }
      
        void OnTriggerEnter2D(Collider2D collider)
        {
            if (collider.gameObject.name == "puck")
            {
                 collider.gameObject.GetComponent<Rigidbody2D>().transform.position= new Vector2(0, 0.5f);
                
                puck.SetActive(false);
                Invoke("ResetPuckplayer", 0.75f);
                Invoke("rest", 1f);
                Invoke("issettriggerr", 1.5f);
                Invoke("rest1", 1.6f);
                GameControler.Increment(GameControler.Score.PlayerScore);
                GetComponent<AudioSource>().PlayOneShot(goalsound);
                particel.SetActive(true);
                Invoke("Activate", 0.5f);
                playerGoal.SetActive(true);
                Invoke("ActivateAi", 0.5f);
                if (PlayerPrefsManager.Instance.Vibrate)
                {
                    Handheld.Vibrate();
                }

            }
         
    }
        void ActivateAi()
        {
            playerGoal.SetActive(false);
        }
        void Activate()
        {
            particel.SetActive(false);
           

        }

        public void rest()
        {
            Ai1.GetComponent<AiScript>().enabled = false;
            Ai1.GetComponent<Rigidbody2D>().transform.position = new Vector2(0, 3.9f);
           
        }
        public void rest1()
        {
            Ai1.GetComponent<AiScript>().enabled = true;
          
        }
        
        public void ResetPuckplayer()

        {
            puck.SetActive(true);
            puck.GetComponent<Collider2D>().isTrigger = true;
            Invoke("setTriggerr", 0.75f);

            playerrestart.GetComponent<Rigidbody2D>().transform.position = new Vector2(0, -3f);          
            Ai.GetComponent<Rigidbody2D>().transform.position = new Vector2(0, 4f);
            
            playerBlue.GetComponent<Rigidbody2D>().transform.position = new Vector2(0, 4f);        
            playerrestart.GetComponent<PlayerMove>().enabled = false;
            //playerrestart.GetComponent<PlayerMovement>().enabled = false;   
            
            Ai.GetComponent<Ai>().enabled = false;

            playerRed1.GetComponent<Rigidbody2D>().transform.position = new Vector2(0, -3f);
            playerBlue.GetComponent<PlayerMovement>().enabled = false;
            playerRed1.GetComponent<PlayerMovement>().enabled = false;
           
           
        }
        public void setTriggerr()
        {
            puck.GetComponent<Collider2D>().isTrigger = false;

        }
        public void issettriggerr()
        {
            playerrestart.GetComponent<PlayerMove>().enabled = true;
            // playerrestart.GetComponent<PlayerMovement>().enabled = true; 

            Ai.GetComponent<Ai>().enabled = true;
            playerBlue.GetComponent<PlayerMovement>().enabled = true;      
             playerRed1.GetComponent<PlayerMovement>().enabled = true;

          

        }
    }
}
