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
    public int Damage;
    public float SpeedMoving;
    public float SpeedRotation;
    public int MoneyGet;
    public bool Alive;
    public bool Doubleable;
    void Start()
    {
        Doubleable = true;
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
            Stats.instance.GetDamage(Damage);
            Destroy(gameObject);
        }
    }

    public void DoublePick()
    {
        //var clone1 = Instantiate(gameObject, transform.position, Quaternion.identity);
        //clone1.transform.position += Vector3.forward;
        //clone1.gameObject.transform.localScale /= 2;
        //var clone2 = Instantiate(gameObject, transform.position, Quaternion.identity);
        //clone2.gameObject.transform.localScale /= 2;
        //StartCoroutine(Death());
        Doubleable = false;
        transform.localScale /= 1.5f;
        Health /= 2;
        transform.position += new Vector3(0, 0.1f);
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
            StartCoroutine(Death());
        }
    }

    IEnumerator Death()
    {
        Alive = false;
        SpeedMoving = 0;
        yield return new WaitForSeconds(3f);
        Destroy(gameObject);
    }
}
