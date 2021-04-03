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
    void Start()
    {
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
}
