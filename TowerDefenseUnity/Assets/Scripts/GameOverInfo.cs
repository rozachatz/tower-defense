using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverInfo : MonoBehaviour
{
    AudioSource audioSource;
    public AudioClip impact;
    public  Text roundsText;
    // Start is called before the first frame update
    void OnEnable()
    {
       
        audioSource = GetComponent<AudioSource>();
        Time.timeScale = 0f;
        roundsText.text = WaveSpawner.waveIndex.ToString();
       
    }

    public void Retry()
    {
        audioSource.PlayOneShot(impact, 0.4F);
        Health.Reset();
        Time.timeScale = 1f;

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Menu()
    {
        audioSource.PlayOneShot(impact, 0.4F);
        Time.timeScale = 1f;
        SceneManager.LoadScene("MAIN_MENU");
    }
}
