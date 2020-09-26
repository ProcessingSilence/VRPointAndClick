using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

// TO DO: Rename Testing.cs to ShrinkGrow.cs
public class Testing : MonoBehaviour
{
    public Transform player;

    public XRRig XRRig_Script;

    private float lineLength;
    private Vector3 currentReticleScale;
    
    private bool _primaryButtonAction;

    public GameObject rightControllerObj, leftControllerObj;
    private XRInteractorLineVisual _rightray, _leftray;
    private XRController _rightController, _leftController;
    private LineRenderer _rightLine, _leftLine;

    private float originalLineWidth;
   
    private bool _shrinkOrGrow;
    private bool primaryVal;
    private bool primaryInput;
    private bool shrinkOrGrow = true;

    public GameObject reticlePrefab;
    
    private Vector3 bigScale = Vector3.one;
    private Vector3 tinyScale = new Vector3(0.1f, 0.1f, 0.1f);

    public Transform mainCamera;
    private Vector3 originalCameraRotation;

    public static class GlobalReticleScale
    {
        public static Vector3 globalScale;
    }

    // Start is called before the first frame update
    void Awake()
    {
        _rightray = rightControllerObj.GetComponent<XRInteractorLineVisual>();
        _rightController = rightControllerObj.GetComponent<XRController>();
        _rightLine = rightControllerObj.GetComponent<LineRenderer>();
        
        _leftray = leftControllerObj.GetComponent<XRInteractorLineVisual>();
        _leftController = leftControllerObj.GetComponent<XRController>();
        _leftLine = leftControllerObj.GetComponent<LineRenderer>();

        originalLineWidth = _rightLine.startWidth;
        
        XRRig_Script = player.GetComponent<XRRig>();

        lineLength = _rightray.lineLength;

        currentReticleScale = reticlePrefab.transform.localScale = new Vector3(1, .05f, 1);
        _rightray.reticle = _leftray.reticle = reticlePrefab;
    }

    // Update is called once per frame
    void Update()
    {
        PrimaryInputPress();
        ShrinkOrGrowSwap();
        PrimaryInputRelease();
    }
    

    private void Shrink()
    {
        player.localScale = tinyScale;
        //XRRig_Script.cameraYOffset = currentYOffset/10;
        _rightray.lineLength = _leftray.lineLength = lineLength * 10;
        _rightray.reticle.transform.localScale =
            _leftray.reticle.transform.localScale = GlobalReticleScale.globalScale = currentReticleScale/10;
        _rightLine.startWidth = _rightLine.endWidth = _leftLine.startWidth = _leftLine.endWidth = originalLineWidth/10; 
    }

    private void Grow()
    {
        player.localScale = bigScale;
        //XRRig_Script.cameraYOffset = currentYOffset;
        _rightray.lineLength = _leftray.lineLength = lineLength;
        _rightray.reticle.transform.localScale =
            _leftray.reticle.transform.localScale = GlobalReticleScale.globalScale = currentReticleScale;
        _rightLine.startWidth = _rightLine.endWidth = _leftLine.startWidth = _leftLine.endWidth = originalLineWidth;
    }

    private void PrimaryInputPress()
    {
        primaryInput = false;
        if ((_rightController.inputDevice.TryGetFeatureValue(CommonUsages.primaryButton, out primaryInput) 
             || _leftController.inputDevice.TryGetFeatureValue(CommonUsages.primaryButton, out primaryInput)) 
            && primaryInput && !primaryVal)
        {
            primaryVal = true;
            Debug.Log("Primary button is pressed.");
        }
    }

    private void PrimaryInputRelease()
    {
        if (!primaryInput && primaryVal)
        {
            primaryVal = false;
            Debug.Log("Primary button is released.");
        }
    }

    // Switch back and forth between switching and growing every time Primary is pressed.
    // Activated upon release of primary button.
    private void ShrinkOrGrowSwap()
    {
        if (!primaryInput && primaryVal)
        {
            shrinkOrGrow = !shrinkOrGrow;
            RecenterRotation();
        }
        
        if (shrinkOrGrow == false && player.localScale != tinyScale)
        {
            Shrink();
            Debug.Log("Shrunk");
        }

        if (shrinkOrGrow && player.localScale != bigScale)
        {
            Grow();
            Debug.Log("Grown");
        }
    }

    // Using InputTrackingRecenter resets the angle each time it's used. 
    // Gets camera y angle, and has XR Rig face towards that y angle upon Primary being pressed.
    private void RecenterRotation()
    {
        originalCameraRotation = mainCamera.eulerAngles;
        InputTracking.Recenter();
        player.eulerAngles = new Vector3(player.eulerAngles.x, originalCameraRotation.y, player.eulerAngles.z);
    }
    

    /*
     private void TriggerInputDetection()
     {
        bool triggerInput = false;
        if (_rightController.inputDevice.TryGetFeatureValue(CommonUsages.triggerButton, out triggerInput) && triggerInput && !triggerVal)
        {
            triggerVal = true;
            if (triggerVal)
                Debug.Log("Trigger button is pressed.");
        }
        else if (!triggerInput && triggerVal)
        {
            triggerVal = false;
            Debug.Log("Trigger button is released.");
        }    
    }
    */
}
