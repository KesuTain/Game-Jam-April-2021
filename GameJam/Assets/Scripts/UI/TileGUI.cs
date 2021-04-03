using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileGUI : MonoBehaviour
{
	[SerializeField] private GameObject buildingMenu;
	[SerializeField] private GameObject towerMenu;
	[SerializeField] private GameObject hex;

	public void DebugMessage()
	{
		Debug.Log("Clicked!");
	}

	public void BuildTower(BuildComponent.TowerType towerType)
	{
		BuildComponent.instance.BuildTower(hex, towerType);
	}

	public void BuildingMenuSetActive (bool enable)
	{
		buildingMenu.SetActive(enable);
	}

	public void TowerMenuSetActive(bool enable)
	{
		towerMenu.SetActive(enable);
	}

	public void AllMenuSetUnactive()
	{
		buildingMenu.SetActive(false);
		towerMenu.SetActive(false);
	}

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
