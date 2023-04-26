using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Win : MonoBehaviour
{
    AudioSource audioSource;
    public AudioClip impact;
    public void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void Menu()
    {
        audioSource.PlayOneShot(impact, 0.4F);
        Debug.Log("Go to menu");
        Health.Reset();
        SceneManager.LoadScene("MAIN_MENU");
    }
}
