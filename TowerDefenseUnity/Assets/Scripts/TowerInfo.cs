using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerInfo : MonoBehaviour //show info for each tower
{
    public GameObject ui; 

    AudioSource audioSource;
    public AudioClip impact;

    public void Info()
    {
        playaudio();
        ui.SetActive(true);
        
    }
    public void Hide()
    {
        playaudio();
        ui.SetActive(false);
      
    }


    public void playaudio()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.PlayOneShot(impact, 0.4F);

    }

  
}
