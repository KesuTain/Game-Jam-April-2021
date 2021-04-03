using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerEntity : MonoBehaviour
{
    [Header("Parameters")]
    public int Health;
    public float SpeedShooting;
    public float RangeAttack;
    public int Damage;
    public List<EnemyEntity> EnemiesIn;
    
    public void AddEnemy(EnemyEntity item)
    {
        EnemiesIn.Add(item);
    }

    public void RemoveEnemy(EnemyEntity item)
    {
        EnemiesIn.Remove(item);
    }
}
