using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleEntity: NavigationSystem
{
    public enum TypeDebug
    {
        StartEnd,
        Distance,
        Way
    }
    [Header("Debug")]
    public TypeDebug TypeOfDebug;
    public Color[] Colors;
    public bool WayPoint = false;

    [Header("Core")]
    public GameObject Hex;
    public TypeTitle Type;
    public int Distance;

    public bool BuildAble;
    //public GameObject Interface;
    void Start()
    {
        //Interface.SetActive(false);
        if (Type != TypeTitle.NotMove)
            BuildAble = true;
        else
            BuildAble = false;
        StartCoroutine(AllColor());
    }


    IEnumerator AllColor()
    {
        yield return new WaitForSeconds(1f);
        DebugS();

    }
    void Update()
    {

    }

    public void BuildSingleTower()
    {
        BuildComponent.instance.BuildSingleTower(gameObject);
    }

    #region Debug

    void DebugS()
    {
        switch (TypeOfDebug)
        {
            case TypeDebug.StartEnd:
                ColorTitle();
                break;
            case TypeDebug.Distance:
                ColorDistance();
                break;
            case TypeDebug.Way:
                ColorWay();
                break;
        }
    }
    void ColorTitle()
    {
        switch (Type)
        {
            case TypeTitle.Start:
                Hex.GetComponent<Renderer>().material.color = Color.green;
                break;
            case TypeTitle.End:
                Hex.GetComponent<Renderer>().material.color = Color.red;
                break;
            case TypeTitle.Move:
                Hex.GetComponent<Renderer>().material.color = Color.white;
                break;
            case TypeTitle.NotMove:
                Hex.GetComponent<Renderer>().material.color = Color.gray;
                break;
        }
    }
    void ColorDistance()
    {
       if (Distance != 99)
            Hex.GetComponent<Renderer>().material.color = Colors[Distance];
    }

    void ColorWay()
    {
        if (WayPoint)
        {
            Hex.GetComponent<Renderer>().material.color = Color.yellow;
        }
    }
    #endregion
}
