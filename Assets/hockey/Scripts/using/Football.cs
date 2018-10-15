using UnityEngine;
using UnityEngine.UI;
using System.Collections;
namespace Com.MyCompany.MyGame
{
    public class Football : MonoBehaviour
    {
   
        public AudioClip playerhitsound;
        public AudioClip wallhitsound;      
        private Rigidbody2D rb2d;       
        public static bool WasGoal { get; private set; }
        float maxX = 1.8f;
        float minX = -1.8f;
        float maxY = 4.5f;
        float minY = -3.3f;
        private Animator anim;
        Collider2D puckCollider;

        void Awake()
        {
            AudioListener.volume = PlayerPrefs.GetFloat("CurVol");
        }
        void Start()
        {          
            anim = gameObject.GetComponent<Animator>();
            puckCollider = GetComponent<Collider2D>();
            WasGoal = false;
            rb2d = GetComponent<Rigidbody2D>();
        }
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (!WasGoal)
            {
                if (other.tag == "AiGoal")
                {
                    //   StartCoroutine(ResetPuck(false));
                    WasGoal = true;
                }
                else if (other.tag == "PlayerGoal")
                {
                    //  StartCoroutine(ResetPuck(true));
                    WasGoal = true;
                }
            }
            if (other.tag == "Finish")
            {
              //  gameObject.GetComponent<Rigidbody2D>().transform.position = other.transform.position;
              //  Debug.Log("finish");
            }
            }
      
     
        void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.name == "PlayerRed")
            {
                //collision.gameObject.GetComponent<Rigidbody2D>().AddForceAtPosition(Beat2.lastVelocity * 20000, collision.contacts[0].point);
                GetComponent<AudioSource>().PlayOneShot(playerhitsound);
            }
            if (collision.gameObject.name == "Ai")
            {
                // collision.gameObject.GetComponent<Rigidbody2D>().AddForceAtPosition(Beat3.lastVelocity * 20000, collision.contacts[0].point);
                GetComponent<AudioSource>().PlayOneShot(playerhitsound);
            }
            if (collision.gameObject.name == "AiBlueplayer")
            {
                GetComponent<AudioSource>().PlayOneShot(playerhitsound);
            }
            if (collision.gameObject.name == "AiBlue")
            {
                GetComponent<AudioSource>().PlayOneShot(playerhitsound);
            }



        }

        public void CenterPuck()
        {
            gameObject.GetComponent<Rigidbody2D>().transform.position = new Vector2(0, 0);
        }
        public float maxSpeed;
        public float bounceSpeed;
        private float xVelocity;
        private float yVelocity;
        private void Update()
        {
            rb2d.velocity = Vector2.ClampMagnitude(rb2d.velocity, maxSpeed);
           
            anim.SetBool("isScale", true);
            rb2d.transform.Rotate(0,0,5);
            /* if (Mathf.Abs(rb2d.position.x) > maxSpeed)
             {
                 if (rb2d.position.x < 0)
                     xVelocity = -maxSpeed;
                 else
                     xVelocity = maxSpeed;
             }
             else
                 xVelocity = Mathf.Clamp(rb2d.position.x, minX, maxX);


             if (Mathf.Abs(rb2d.position.y) > maxSpeed)
             {
                 if (rb2d.position.y < 0)
                     yVelocity = -maxSpeed;
                 else
                     yVelocity = maxSpeed;
             }
             else
                 yVelocity = Mathf.Clamp(rb2d.position.y, minY, maxY);

             rb2d.position = new Vector2(xVelocity, yVelocity);
             // rb2d.position = new Vector3(Mathf.Clamp(rb2d.position.x, minX, maxX), Mathf.Clamp(rb2d.position.y, minY, maxY), 0);
             if (Mathf.Abs(rb2d.velocity.x) > maxSpeed)
             {
                 if (rb2d.velocity.x < 0)
                     xVelocity = -maxSpeed;
                 else
                     xVelocity = maxSpeed;
             }
             else
                 xVelocity = rb2d.velocity.x;


             if (Mathf.Abs(rb2d.velocity.y) > maxSpeed)
             {
                 if (rb2d.velocity.y < 0)
                     yVelocity = -maxSpeed;
                 else
                     yVelocity = maxSpeed;
             }
             else
                 yVelocity = rb2d.velocity.y;

             rb2d.velocity = new Vector2(xVelocity, yVelocity);*/
        }
        public void setTrigger()
        {
            puckCollider.isTrigger = false;
        }       
        

       
       

    }    
}

