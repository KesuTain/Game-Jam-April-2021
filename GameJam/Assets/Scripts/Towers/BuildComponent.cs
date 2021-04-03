﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuildComponent : MonoBehaviour
{
	public enum TowerType {SINGLE, SPLASH, DEVIDE}
    [Header("Towers")]
    public GameObject SingleTower;
	public GameObject SplashTower;
	public GameObject DevideTower;
	public GameObject Buildings;
    public static BuildComponent instance;
    public float YUp;
	private TileGUI previousHittenTileGui;
	//private bool isMenuActive = false;

    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
    }
    
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                Debug.Log(hit.collider);
				CloseGUI();
                if (hit.collider.name == "Main")
                {
					if (hit.collider.GetComponentInParent<TitleEntity>().BuildAble == true)
					{
						hit.collider.GetComponentInParent<TileGUI>().BuildingMenuSetActive(true);
					} else
					{
						//hit.collider.GetComponentInParent<TileGUI>().TowerMenuSetActive(true);
					}
					previousHittenTileGui = hit.collider.GetComponentInParent<TileGUI>();
					//BuildSingleTower(hit.collider.gameObject);
					//hit.collider.transform.parent.GetComponent<TitleEntity>().Interface.SetActive(true);
				}
            }
        }
    }

	public void CloseGUI()
	{
		if (previousHittenTileGui != null)
		{
			previousHittenTileGui.AllMenuSetUnactive();
			previousHittenTileGui = null;
		}
	}

	private GameObject GetTowerOfType(TowerType towerType)
	{
		switch (towerType)
		{
			case TowerType.SINGLE:
				return SingleTower;
			case TowerType.SPLASH:
				return SplashTower;
			case TowerType.DEVIDE:
				return DevideTower;
			default:
				return null;
		}
	}

    public void BuildTower(GameObject hit, TowerType towerType)
    {
        hit.GetComponentInParent<TitleEntity>().BuildAble = false;
        hit.GetComponentInParent<TitleEntity>().Type = NavigationSystem.TypeTitle.NotMove;
        NavigationSystem.instance.FindWay();
        Instantiate(GetTowerOfType(towerType), hit.transform.position + new Vector3(0, YUp, 0), Quaternion.identity, Buildings.transform);
    }

}
