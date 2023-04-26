using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class End_Destination : MonoBehaviour
{
    
    private void OnTriggerEnter(Collider other)
    {
        // Change the cube color to green.
        if (other.tag == "Enemy")
        {
          
            Health.lives--;
            WaveSpawner.enemies_alive--;
            Destroy(other.gameObject);


            return;
        }
    }
    void OnCollisionExit(Collision collisionInfo)
    {
        print("Collision Out: " + gameObject.name);
    }
}
