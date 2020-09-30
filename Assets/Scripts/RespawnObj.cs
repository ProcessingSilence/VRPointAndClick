using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnObj : MonoBehaviour
{
    private Vector3 respawnPos;

    private Rigidbody _rb; 
    // Start is called before the first frame update
    void Awake()
    {
        respawnPos = transform.position;
        _rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < -15)
        {
            transform.position = respawnPos;
            _rb.velocity = Vector3.zero;
        }
    }
}
