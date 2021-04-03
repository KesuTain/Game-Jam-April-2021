using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(TowerEntity))]
public class AoETowerEntity : TowerEntity
{
    bool canShot;
    public GameObject Patron;
    public GameObject Gun;
    void Start()
    {
        canShot = true;
        GetComponent<SphereCollider>().radius = RangeAttack;
    }

    
    void Update()
    {
        if (canShot)
            StartCoroutine(Shoots());
    }

    IEnumerator Shoots()
    {
        canShot = false;
        foreach (EnemyEntity enemy in EnemiesIn)
        {
            enemy.GetComponent<EnemyEntity>().GetDamage(Damage);
            var clone = Instantiate(Patron, Gun.transform.position, Quaternion.identity);
            clone.GetComponent<AoEPatronEntity>().Target = enemy;
            Debug.DrawRay(transform.position, enemy.transform.position);
        }
        yield return new WaitForSeconds(SpeedShooting);
        canShot = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            AddEnemy(other.gameObject.GetComponent<EnemyEntity>());
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Enemy")
        {
            if (other.GetComponent<EnemyEntity>().Alive == false)
            {
                RemoveEnemy(other.gameObject.GetComponent<EnemyEntity>());
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Enemy")
        {
            RemoveEnemy(other.gameObject.GetComponent<EnemyEntity>());
        }
    }
}
