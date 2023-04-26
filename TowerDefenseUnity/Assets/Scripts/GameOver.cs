using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    AudioSource audioSource;
    AudioSource playtheme;
    public AudioClip playtheme_clip;
    public AudioClip impact1;
    public static bool gameover;
    public GameObject gameOverUI;
    // Update is called once per frame
    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        playtheme = GetComponent<AudioSource>();
        playtheme.loop = true;
        audioSource.clip = playtheme_clip;
        audioSource.volume = 0.4f;
        audioSource.Play();
        gameover = false; //everytime we load a new scene
    }
    void Update()
    {   if (gameover) {  return; }
                
                
        if (  (Health.lives <= 0) || Input.GetKeyDown("q")) 
        {
            playtheme.Stop();
            gameover =true;

            audioSource.PlayOneShot(impact1, 0.7F);
            gameOverUI.SetActive(true);
            Debug.Log("GAME OVER");
        }

    }
}
