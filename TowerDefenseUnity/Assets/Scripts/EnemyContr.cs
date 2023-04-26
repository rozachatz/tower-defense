using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyContr : MonoBehaviour
{
    public Transform end;
 
    public NavMeshAgent agent;
    // Update is called once per frame
    void Update()
    {
        
        agent.SetDestination(end.position);
        
    }

    }

