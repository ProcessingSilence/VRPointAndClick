// Moves platform from beginning and end whenever atPosition == false; interruption cannot happen.
// This script starts from BeginMovement() getting called.
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMove : MonoBehaviour
{
    // false: go to beginning, true: go to end
    public bool goToBeginningOrEnd = true;
    public bool atPosition = true;

    public float speed;
    private Vector3 beginning, end;

    public Vector3 endOffset;

    public float fraction;

    public bool testMovement;

    void Awake()
    {
        beginning = transform.position;
        end = transform.position + endOffset;
    }

    // Update is called once per frame
    void Update()
    {
        if (testMovement)
        {
            testMovement = false;
            BeginMovement();
        }

        if (atPosition == false)
        {
            Movement();
        }
    }

    // Starts platform movement.
    // Only allow movement AFTER platform is at destination.
    public void BeginMovement()
    {
        if (atPosition)
        {
            fraction = 0;
            atPosition = false;
        }
    }
 
    private void Movement()
    {
        if (goToBeginningOrEnd && atPosition == false)
        {
            Debug.Log("Moving from beginning to end");
            fraction += Time.deltaTime * speed;
            if (fraction > 1)
            {
                fraction = 1;
            }
            transform.position = Vector3.Lerp(beginning, end, fraction);
            if (transform.position == end)
            {
                atPosition = true;
                goToBeginningOrEnd = false;
                transform.position = end;
            }   
        }
        else if (goToBeginningOrEnd == false && atPosition == false)
        {
            Debug.Log("Moving from end to beginning");
            fraction += Time.deltaTime * speed;
            if (fraction > 1)
            {
                fraction = 1;
            }
            transform.position = Vector3.Lerp(end, beginning, fraction);
            if (transform.position == beginning)
            {
                atPosition = true;
                goToBeginningOrEnd = true;
                transform.position = beginning;
            }
        }
    }
}
