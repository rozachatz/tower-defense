using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower_rotating : MonoBehaviour

{

    //***used for canon tower***
    private Transform target;

    [Header("Attributes")] //vary from one tur to another
    public float range = 15f;
    public float fireRate = 1f;
    private float fireCountdown = 0f;

    [Header("Unity Setup Fields")]
    // Start is called before the first frame update
    public string enemyTag = "Enemy";

    public Transform PartToRotate;
    public float turnspeed = 10f;
    public GameObject mybulletPrefab; //ref to bullet
    public Transform firepoint; //which to spawn a bullet
    public Color color = Color.white;

    void Start()
    {
        color.a = 0.3f;
        //search for target at the beginning and check every 0.5 secs
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
    }

    void UpdateTarget()
    {
      
        Collider[] colliders = Physics.OverlapSphere(transform.position, range);
      
        float shortestDistance = Mathf.Infinity; 
        GameObject nearestEnemy = null;
        foreach (Collider collider in colliders)
        {

            if (collider.tag == "Enemy")
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
                { //make sure that we lose connection to enemy when he's not in range
                    target = null;
                }
            }
            else
            {
                //oops
            }
        }

    }

    // Update is called once per frame
    void Update()
    {
        //not every frame, two times per sec
        if (target == null) return; //do nothing, no target

        //rotation

        Vector3 dir = target.position - transform.position;

        Quaternion lookRotation = Quaternion.LookRotation(dir); //how to turn in order to shoot enemy

        //rotate the body around the y axis, smooth movements
        Vector3 rotation = Quaternion.Lerp(PartToRotate.rotation, lookRotation, Time.deltaTime * turnspeed).eulerAngles;

        PartToRotate.rotation = Quaternion.Euler(0f, rotation.y, 0f);

        if (fireCountdown <= 0f)
        {
            Shoot();
            fireCountdown = 1f/fireRate;
        }
        fireCountdown -= Time.deltaTime;
    }

    private void OnDrawGizmos()
    {

        Gizmos.color = color;

        Gizmos.DrawSphere(transform.position, range);
    }
    void Shoot()
    {
        //the bullet
        GameObject bulletGo = (GameObject)Instantiate(mybulletPrefab, firepoint.position, firepoint.rotation);

        //store bullet script
        Bullet bullet = bulletGo.GetComponent<Bullet>();
        if (bullet != null) bullet.Seek(target); 
    }
}
