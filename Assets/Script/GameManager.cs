using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager manager;
    public List<Item> inv = new List<Item>();

    void Awake()
    {
        if (manager != null)
        {
            GameObject.Destroy(manager);
        } 
        else
        {
            manager = this;
        }

        DontDestroyOnLoad(this);
    }


    public void printInventory() 
    {
        //Debug.Log("printing inv with " + inv.Count);
        foreach (var i in inv)
        {
            Debug.Log(i.name);
        }
    }
}
