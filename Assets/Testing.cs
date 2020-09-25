using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class Testing : MonoBehaviour
{
    public Transform player;

    public XRRig XRRig_Script;

    private float currentYOffset;
    private float lineLength;
    private Vector3 currentReticleScale;
    
    private bool _primaryButtonAction;

    public GameObject rightControllerObj, leftControllerObj;
    private XRInteractorLineVisual _rightLine, _leftLine;
    private XRController _rightController, _leftController;
    private bool _shrinkOrGrow;

    //public bool triggerVal;
    public bool primaryVal;

    public bool shrinkOrGrow;
    
    // Start is called before the first frame update
    void Awake()
    {
        _rightLine = rightControllerObj.GetComponent<XRInteractorLineVisual>();
        _rightController = rightControllerObj.GetComponent<XRController>();
        
        _leftLine = leftControllerObj.GetComponent<XRInteractorLineVisual>();
        _leftController = leftControllerObj.GetComponent<XRController>();
        
        XRRig_Script = player.GetComponent<XRRig>();
        
        currentYOffset = XRRig_Script.cameraYOffset;
        
        lineLength = _rightLine.lineLength;
        
        currentReticleScale = _rightLine.reticle.transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        PrimaryInputDetection();


    }
    

    public void Shrink()
    {
        player.localScale = new Vector3(0.1f,0.1f,0.1f);
        XRRig_Script.cameraYOffset = currentYOffset/10;
        _rightLine.lineLength = _leftLine.lineLength = lineLength * 10;
        _rightLine.reticle.transform.localScale =
            _leftLine.reticle.transform.localScale = currentReticleScale/10;
    }

    public void Grow()
    {
        player.localScale = new Vector3(1f,1f,1f);
        XRRig_Script.cameraYOffset = currentYOffset;
        _rightLine.lineLength = _leftLine.lineLength = lineLength;
        _rightLine.reticle.transform.localScale =
            _leftLine.reticle.transform.localScale = currentReticleScale;
    }

    // Why is all of this required to press one. simple. button.
    // WHY.
    private void PrimaryInputDetection()
    {
        bool primaryInput = false;
        if ((_rightController.inputDevice.TryGetFeatureValue(CommonUsages.primaryButton, out primaryInput) 
             || _leftController.inputDevice.TryGetFeatureValue(CommonUsages.primaryButton, out primaryInput)) 
            && primaryInput && !primaryVal)
        {
            primaryVal = true;
            if (primaryVal)
                Debug.Log("Primary button is pressed.");
        }
        else if (!primaryInput && primaryVal)
        {
            primaryVal = false;
            Debug.Log("Primary button is released.");
        }
        // Switch back and forth between switching and growing every time Primary is pressed.
        shrinkOrGrow = !shrinkOrGrow;
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
