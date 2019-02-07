using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class WolfController : MonoBehaviour
{
    public Vector3 Destination = new Vector3(-1f, -1f, -1f);
    private Rigidbody rb;
    public float Speed;
    public float Distance;
//    private Collider anyCollider = null;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();

    }

    private void OnTriggerEnter(Collider other)
    {
//        if (!other.Equals(anyCollider))
//        {
            Destination = new Vector3(-1f, -1f, -1f);
//        }
//        anyCollider = other;
    }

    private void FixedUpdate()
    {
        if (Destination != new Vector3(-1f,-1f,-1f))
        {
            Vector3 direction = (Destination - rb.position).normalized;
            rb.gameObject.transform.LookAt(Destination + rb.velocity);
            rb.MovePosition(rb.position + direction * Speed * Time.fixedDeltaTime);
            if (rb.position == Destination)
            {
                Destination = new Vector3(-1f, -1f, -1f);
            }
        }
    }

    void Move(Vector2 direction)
    {
        float moveHorizontal = direction.x;
        float moveVertical = direction.y;

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        Vector3 newPosition = rb.position + movement;

        rb.transform.LookAt(newPosition + rb.velocity);
        rb.MovePosition(newPosition);
    }

    //inside class
    Vector2 firstPressPos;
    Vector2 secondPressPos;
    Vector2 currentSwipe;
/*
    void FixedUpdate()
    {
        if (Input.touches.Length > 0)
        {
            Touch t = Input.GetTouch(0);
            if (t.phase == TouchPhase.Began)
            {
                //save began touch 2d point
                firstPressPos = new Vector2(t.position.x, t.position.y);
            }
            if (t.phase == TouchPhase.Ended)
            {
                //save ended touch 2d point
                secondPressPos = new Vector2(t.position.x, t.position.y);

                //create vector from the two points
                currentSwipe = new Vector3(secondPressPos.x - firstPressPos.x, secondPressPos.y - firstPressPos.y);

                //normalize the 2d vector
                currentSwipe.Normalize();

                Move(currentSwipe);
                
                                //swipe upwards
                                if (currentSwipe.y > 0  currentSwipe.x > -0.5f  currentSwipe.x < 0.5f)
                             {
                                    Debug.Log("up swipe");
                                }
                                //swipe down
                                if (currentSwipe.y < 0  currentSwipe.x > -0.5f  currentSwipe.x < 0.5f)
                             {
                                    Debug.Log("down swipe");
                                }
                                //swipe left
                                if (currentSwipe.x < 0  currentSwipe.y > -0.5f  currentSwipe.y < 0.5f)
                             {
                                    Debug.Log("left swipe");
                                }
                                //swipe right
                                if (currentSwipe.x > 0  currentSwipe.y > -0.5f  currentSwipe.y < 0.5f)
                             {
                                    Debug.Log("right swipe");
                                }
                            }
                 
            }
        }
    }*/
}
