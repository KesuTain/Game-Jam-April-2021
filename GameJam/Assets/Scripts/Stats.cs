using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stats : MonoBehaviour
{
    public static Stats instance;

    public int Money;
    private void Awake()
    {
        instance = this;
    }

    public void GetMoney(int Count)
    {
        Money += Count;
    }
}
