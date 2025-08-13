using System;
using System.Collections;
using System.Linq;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Object_Manager : MonoBehaviour
{
    [SerializeField] private Trigger_Checker[] building = new Trigger_Checker[2];
    [SerializeField] private Trigger_Checker[] obstacle = new Trigger_Checker[3];
    [SerializeField] private Environment_Move[] All_Buildings = new Environment_Move[2];
    [SerializeField] private Coin_Move[] All_Coins = new Coin_Move[2];
    [SerializeField] private Wall[] All_Walls = new Wall[2];
    void Teleporter(Moving_Staff[] staff, Trigger_Checker[] checker)
    {
        Moving_Staff[] All_Buildings_Buffer = new Moving_Staff[staff.Count()];
        int All_Buildings_Size = 0;
        foreach (var t in staff)
        {
            if (t.IsFree)
            {
                All_Buildings_Buffer[All_Buildings_Size] = t;
                All_Buildings_Size++;
            }
        }
        foreach (var t in checker)
        {
            if (All_Buildings_Size == 0)
            {
                break;
            }

            if (t.Is_Free == true)
            {
                All_Buildings_Buffer[All_Buildings_Size - 1].Teleport(t.transform.position);
                All_Buildings_Size--;
                t.Is_Free = false;
            }
        }
        
    
}
    IEnumerator Object_Teleporter()
    {
        while (true)
        {
            Teleporter(All_Buildings, building);
            Teleporter(All_Walls, obstacle);
            Teleporter(All_Coins, obstacle);
            yield return new WaitForSeconds(5);
        }
    }  

    void Start()
    {
        
        StartCoroutine(Object_Teleporter());
    }

    void Update()
    {
        
    }
}
