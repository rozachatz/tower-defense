using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GamePause : MonoBehaviour
{
    public GameObject ui; //pause screen

    AudioSource audioSource;
    public AudioClip impact;
    public void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    public void Pause()
    {
       
        ui.SetActive(true);
        //freeze time
        Time.timeScale = 0f;
    }
    public void Play()
    {
        
        ui.SetActive(false);
        Time.timeScale = 1f;
    }



    public void Retry()
    {
        audioSource.PlayOneShot(impact, 0.4F);
        Time.timeScale = 1f;
        Health.Reset();

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void Menu()
    {
        audioSource.PlayOneShot(impact, 0.4F);
        Debug.Log("Go to menu");
        SceneManager.LoadScene("MAIN_MENU");
    }
}
