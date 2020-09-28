using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoalPedestal : MonoBehaviour
{
    private bool loadingScene;
    public string nextScene;

    // Activated via XRSocketInteractor.cs 
    public void LoadScene()
    {
        if (loadingScene == false)
        {
            loadingScene = true;
            SceneManager.LoadScene(nextScene);
        }
    }

    public IEnumerator Delay()
    {
        yield return new WaitForSecondsRealtime(0.5f);
        SceneManager.LoadScene(nextScene);
    }    
}
