using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AoEPatronEntity : MonoBehaviour
{
    public EnemyEntity Target;
    public float Speed;

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
        if(other.tag == "Enemy")
        {
            Destroy(gameObject);
        }
    }
}
