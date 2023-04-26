using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{

    public float StartSpeed = 10f;

    [HideInInspector]
    public float Speed;
    public Text enemyText;
    public float startHealth = 100;
    private float health;
    public int worth = 50;
    public GameObject deathEffect;

    //public GameObject deathEffect;

    [Header("Unity Stuff")]
    public Image healthbar;

    private bool isDead = false;

    void Start()
    {
        Speed = StartSpeed;
        health = startHealth;
    }
     void Update()
    {
        
        enemyText.text =  health.ToString() + "/" + startHealth.ToString();

    }
    public void TakeDamage(float amount)
    {
        health -= amount;
        healthbar.fillAmount = health / startHealth;

        //Debug.Log("Health is" + health);
        if (health <= 0 && !isDead)
        {
            
            Die();
            WaveSpawner.enemies_alive--;
            Health.money += worth;
        }
    }

 

    void Die()
    {
        isDead = true;
        GameObject effect = (GameObject)Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(effect, 5f);
        Destroy(gameObject);
    }

}
