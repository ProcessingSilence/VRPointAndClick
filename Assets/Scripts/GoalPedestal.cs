using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GoalPedestal : MonoBehaviour
{
    private bool loadingScene;
    public string nextScene;

    public Image fadeImage;

    private GameObject goalObj;

    public ParticleSystem _particleSystem;

    private AudioSource _audioSource;

    public AudioClip splat, win;

    private float negOrPosFade;

    public GameObject audioPlayer;
    private AudioSource audioPlayerAS;


    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
        goalObj = GameObject.FindWithTag("Goal");
    }

    // Activated via XRSocketInteractor.cs 
    public void LoadScene()
    {
        if (loadingScene == false)
        {
            loadingScene = true;
            StartCoroutine(Delay());
            //SceneManager.LoadScene(nextScene);
        }
    }

    public IEnumerator Delay()
    {
        Destroy(goalObj);
        _audioSource.clip = splat;
        audioPlayerAS = Instantiate(audioPlayer, transform.position, Quaternion.identity).GetComponent<AudioSource>();
        audioPlayerAS.clip = win;
        _audioSource.Play();
        audioPlayerAS.Play();
        _particleSystem.Play();
        yield return new WaitForSecondsRealtime(1f);
        while (fadeImage.color.a < 1)
        {
            fadeImage.color += new Color(0,0,0,0.1f * 1);
            yield return new WaitForSeconds(0.01f);
        }

        SceneManager.LoadScene(nextScene);
    }    
}
