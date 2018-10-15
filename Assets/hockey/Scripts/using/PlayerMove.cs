using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour {

    bool wasJustClicked = true;
    bool canMove;
    Rigidbody2D rb;
    Vector2 startingPosition;  
    public Transform BoundaryHolder;
    Boundary playerBoundary;
    Collider2D playerCollider;
    public float scale;
    public float distanceTouch;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        startingPosition = rb.position;
        playerCollider = GetComponent<Collider2D>();
        playerBoundary = new Boundary(BoundaryHolder.GetChild(0).position.y,
                                      BoundaryHolder.GetChild(1).position.y,
                                      BoundaryHolder.GetChild(2).position.x,
                                      BoundaryHolder.GetChild(3).position.x);

    }
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Vector2 mousePos;
            mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
          //  mousePos = new Vector2(mousePos.x, mousePos.y + distanceTouch);
            if (wasJustClicked)
              {
                 wasJustClicked = false;

                  if (playerCollider.OverlapPoint(mousePos))
                  {
                      canMove = true;
                  }
                  else
                  {
                      canMove = false;
                  }
              }
              if (canMove)
              {
                Drag();

              /*  Vector2 clampedMousePos = new Vector2(Mathf.Clamp(mousePos.x, playerBoundary.Left,
                                                               playerBoundary.Right),
                                                   Mathf.Clamp(mousePos.y, playerBoundary.Down,
                                                               playerBoundary.Up));
                rb.MovePosition(clampedMousePos);*/

            }
          }
          else
          {
              wasJustClicked = true;
          } 

       
    }
    void Drag()
    {
        SetBlockPos(GetFixedMousePos(), scale);
    }
    void SetBlockPos(Vector3 pos, float newScale) 
    {
        float posX = Mathf.Clamp(pos.x, playerBoundary.Left, playerBoundary.Right) * Mathf.Min(newScale, scale) / scale;
        float posY = Mathf.Clamp(pos.y, playerBoundary.Down,playerBoundary.Up) * Mathf.Min(newScale, scale) / scale;     
      Vector2  tran= new Vector2(posX, posY);
        rb.MovePosition(tran);
    }
    Vector2 GetFixedMousePos()
    {
        Vector2 mousePos;
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos = new Vector2(mousePos.x, mousePos.y + distanceTouch);      
        return mousePos;
    }   
    public void ResetPosition()
    {
        rb.position = startingPosition;
    }
}
