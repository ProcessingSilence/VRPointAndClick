using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrangeParentPlatform : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Platform"))
            transform.parent = other.transform;
    }

    private void OnCollisionExit(Collision other)
    {
        if (other.gameObject.CompareTag("Platform"))
            transform.parent = null;
    }
}
