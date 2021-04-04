using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NavigationSystem : MonoBehaviour
{
    public static NavigationSystem instance;
    public enum TypeTitle
    {
        Start,
        End,
        Move,
        NotMove
    }
    [SerializeField]
    private TitleEntity[] Titles;
    public TitleEntity StartPoint;
    [SerializeField]
    private TitleEntity EndPoint;
    [SerializeField]
    private List<TitleEntity> CloseTitles;
    [SerializeField]
    private List<TitleEntity> CloseNextTitles;
    public List<TitleEntity> Way;

    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        FindWay();
        
    }

    void Update()
    {
    }
    #region ListFuncitons
    void AddWay(TitleEntity item)
    {
        Way.Add(item);
    }
    void RemoveWay(TitleEntity item)
    {
        Way.Remove(item);
    }
    void AddClose(TitleEntity item)
    {
        CloseTitles.Add(item);
    }
    void RemoveClose(TitleEntity item)
    {
        CloseTitles.Remove(item);
    }
    void AddNextClose(TitleEntity item)
    {
        CloseNextTitles.Add(item);
    }
    void RemoveNextClose(TitleEntity item)
    {
        CloseNextTitles.Remove(item);
    }
    #endregion
    void FindAllTitles()
    {
        Titles = GameObject.FindObjectsOfType<TitleEntity>();
        foreach(TitleEntity title in Titles)
        {
            title.Distance = 99;
        }
        FindStartEndPoint();
    }
    void FindStartEndPoint()
    {
        foreach (TitleEntity title in Titles)
        {
            if (title.Type == TypeTitle.Start)
            {
                StartPoint = title;
                title.Distance = 0;
                AddClose(title);
            }
            if(title.Type == TypeTitle.End)
            {
                EndPoint = title;
                AddWay(title);
            }
        }
    }
    public void FindWay()
    {
        Debug.Log("Find way!");
        Way.Clear();
        FindAllTitles();
        FindClosePoint(StartPoint);
        Nearest();
        if(Way[Way.Count - 1].Type == TypeTitle.End)
        {
            FindClosestWay();
        } else
        {
            Debug.Log("Haven't way");
        }
        DebugK();
    } 
    
    void Nearest()
    {
        bool HaveNext = true;
        if (CloseTitles.Count == 0)
        {
            CloseTitles = CloseNextTitles;
            CloseNextTitles.Clear();
            if (CloseTitles.Count == 0)
            {
                HaveNext = false;
            }
        }
        if (HaveNext)
        {
            for (int i = 0; i < CloseTitles.Count; i++)
            {
                FindClosePoint(CloseTitles[i]);
            }
        }

        if (HaveNext)
            Nearest();
    }
    void FindClosePoint(TitleEntity title)
    {
        foreach (TitleEntity nextTitle in Titles)
        {
            if (Vector3.Distance(title.transform.position, nextTitle.transform.position) < 2f && nextTitle.Type != TypeTitle.NotMove && nextTitle.Distance == 99)
            {
                nextTitle.Distance = title.Distance + 1;
                AddClose(nextTitle);
            }
        }
        RemoveClose(title);
    }
    void FindClosestWay()
    {
        int iend = Way[Way.Count - 1].Distance;
        for (int i = 0; i <= iend; i++)
        {
            bool FoundPoint = false;
            foreach (TitleEntity nextTitle in Titles)
            {
                if (FoundPoint == false)
                {
                    if (Vector3.Distance(Way[Way.Count - 1].transform.position, nextTitle.transform.position) < 2f && nextTitle.Distance == Way[Way.Count - 1].Distance - 1)
                    {
                        FoundPoint = true;
                        AddWay(nextTitle);
                    }
                }
            }
        }
        if(Way[Way.Count - 1].Distance != 0)
        {
            BuildComponent.instance.RemoveBuilding();
        }
    }

    void DebugK()
    {
        foreach (TitleEntity title in Titles)
        {
            title.StartCoroutine(title.AllColor());
        }
        foreach (TitleEntity Debugable in Way)
        {
            Debugable.WayPoint = true;
        }
    }
}
