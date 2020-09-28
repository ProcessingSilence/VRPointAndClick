using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.SceneManagement;

public class GoalPedestal : MonoBehaviour
{
    public XRSocketInteractor XrSocketInteractor_script;

    private bool loadingScene;

    public string nextScene;

    // Activated via XRSocketInteractor.cs 
    public void LoadScene()
    {
        if (loadingScene == false)
        {
            loadingScene = true;
            StartCoroutine(Delay());
        }
    }

    private IEnumerator Delay()
    {
        loadingScene = true;
        XrSocketInteractor_script.enabled = false;
        yield return new WaitForSecondsRealtime(0.5f);
        SceneManager.LoadScene(nextScene);
    }    
}
