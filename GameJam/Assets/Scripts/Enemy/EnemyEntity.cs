using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MoveComponent))]
public class EnemyEntity : MonoBehaviour
{
    public MoveComponent Move;
    public TitleEntity PointToMove;
    [Header("Parameters")]
    public int Health;
    public float SpeedMoving;
    public float SpeedRotation;
    public int MoneyGet;
    public bool Alive;
    void Start()
    {
        Alive = true;
        Move = GetComponent<MoveComponent>();
        FindNextTitle();
    }

    

    void FindNextTitle()
    {
        PointToMove = Move.FindNextPosition();
    }

    void Update()
    {
        MoveToTitle();
    }

    void MoveToTitle()
    {
        if (Vector3.Distance(transform.position, PointToMove.transform.position) <= 0.1f)
        {
            FindNextTitle();
        }

        Vector3 direction = PointToMove.transform.position - transform.position;
        Quaternion rotation = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Lerp(transform.rotation, rotation, SpeedRotation * Time.deltaTime);
        transform.Translate(Vector3.forward * SpeedMoving * Time.deltaTime);
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.name == "EndPoint")
        {
            Destroy(gameObject);
        }
    }


    public void GetDamage(int damage)
    {
        Health -= damage;
        CheckHealth();
    }

    void CheckHealth()
    {
        if(Health <= 0)
        {
            Stats.instance.GetMoney(MoneyGet);
            Alive = false;
            SpeedMoving = 0;
            StartCoroutine(Death());
        }
    }

    IEnumerator Death()
    {
        yield return new WaitForSeconds(1f);
        Destroy(gameObject);
    }
}
