using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveComponent : MonoBehaviour
{
    public TitleEntity CurrentPoint;
    public TitleEntity NextPoint;
    public int NumberPoint;

    void Start()
    {
        StartPosition();
    }

    void StartPosition()
    {
        NumberPoint = NavigationSystem.instance.Way.Count - 1;
        CurrentPoint = NavigationSystem.instance.StartPoint;
        transform.position = CurrentPoint.transform.position;
    }

    public TitleEntity FindNextPosition()
    {
        if(NumberPoint > -1)
        {
            NumberPoint--;
            if(NumberPoint >= 0)
            {
                CurrentPoint = NavigationSystem.instance.Way[NumberPoint];
            }
        }
        return CurrentPoint;
    }
    void Update()
    {
        
    }
    

}
