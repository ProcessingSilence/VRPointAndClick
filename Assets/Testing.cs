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

    public bool triggerInput;

    
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
        bool triggerButtonVal = false;
        if (_rightController.inputDevice.TryGetFeatureValue(CommonUsages.triggerButton, out triggerButtonVal) && triggerButtonVal && !triggerInput)
        {
            triggerInput = true;
            if (triggerInput)
                Debug.Log("Trigger button is pressed.");
        }
        else if (!triggerButtonVal && triggerInput)
        {
            triggerInput = false;
            Debug.Log("Trigger button is released.");
        }
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
}
