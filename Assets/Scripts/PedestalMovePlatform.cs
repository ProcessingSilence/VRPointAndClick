// When activated, move platform in one direction. Move in opposite direction upon being activated again.
// Movement can be interrupted upon activation (can switch directions even in the middle of moving).
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PedestalMovePlatform : MonoBehaviour
{
    // false: go to beginning, true: go to end
    private bool _goToBeginningOrEnd;
    public bool movementSwitch = true;

    public float speed;
    private Vector3 beginning, end;

    public Vector3 endOffset;

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
            movementSwitch = true;
            BeginMovement();
        }
            Movement();
    }

    // Starts platform movement.
    // Only allow movement AFTER platform is at destination.
    public void BeginMovement()
    {
        if (movementSwitch)
        {
            _goToBeginningOrEnd = !_goToBeginningOrEnd;
            movementSwitch = false;
        }
    }
 
    private void Movement()
    {
        if (_goToBeginningOrEnd && movementSwitch == false)
        {
            Debug.Log("Moving from beginning to end");
            transform.position = Vector3.MoveTowards(transform.position, end, Time.deltaTime*speed);
            if (transform.position == end)
            {
                movementSwitch = true;
                transform.position = end;
            }   
        }
        else if (_goToBeginningOrEnd == false && movementSwitch == false)
        {
            Debug.Log("Moving from end to beginning");
            transform.position = Vector3.MoveTowards(transform.position, beginning, Time.deltaTime*speed);
            if (transform.position == beginning)
            {
                movementSwitch = true;
                transform.position = beginning;
            }
        }
    }
}
