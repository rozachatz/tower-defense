using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Bullet : MonoBehaviour
{
    private Transform target;
    public float speed ;
    public GameObject impactEffect;
    public int damage = 50;
 
    public float explosionRadius ;
    // Start is called before the first frame update
    public void Seek(Transform _target)
    {
        target = _target;
    }

    // Update is called once per frame
    void Update()
    {
        if (target == null)
        {   
            Destroy(gameObject);
            return;
        } //enemy is killed, destroy bullet
        Vector3 dir = target.position - transform.position;
        float distanceThisFrame = speed * Time.deltaTime;

        if (dir.magnitude <= distanceThisFrame) //dir.magnitude=distance to target <= distance to move this frame, we've already shoot the target
        {
            HitTarget(); 
            return;
            
        }
        transform.Translate(dir.normalized * distanceThisFrame, Space.World); //distance to object doesnt have any effect on how fast we move
        transform.LookAt(target);
    }
    void HitTarget()
    {
        GameObject effectInst = (GameObject)Instantiate(impactEffect, transform.position, transform.rotation);
        Destroy(effectInst, 0.5f);

    
           
        Damage(target);

        if (explosionRadius > 0f)
        {
            //damage several enemies
            Explode();
        }
        else
        {
            //single target
        }
        Destroy(gameObject); //destroy bullet
    }

    void Damage(Transform enemy)
    {
        Enemy e = enemy.GetComponent<Enemy>();
        if (e != null)
        {
            e.TakeDamage(damage);
        }
        else
        {
           
        }
        
        
    }
  public void Explode()
    {
        Collider[] colliders=Physics.OverlapSphere(transform.position, explosionRadius);
        //find all colliders
        Debug.Log("Explode!");
        foreach (Collider collider in colliders)
        {
            if (collider.tag=="Enemy")
            {
                Damage(collider.transform);
            }
        }
    }

}

