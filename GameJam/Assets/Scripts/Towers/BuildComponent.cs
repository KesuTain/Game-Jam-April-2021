using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuildComponent : MonoBehaviour
{
    [Header("Towers")]
    public GameObject SingleTower;
    public GameObject Buildings;
    public static BuildComponent instance;
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
                if (hit.collider.name == "Main" && hit.collider.GetComponentInParent<TitleEntity>().BuildAble == true)
                {
                    BuildSingleTower(hit.collider.gameObject);
                    //hit.collider.transform.parent.GetComponent<TitleEntity>().Interface.SetActive(true);
                }
            }
        }
    }

    public void BuildSingleTower(GameObject hit)
    {
        hit.GetComponentInParent<TitleEntity>().BuildAble = false;
        Instantiate(SingleTower, hit.transform.position, Quaternion.identity, Buildings.transform);
    }

}
