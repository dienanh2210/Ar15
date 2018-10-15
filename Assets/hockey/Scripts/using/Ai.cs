using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Com.MyCompany.MyGame
{
    public class Ai : MonoBehaviour
    {
        public float MaxMovementSpeed=5;
        private Rigidbody2D rb;
        private Vector2 startingPosition;
        public Rigidbody2D Puck;
        private Vector2 targetPosition;
        private bool isFirstTimeInOpponentsHalf = true;
        private float offsetXFromTarget;
        public bool ischeckol;
        public Transform PuckBoundaryHolder;
        private Boundary puckBoundary;
        private void Start()
        {
            rb = GetComponent<Rigidbody2D>();
            startingPosition = rb.position;
            puckBoundary = new Boundary(PuckBoundaryHolder.GetChild(0).position.y,
                                  PuckBoundaryHolder.GetChild(1).position.y,
                                  PuckBoundaryHolder.GetChild(2).position.x,
                                  PuckBoundaryHolder.GetChild(3).position.x);

        }
        private void FixedUpdate()
        {
            switch (GameValues.Difficulty)
            {
                case GameValues.Difficulties.Easy:
                    MaxMovementSpeed = 10;
                    break;
                case GameValues.Difficulties.Medium:
                    MaxMovementSpeed = 20;
                    break;
                case GameValues.Difficulties.Hard:
                    MaxMovementSpeed = 30;
                    break;
            }
            float movementSpeed;

            if (Puck.position.y < puckBoundary.Down)
            {
                if (isFirstTimeInOpponentsHalf)
                {
                    isFirstTimeInOpponentsHalf = false;
                    offsetXFromTarget = Random.Range(-1f, 1f);
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
                                            Mathf.Clamp(Puck.position.y, 0.3f,
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

