// Upon teleportation to a platform:
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
    private Transform _platformParent;

    public XRBaseInteractor rightController, leftController;

    private bool decideIfParent;
    private AudioSource _audioSource;

    void Awake()
    {
        rightController.onSelectExit.AddListener(GetPlatform);
        leftController.onSelectExit.AddListener(GetPlatform);
        _audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (decideIfParent)
        {
            decideIfParent = false;
            if (platform.CompareTag("Platform"))
            {
                _platformParent = platform;
                transform.parent = _platformParent;
                transform.localScale = new Vector3 (1/_platformParent.localScale.x,1/_platformParent.localScale.y,1/_platformParent.localScale.z);
                _audioSource.Play();
            }
        }
    }

    private void GetPlatform(XRBaseInteractable interactable)
    {
        platform = interactable.transform;
        decideIfParent = true;
    }
}
