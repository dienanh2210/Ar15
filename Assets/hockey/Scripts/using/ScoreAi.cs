using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Com.MyCompany.MyGame
{
    public class ScoreAi : MonoBehaviour
    {
        
        public AudioClip goalsound;
        public GameControler GameControler;
        public GameObject puck;
        public Collider2D puckReset;
        public GameObject particel;
        public GameObject aiGoal;

        public GameObject playerrestart;
        public GameObject Ai;
        public GameObject Ai1;
        public GameObject playerBlue;
        public GameObject playerRed1;
       
        private void Start()
        {
            particel.SetActive(false);                  
        }
      
        void OnTriggerEnter2D(Collider2D collider)
        {
            if (collider.gameObject.name == "puck")
            {
                collider.gameObject.GetComponent<Rigidbody2D>().transform.position = new Vector2(0,0.5f);
                puck.SetActive(false);
                Invoke("ResetPuck", 0.75f);
                Invoke("rest", 1f);
                Invoke("issettrigger", 1.5f);
                Invoke("rest1", 1.6f);
                GameControler.Increment(GameControler.Score.AiScore);
                GetComponent<AudioSource>().PlayOneShot(goalsound);
                particel.SetActive(true);
                Invoke("Activate", 0.5f);
                aiGoal.SetActive(true);
                Invoke("ActivateAi", 0.5f);
                if (PlayerPrefsManager.Instance.Vibrate)
                {
                    Handheld.Vibrate();
                }
               
            }
          
        }
        void ActivateAi()
        {
            aiGoal.SetActive(false);
        }
        void Activate()
        {
            particel.SetActive(false);
            
        }

        public void rest() {
            Ai1.GetComponent<AiScript>().enabled = false;
            Ai1.GetComponent<Rigidbody2D>().transform.position = new Vector2(0, 3.9f);
           
        }
        public void rest1()
        {
            Ai1.GetComponent<AiScript>().enabled = true;
           

        }
        public void ResetPuck()

        {          
            puck.SetActive(true);
            puck.GetComponent<Collider2D>().isTrigger = true;
            Invoke("setTriggerr", 0.75f);
            playerrestart.GetComponent<Rigidbody2D>().transform.position = new Vector2(0, -3f);           
            Ai.GetComponent<Rigidbody2D>().transform.position = new Vector2(0, 4f);          
            playerBlue.GetComponent<Rigidbody2D>().transform.position = new Vector2(0, 4f);                    
            Ai.GetComponent<Ai>().enabled = false;           
            playerrestart.GetComponent<PlayerMove>().enabled=false;           
            playerBlue.GetComponent<PlayerMovement>().enabled = false;
            playerRed1.GetComponent<Rigidbody2D>().transform.position = new Vector2(0, -3f);
            playerRed1.GetComponent<PlayerMovement>().enabled = false;
            //  Ai1.GetComponent<AiScript>().enabled = false;
            // Ai1.GetComponent<Rigidbody2D>().transform.position = new Vector2(0, 3.9f);

        }
        public void setTriggerr()
        {
            puck.GetComponent<Collider2D>().isTrigger = false;

        }
        public void issettrigger()
        {
            playerrestart.GetComponent<PlayerMove>().enabled = true;         
            Ai.GetComponent<Ai>().enabled = true;
            playerBlue.GetComponent<PlayerMovement>().enabled = true;
            playerRed1.GetComponent<PlayerMovement>().enabled = true;

        }

    }
}
