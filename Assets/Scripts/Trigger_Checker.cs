using Unity.VisualScripting;
using UnityEngine;

public class Trigger_Checker : MonoBehaviour
{
    public bool Is_Free = true;
    private int Building_Count = 0;
    private void OnTriggerEnter(Collider other)
    {
        Building_Count++;
    }
    private void OnTriggerExit(Collider other)
    {
        Building_Count--;
    }
    void Update()
    {
        if (Building_Count == 0)
        {
            Is_Free = true;
        }
        else
        {
            Is_Free = false;
        }
    }
}
