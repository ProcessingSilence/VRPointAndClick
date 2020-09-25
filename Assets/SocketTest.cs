using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class SocketTest : MonoBehaviour
{
    private XRSocketInteractor socketObj;
    // Start is called before the first frame update
    void Start()
    {
        socketObj = GetComponent<XRSocketInteractor>();
        socketObj.onSelectEnter.AddListener(OnSocketEnter);
        socketObj.onSelectEnter.AddListener(OnSocketExit);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnSocketEnter(XRBaseInteractable socketObject)
    {
        
    }
    
    void OnSocketExit(XRBaseInteractable socketObject)
    {
        
    }
}
