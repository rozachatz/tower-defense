using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Shop : MonoBehaviour
{

    BuildManager buildManager;
    public static int standard_price = 150;
 
    public Towers tower;
    public Towers explosive_tower;
    public Towers flame_arrow_tower;
    
    AudioSource audioSource;
    public AudioClip impact;


    private void Start()
    {

        audioSource = GetComponent<AudioSource>();
        //ref to build manager
        buildManager = BuildManager.instance;

    }
    public void playaudio()
    {
        audioSource.PlayOneShot(impact, 0.7F);

    }

  

    public void PurchaseTower()
    {
        Debug.Log("Tower Selected");

        playaudio();
        buildManager.Select_tower_to_build(tower);
        
        
    }

    public void PurchaseFlameTower()
    {
        Debug.Log("Magic Tower Selected");

        playaudio();
        buildManager.Select_tower_to_build(flame_arrow_tower);


    }
    public void PurchaseExplosiveTower()
    {
        Debug.Log("Explosive Tower Selected");

        playaudio();
        
        buildManager.Select_tower_to_build(explosive_tower);
    }
}

   

