using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Com.MyCompany.MyGame
{
    public class AiScript : MonoBehaviour
    {

        public float MaxMovementSpeed;
        private Rigidbody2D rb;
        private Vector2 startingPosition;
        public Rigidbody2D Puck;
        private Vector2 targetPosition;
        private bool isFirstTimeInOpponentsHalf = true;
        private float offsetXFromTarget;
       
        private void Start()
        {
            rb = GetComponent<Rigidbody2D>();
            startingPosition = rb.position;
            
        }
        private void FixedUpdate()
        {
           
            float movementSpeed;

            if (Puck.position.y < 0.6f)
            {
                if (isFirstTimeInOpponentsHalf)
                {
                    isFirstTimeInOpponentsHalf = false;
                    offsetXFromTarget = Random.Range(-1f, 1.1f);
                }

                movementSpeed = MaxMovementSpeed * Random.Range(0.1f, 0.3f);
                targetPosition = new Vector2(Mathf.Clamp(Puck.position.x + offsetXFromTarget, -1.8f,
                                                       1.8f),
                                            startingPosition.y);
            }
            else
            {
                isFirstTimeInOpponentsHalf = true;

                movementSpeed = Random.Range(MaxMovementSpeed * 0.4f, MaxMovementSpeed);
                targetPosition = new Vector2(Mathf.Clamp(Puck.position.x, -1.8f,
                                            1.8f),
                                            Mathf.Clamp(Puck.position.y, 0.4f,
                                            4.2f));
            }
            rb.MovePosition(Vector2.MoveTowards(rb.position, targetPosition,
                    movementSpeed * Time.fixedDeltaTime));
        }
        public void ResetPosition()
        {
            rb.position = startingPosition;
        }
    }
}
