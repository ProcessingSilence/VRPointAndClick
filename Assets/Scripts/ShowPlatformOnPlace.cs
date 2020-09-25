using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class ShowPlatformOnPlace : MonoBehaviour
{
    public GameObject planeToActivate;
    private XRSocketInteractor socket;
    // Start is called before the first frame update
    void Start()
    {
        socket = GetComponent<XRSocketInteractor>();
        
        socket.onSelectEnter.AddListener(OnSocketEnter);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnSocketEnter(XRBaseInteractable socketObj)
    {
        Debug.Log("Object placed.");
    }
}
