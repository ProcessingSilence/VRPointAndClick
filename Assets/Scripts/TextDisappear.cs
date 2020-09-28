// Gets text meshes and fades them all out.
// Should be used on parent of textmeshes, as the parent gets destroyed when the last textmesh is faded out.
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class TextDisappear: MonoBehaviour
{
    public XRController rightController, leftController;

    private bool _triggerVal;

    private int _textDisappear;

    public TextMesh[] texts;

    public float fadeTime;

    // Update is called once per frame
    void Update()
    {
        _triggerInputDetection();
        ActivateFade();
    }
    
    private void _triggerInputDetection()
    {
        bool _triggerInput = false;
        if ((rightController.inputDevice.TryGetFeatureValue(CommonUsages.triggerButton, out _triggerInput) || 
             leftController.inputDevice.TryGetFeatureValue(CommonUsages.triggerButton, out _triggerInput)) 
            && _triggerInput && !_triggerVal)
        {
            _triggerVal = true;
            Debug.Log("Trigger button is pressed.");
        }
        else if (!_triggerInput && _triggerVal)
        {
            _triggerVal = false;
            Debug.Log("Trigger button is released.");
        }    
    }

    private void ActivateFade()
    {
        // Get trigger down.
        if (_triggerVal && _textDisappear < 1)
        {
            _textDisappear = 1;
            Debug.Log("got triggerdown");
        }

        // Get trigger up, start fading text.
        if (_triggerVal == false && _textDisappear == 1)
        {
            _textDisappear= 2;
            Debug.Log("got triggerup, beginning TextFade()");
        }
        
        if (_textDisappear == 2)
        {
            TextFade();
        }
    }

    // Fade out text, destroy parent upon last text being fully faded out.
    private void TextFade()
    {
        for (int i = 0; i < texts.Length; i++)
        {
            //Color fadedColor = texts[i].color;
            //fadedColor.a = 0;
            
            texts[i].color -= new Color(0,0,0,0.1f);
        }
    }
}
