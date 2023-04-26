using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    
    public static int lives= 30;
    public static int money= 2500;




    public static void Reset()
    {
        money = 2500;
        lives = 30;
        WaveSpawner.waveIndex = 0;
        WaveSpawner.enemies_alive = 0;

        

    }

    


}
