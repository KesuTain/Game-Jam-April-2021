using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Stats : MonoBehaviour
{
    public static Stats instance;

    public int Money;
    public int Health;

    public Text MoneyLabel;
    public Text HealthLabel;

    public GameObject LosePanel;
    public GameObject WinPanel;

    public int Cost;
    private void Awake()
    {
        instance = this;
        
    }

    private void Start()
    {
        Health = 999;
        Money = 100;
        OutToUI();
    }
    public void GetMoney(int Count)
    {
        Money += Count;
        OutToUI();
    }

    public void GetDamage(int Damage)
    {
        Health -= Damage;
        if(Health <= 0)
        {
            Health = 0;
            OutToUI();
            LosePanel.SetActive(true);
        }
    }
    public void Win()
    {
        WinPanel.SetActive(true);
    }
    void OutToUI()
    {
        MoneyLabel.text = Money.ToString();
        HealthLabel.text = Health.ToString();
    }
}
