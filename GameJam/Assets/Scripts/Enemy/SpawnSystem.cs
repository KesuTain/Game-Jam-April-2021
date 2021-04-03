using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnSystem : MonoBehaviour
{
    public EnemyEntity[] Enemy;
    public float TimeBetweenWaves;
    public float TimeBetweenEnemy;
    [System.Serializable]
    public class Wave
    {
        public int CountEnemies;
        public int ResoursesType;
        public int WarriorType;
        public List<EnemyEntity> Queue;
    }
    public List<Wave> Waves;
    public int WaveNow;
    void Start()
    {
        WaveNow = 0;
        QueueQueue();
        SpawnWave();
    }

    void SpawnWave()
    {
        StartCoroutine(SpawnEnemy());
    }

    IEnumerator SpawnEnemy()
    {
        foreach (Wave wave in Waves)
        {
            yield return new WaitForSeconds(TimeBetweenWaves);
            foreach (EnemyEntity enemy in wave.Queue)
            {
                Instantiate(enemy);
                yield return new WaitForSeconds(TimeBetweenEnemy);
            }
        }
        
    }

    void QueueQueue()
    {
        int i = -1;
        foreach(Wave wave in Waves)
        {
            i++;
            
            for(int j = 1; j <= wave.CountEnemies; j++)
            {
                if(j % wave.WarriorType == 0)
                {
                    wave.Queue.Add(Enemy[2]);
                } else if (j % wave.ResoursesType == 0)
                {
                    wave.Queue.Add(Enemy[1]);
                } else
                {
                    wave.Queue.Add(Enemy[0]);
                }
            }
        }
    }

    void Update()
    {
        
    }
}
