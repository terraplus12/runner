using System;
using System.Collections;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Object_Manager : MonoBehaviour
{
    [SerializeField] private Trigger_Checker[] building = new Trigger_Checker[2];
    [SerializeField] private Trigger_Checker[] obstacle = new Trigger_Checker[3];
    [SerializeField] private Environment_Move[] All_Buildings = new Environment_Move[2];
    [SerializeField] private Wall[] All_Walls = new Wall[2];
    private int All_Buildings_Capacity = 0;
    private int All_Walls_Capacity = 0;
    void Teleporter(Moving_Staff[] staff, Trigger_Checker[] checker)
    {
        Moving_Staff[] All_Buildings_Buffer = new Moving_Staff[All_Buildings_Capacity];
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
                print("1");
                All_Buildings_Buffer[All_Buildings_Size - 1].Teleport(t.transform.position);
            }
        }
        
    
}
    IEnumerator Object_Teleporter()
    {
        Teleporter(All_Buildings, building);
        Teleporter(All_Walls, obstacle);
        yield return new WaitForSeconds(5);
    }  

    void Start()
    {
        All_Buildings_Capacity = All_Buildings.Length;
        All_Walls_Capacity = All_Walls.Length;
        StartCoroutine(Object_Teleporter());
    }

    void Update()
    {
        
    }
}
