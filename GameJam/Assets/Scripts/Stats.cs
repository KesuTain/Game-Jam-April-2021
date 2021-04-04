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

    public GameObject EndGamePanel;
	public Text WinLabel;

    public int Cost;
    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        //Health = 999;
        //Money = 100;
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
		OutToUI();
		if (Health <= 0)
        {
            Health = 0;
            OutToUI();
			Loose();
        }
    }
    public void Win()
    {
		WinLabel.text = "Победа!";
		WinLabel.color = Color.green;
		EndGamePanel.SetActive(true);
		//Time.timeScale = 0;
	}
	public void Loose()
	{
		WinLabel.text = "Поражение";
		WinLabel.color = Color.red;
		EndGamePanel.SetActive(true);
		//Time.timeScale = 0;
	}

    void OutToUI()
    {
        MoneyLabel.text = Money.ToString();
        HealthLabel.text = Health.ToString();
    }
}
