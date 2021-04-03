using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SinglePatronEntity : MonoBehaviour
{
    public EnemyEntity Target;
    public float Speed;
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
        transform.LookAt(Target.transform.position + Vector3.up);
        transform.Translate(Vector3.forward * Time.deltaTime * Speed);
    }
}
