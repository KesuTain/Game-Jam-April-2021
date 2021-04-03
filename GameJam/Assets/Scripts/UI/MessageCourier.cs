using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MessageCourier : MonoBehaviour
{
	private TileGUI tileGUI;
	//private 


    // Start is called before the first frame update
    void Start()
    {
		tileGUI = GetComponentInParent<TileGUI>();
    }

	public void Message1()
	{
		tileGUI.DebugMessage();
	}

	public void BuildTower(int towerType)
	{
		switch (towerType)
		{
			case 1:
				tileGUI.BuildTower(BuildComponent.TowerType.SINGLE);
				break;
			case 2:
				tileGUI.BuildTower(BuildComponent.TowerType.SPLASH);
				break;
			case 3:
				tileGUI.BuildTower(BuildComponent.TowerType.DEVIDE);
				break;
		}
		BuildComponent.instance.CloseGUI();
	}

    // Update is called once per frame
    void Update()
    {
        
    }
}
