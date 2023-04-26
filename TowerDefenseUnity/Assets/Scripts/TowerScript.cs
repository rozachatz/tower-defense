using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerScript : MonoBehaviour
{
    private Transform target;
    public Color color = Color.white;

    [Header("Attributes")] //vary from one tur to another
    public float range = 15f;
    public float fireRate = 1f;
    private float fireCountdown = 0f;

    [Header("Unity Setup Fields")]
    // Start is called before the first frame update
    public string enemyTag = "Enemy";

    public GameObject bulletPrefab; //ref to bullet

    private Quaternion lookRotation; //dir for bullet
    private Vector3 dir;
    void Start()
    {
        color.a = 0.2f;
        //search for target at the beginning and check every 0.5 secs
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
    }
    void UpdateTarget()
    {

        Collider[] colliders = Physics.OverlapSphere(transform.position, range); //find colliders within range

        //initialazations
        float shortestDistance = Mathf.Infinity; 
        GameObject nearestEnemy = null;

        foreach (Collider collider in colliders)
        {
            //find the closest enemy
            if (collider.tag == "Enemy") //only enemy colliders!
            {
                Enemy enemy = collider.transform.GetComponent<Enemy>();

                float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
                if (distanceToEnemy < shortestDistance)
                {
                    //check for nearest enemy
                    shortestDistance = distanceToEnemy;
                    nearestEnemy = enemy.gameObject;
                }

                if (nearestEnemy != null && shortestDistance <= range)
                {
                    //the target is the nearest enemy
                    target = nearestEnemy.transform;
                }
                else
                { 
                    //make sure that we loose connection to enemy when he's not in range
                    target = null;
                }
            }
        else
        {
                //oops, that's not an enemy
            }
        }

    }

    // Update is called once per frame
    void Update()
    {
        //not every frame, two times per sec
        if (target == null) return; //do nothing, no target

        //rotation

        dir = target.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(dir); //where the bullet will aim

       
        if (fireCountdown <= 0f)
        {
            Shoot();
            fireCountdown =1f/fireRate;
        }
        fireCountdown -= Time.deltaTime;
    }
    private void OnDrawGizmos() //this appears only in edit mode
    {
        
        Gizmos.color = color;
        Gizmos.DrawSphere(transform.position, range);
       
    }
    void Shoot()
    {
        //Instantiate the bullet
        GameObject bulletGo = (GameObject)Instantiate(bulletPrefab, transform.position, lookRotation);

        //get the bullet script
        Bullet bullet = bulletGo.GetComponent<Bullet>();
       
        //seek target!
        if (bullet != null) bullet.Seek(target); 
                                                 
    }
}

