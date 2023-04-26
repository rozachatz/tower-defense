using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenuScript : MonoBehaviour
{
    AudioSource audioSource;
    public AudioClip impact;
    public string loadlevel = "MainScene";
    public void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    public void Play()
    {
        

        audioSource.PlayOneShot(impact, 1.0F);
        Health.Reset();
        if (Time.timeScale == 0f) Time.timeScale = 1f;
        SceneManager.LoadScene(loadlevel);
    }

    public void Quit()
    {

        audioSource.PlayOneShot(impact, 1.0F);
        Debug.Log("Exiting Game...");
        Application.Quit();
    }

    public void Options()
    {
        audioSource.PlayOneShot(impact, 1.0F);
    }
}
