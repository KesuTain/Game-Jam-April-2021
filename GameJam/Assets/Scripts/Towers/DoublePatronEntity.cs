using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoublePatronEntity : MonoBehaviour
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
        yield return new WaitForSeconds(1f);
        Destroy(this.gameObject);
    }

    void Update()
    {
        MoveToEnemy();
    }

    void MoveToEnemy()
    {
        Debug.Log(Target);
        if (Target.GetComponent<EnemyEntity>().Health > 0)
        {
            transform.LookAt(Target.transform.position + Vector3.up);
            transform.Translate(Vector3.forward * Time.deltaTime * Speed);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            Debug.Log("A");
            other.GetComponent<EnemyEntity>().DoublePick();
            Destroy(gameObject);
        }
    }
}
