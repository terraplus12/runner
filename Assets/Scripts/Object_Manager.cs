using System;
using System.Collections;
using System.Linq;
using UnityEngine;

public class Object_Manager : MonoBehaviour
{
    [SerializeField] private Trigger_Checker[] building = new Trigger_Checker[2];
    [SerializeField] private Trigger_Checker[] obstacle = new Trigger_Checker[3];
    [SerializeField] private Environment_Move[] All_Buildings = new Environment_Move[2];
    [SerializeField] private Coin_Move[] All_Coins = new Coin_Move[2];
    [SerializeField] private Wall[] All_Walls = new Wall[2];
    void Teleporter(Moving_Staff[] staff, Trigger_Checker[] checker, int random = Int32.MaxValue)
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
        for (int Counter = 0; Counter < checker.Length; Counter++)
        {
            var t = checker[Counter];
            if (All_Buildings_Size == 0)
            {
                break;
            }

            if (t.Is_Free == true)
            {
                if (random == 0)
                {
                    break;
                }
                random--;
                All_Buildings_Buffer[All_Buildings_Size - 1].Teleport(t.transform.position, Counter);
                All_Buildings_Size--;
                t.Is_Free = false;
            }
        }
        
    
}
    IEnumerator Object_Teleporter()
    {
        while (true)
        {
            int command_random = UnityEngine.Random.Range(0, 2);
            int random = UnityEngine.Random.Range(1, 3);
            Teleporter(All_Buildings, building);
            if (command_random == 0)
            {
                Teleporter(All_Walls, obstacle, random);
                Teleporter(All_Coins, obstacle);
            }
            else
            {
                Teleporter(All_Coins, obstacle);
                Teleporter(All_Walls, obstacle, random);
            }
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
