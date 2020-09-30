﻿// Upon teleportation to a platform:
// Become a child of any object as long as they are tagged as "Platform"
// Corrects scale to always be (1,1,1) in world space, and not get scale from parent platform.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class BecomeChildToPlatform : MonoBehaviour
{
    public Transform platform;
    public Transform platformParent;

    public XRBaseInteractor rightController, leftController;

    private bool decideIfParent;

    void Awake()
    {
        rightController.onSelectExit.AddListener(GetPlatform);
        leftController.onSelectExit.AddListener(GetPlatform);
    }

    // Update is called once per frame
    void Update()
    {
        if (decideIfParent)
        {
            decideIfParent = false;
            if (platform.CompareTag("Platform"))
            {
                platformParent = platform;
                transform.parent = platformParent;
                transform.localScale = new Vector3 (1/platformParent.localScale.x,1/platformParent.localScale.y,1/platformParent.localScale.z);
            }
        }
    }

    private void ParentDecider()
    {
        
    }

    private void GetPlatform(XRBaseInteractable interactable)
    {
        platform = interactable.transform;
        decideIfParent = true;
    }
}