using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FourWayMovement : MonoBehaviour
{
    //public int leftMin, leftMax, rightMin, rightMax, upMin, upMax, downMin, downMax;

    //public int currentLeft, currentRight, currentUp, currentDown;

    public Vector3 currentBeginning, currentEnd;
    
    // 0: Off, 1: Left, 2: Right, 3: Up, 4: Down
    public int currentMovementDirection;

    public bool atPosition = true;

    public float fraction;

    public float movementIteration;

    public float speed;

    public bool test;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (test)
        {
            test = false;
            atPosition = true;
            currentMovementDirection = 4;
        }

        if (currentMovementDirection == 4)
        {
            DownMovement();
        }
    }
    
    private void DownMovement()
    {
        if (atPosition)
        {
            atPosition = false;

            fraction = 0;

            currentEnd = transform.position + new Vector3(0, 0, -movementIteration);
            currentBeginning = transform.position;
        }

        if (atPosition == false)
        {
            Debug.Log("Moving from beginning to end");
            fraction += Time.deltaTime * speed;
            if (fraction > 1)
            {
                fraction = 1;
            }
            transform.position = Vector3.Lerp(currentBeginning, currentEnd, fraction);
            if (transform.position == currentEnd)
            {
                currentMovementDirection = 0;
                atPosition = true;
                transform.position = currentEnd;
            }   
        }
    }

    private void VerticalMovement()
    {
        
    }
}
