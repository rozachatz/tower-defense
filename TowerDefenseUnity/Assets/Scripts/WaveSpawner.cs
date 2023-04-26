using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;


public class WaveSpawner : MonoBehaviour
{
    // Start is called before the first frame update

    public Transform enemyPrefab; //normal
    public Transform enemyPrefab_small;//small
    public Transform enemyPrefab_big;//medium

    public Transform enemyPrefabf; //normal
    public Transform enemyPrefab_smallf;//small
    public Transform enemyPrefab_bigf;//medium

    public Transform spawnPoint;
    public Transform spawnPoint1;

    
    public static int waveIndex = 0;

    //time between waves
    public float TimeBetweenWaves = 10f;
    private float countdown = 2f;
  
    private float enemy_type = 0;
    public Text waves_left;

    public static int goal = 18;
    public static int goal1 = goal/3;
    public static int goal2 = 2*goal1;
    public static int enemies_alive = 0;
    //timer
    public Text waveCountdownText;
    void Update()
    {
        if (waveIndex == goal)
        {
            if(enemies_alive==0) SceneManager.LoadScene("Win_Scene");
            else { countdown = 0f; waveCountdownText.text = string.Format("{0:00.00}", countdown) + "secs"; waveCountdownText.color = Color.white; return; }
        }
     
        if (countdown <= 1.5f) waveCountdownText.color = Color.red;
        else waveCountdownText.color = Color.white;

        if (countdown <= 0.0f)
        {
            //new wave!
            StartCoroutine(SpawnWave()); 
           
            //reset timer for next wave
            countdown = TimeBetweenWaves;
         
        }
       
        //amount of time passed since last frame, reduce
        countdown -= Time.deltaTime;
        //cut off all the decimal places
        waveCountdownText.text = string.Format("{0:00.00}",countdown)+"secs";
        waves_left.text = waveIndex.ToString()+"/"+goal.ToString()+"WAVES";
    }
    IEnumerator SpawnWave()
    {
        waveIndex++;
        for (int i = 0; i < 2; i++)
            {


                if (waveIndex<=goal1)
                {
                    if (waveIndex <= goal1 + (goal1 - goal1) / 2)
                    {
                    SpawnEnemy_easy(spawnPoint);

                    SpawnEnemy_easy(spawnPoint1);
                    }
                    else
                    {
                    SpawnEnemy_easyf(spawnPoint);

                    SpawnEnemy_easyf(spawnPoint1);
                    }

                    enemies_alive = enemies_alive + 2;
                   

                //wait for 0.5 sec for the other enemy
                //so he is not on top of the others
                yield return new WaitForSeconds(0.5f);
                }
                else if (waveIndex <= goal2 )
            {

                if (waveIndex <= goal1+ (goal2 - goal1) / 2)
                {
                    SpawnEnemy_medium(spawnPoint);

                    SpawnEnemy_medium(spawnPoint1);
                }
                else
                {
                    SpawnEnemy_mediumf(spawnPoint);

                    SpawnEnemy_mediumf(spawnPoint1);
                }

        
                    enemies_alive = enemies_alive + 2;

                //wait for 0.5 sec for the other enemy
                //so he is not on top of the others
                yield return new WaitForSeconds(0.5f);
                }
                else
                {

                    if (waveIndex <=  goal2+ (goal-goal2)/2)
                    {
                    Debug.Log("Time to spawn big enemies!");
                        SpawnEnemy_hard(spawnPoint);

                        SpawnEnemy_hard(spawnPoint1);
                    }
                    else
                    {
                        SpawnEnemy_hardf(spawnPoint);

                        SpawnEnemy_hardf(spawnPoint1);
                    }

                    enemies_alive = enemies_alive + 2;

                //wait for 0.5 sec for the other enemy
                //so he is not on top of the others
                yield return new WaitForSeconds(0.5f);
                }
                





            }
        
    }
    void SpawnEnemy_easy(Transform spawnp)
    {
        //enemy at spawn location
        Instantiate(enemyPrefab_small, spawnp.position, spawnPoint.rotation);
        
    }
    void SpawnEnemy_medium(Transform spawnp)
    {
        //enemy at spawn location
        Instantiate(enemyPrefab, spawnp.position, spawnPoint.rotation);

    }
    void SpawnEnemy_hard(Transform spawnp)
    {
        //enemy at spawn location
        Instantiate(enemyPrefab_big, spawnp.position, spawnPoint.rotation);

    }

    void SpawnEnemy_easyf(Transform spawnp)
    {
        //enemy at spawn location
        Instantiate(enemyPrefab_smallf, spawnp.position, spawnPoint.rotation);

    }
    void SpawnEnemy_mediumf(Transform spawnp)
    {
        //enemy at spawn location
        Instantiate(enemyPrefabf, spawnp.position, spawnPoint.rotation);

    }
    void SpawnEnemy_hardf(Transform spawnp)
    {
        //enemy at spawn location
        Instantiate(enemyPrefab_bigf, spawnp.position, spawnPoint.rotation);

    }
}
