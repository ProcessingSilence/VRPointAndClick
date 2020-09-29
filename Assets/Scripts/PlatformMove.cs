// Moves platform from beginning and end whenever "startMove" is set to true.
// This script gets called from MoverPedestal.cs whenever an object enters its socket.
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMove : MonoBehaviour
{
    // false: go to beginning, true: go to end
    public bool goToBeginningOrEnd;
    public bool atPosition = true;

    public float speed;
    private Vector3 beginning, end;

    public Vector3 endOffset;

    void Awake()
    {
        beginning = transform.position;
        end = transform.position + endOffset;
    }

    // Update is called once per frame
    void Update()
    {
        if (atPosition == false)
        {
            BeginningToEnd();
            EndToBeginning();
        }
    }

    // Starts platform movement.
    // Only allow movement AFTER platform is at destination.
    public void BeginMovement()
    {
        if (atPosition)
        {
            atPosition = false;
        }
    }

    
    
    private void EndToBeginning()
    {
        if (goToBeginningOrEnd == false && transform.position != beginning)
        {
            transform.position = Vector3.MoveTowards(end, beginning, speed * Time.deltaTime);
        }
        else if (goToBeginningOrEnd == false && transform.position == beginning)
        {
            atPosition = true;
            goToBeginningOrEnd = true;
        }
    }

    private void BeginningToEnd()
    {
        if (goToBeginningOrEnd && transform.position != end)
        {
            transform.position = Vector3.MoveTowards(beginning, end, speed * Time.deltaTime);
        }
        else if (goToBeginningOrEnd && transform.position == end)
        {
            atPosition = true;
            goToBeginningOrEnd = false;
        }   
    }
}
