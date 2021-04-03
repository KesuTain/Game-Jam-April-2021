using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SinglePatronEntity : MonoBehaviour
{
    public EnemyEntity Target;
    public float Speed;
    public int Damage;
    
    void Start()
    {
        StartCoroutine(TimeLife());
    }

    IEnumerator TimeLife()
    {
        yield return new WaitForSeconds(2.5f);
        Destroy(this.gameObject);
    }

    void Update()
    {
        MoveToEnemy();
    }

    void MoveToEnemy()
    {
        if (Target.GetComponent<EnemyEntity>().Health > 0)
        {
            transform.LookAt(Target.transform.position + Vector3.up);
            transform.Translate(Vector3.forward * Time.deltaTime * Speed);
        } else
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            other.GetComponent<EnemyEntity>().GetDamage(Damage);
            Destroy(gameObject);
        }
    }
}
