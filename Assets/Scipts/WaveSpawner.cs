using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class WaveSpawner : MonoBehaviour
{
    public static int EnemyAlives;
    public float timeBettwenWave = 10f;
    private float timeCount = 5f;

    public Transform Spawnpoint;
    private int waveIndex = 0;
    public Text waveTimeBettwen;
    public Wave[] waves;

    public Gamemanager gamemanager;
    void Start()
    {
        EnemyAlives = 0;
    }
    private void Update()
    {
        if(EnemyAlives > 0)
        {
            return;
        }
        if (waveIndex == waves.Length && PlayerStart.Lives > 0)
        {
            gamemanager.Winlevel();
            this.enabled = false;
        }
        if (timeCount <= 0f)
        {
            StartCoroutine(SpawnWave());    
            timeCount = timeBettwenWave;
            return;
        }
        
        timeCount -= Time.deltaTime;
        timeCount = Mathf.Clamp(timeCount, 0f, Mathf.Infinity);
        waveTimeBettwen.text = string.Format("{0:00.00}", timeCount);
    }
    IEnumerator SpawnWave()
    {
        PlayerStart.Rounds++;
        Wave wave = waves[waveIndex];

        EnemyAlives = wave.count;

        for (int i = 0; i < wave.count; i++)
        {
            SpawnEnemy(wave.enemy);
            yield return new WaitForSeconds(01f / wave.rate );
        }
        
        waveIndex++;
        
    }
    void SpawnEnemy(GameObject enemy)
    {
        // instantiate enemy
        Instantiate(enemy, Spawnpoint.position, Spawnpoint.rotation);
    }
}
