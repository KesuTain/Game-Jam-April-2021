using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnSystem : MonoBehaviour
{
    public static SpawnSystem instance;
    public EnemyEntity[] Enemy;
    public float TimeBetweenWaves;
    public float TimeBetweenEnemy;
    public bool Buildability;

	public Text BuildabilityLabel;

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
    private void Awake()
    {
        instance = this;
    }
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
            Buildability = true;
			BuildabilityLabel.text = "Время строить!";
			BuildabilityLabel.color = Color.green;
            yield return new WaitForSeconds(TimeBetweenWaves);
            Buildability = false;
			BuildabilityLabel.text = "Не время строить!";
			BuildabilityLabel.color = Color.red;
			foreach (EnemyEntity enemy in wave.Queue)
            {
                Instantiate(enemy);
                yield return new WaitForSeconds(TimeBetweenEnemy);
            }
        }
        Stats.instance.Win();
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
