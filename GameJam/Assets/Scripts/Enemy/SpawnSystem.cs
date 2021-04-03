using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnSystem : MonoBehaviour
{
    public GameObject Enemy;
    void Start()
    {
        StartCoroutine(SpawnEnemy());
    }

    IEnumerator SpawnEnemy()
    {
        yield return new WaitForSeconds(2f);
        Instantiate(Enemy);
        StartCoroutine(SpawnEnemy());
    }

    void Update()
    {
        
    }
}
