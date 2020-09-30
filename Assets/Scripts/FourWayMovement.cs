using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FourWayMovement : MonoBehaviour
{
    //public int leftMin, leftMax, rightMin, rightMax, upMin, upMax, downMin, downMax;

    //public int currentLeft, currentRight, currentUp, currentDown;

    public Vector3 currentBeginning, currentEnd;

    public Vector3 vectorAdd;
    public bool atPosition = true;

    public float fraction;

    public float movementIteration;

    public int direction;
    
    public float speed;
    private bool currentlyMoving;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Movement();    
    }

    public void MyVector(Vector3 myVector3)
    {
        
    }

    public void SetX(float myFloat)
    {
        if (atPosition)
        {
            vectorAdd = new Vector3(myFloat, vectorAdd.y, vectorAdd.z);
        }
    }

    public void SetY(float myFloat)
    {
        if (atPosition)
        {
            vectorAdd = new Vector3(vectorAdd.x, myFloat, vectorAdd.z);
        }
    }

    public void SetZ(float myFloat)
    {
        if (atPosition)
        {
            vectorAdd = new Vector3(vectorAdd.x, vectorAdd.y, myFloat);
        }
    }

    public void BeginMovement()
    {
        if (atPosition)
        {
            fraction = 0;

            currentEnd = transform.position + vectorAdd;
            currentBeginning = transform.position;
            
            atPosition = false;
        }
    }
    
    // Movement position determined by given vectorAdd.
    private void Movement()
    {
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
                currentlyMoving = false;
                atPosition = true;
                transform.position = currentEnd;
            }   
        }
    }

    private void VerticalMovement()
    {
        
    }
}
