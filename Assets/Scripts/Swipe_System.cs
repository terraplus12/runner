using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
public enum Swipe_Directions
{
    None,
    Left,
    Right,
    Up,
    Down,
    
}
public class Swipe_System: MonoBehaviour
{
    public Swipe_Directions swipe_Directions { get; private set; }
    private float treshold = 0.05f;
    public delegate void swipe_event_handler();
    
    public event swipe_event_handler left_event;
    public event swipe_event_handler right_event;
    public event swipe_event_handler up_event;
    public event swipe_event_handler down_event;

    private void onSwipe()
    {
        if (swipe_Directions == Swipe_Directions.Up)
        {
           up_event?.Invoke();
        }
        if (swipe_Directions == Swipe_Directions.Right)
        {
            right_event?.Invoke();
        }
        if (swipe_Directions == Swipe_Directions.Left)
        {
            left_event?.Invoke();
        }
        if (swipe_Directions == Swipe_Directions.Down)
        {
            down_event?.Invoke();
        }
    }


    private Swipe_Directions Get_Swipe_Direction()
    {
        
        
        if (Input.touchCount == 0)
       {
           return Swipe_Directions.None;
        }
        
        if (Input.GetTouch(0).deltaPosition.normalized.sqrMagnitude < treshold) 

        {
           return Swipe_Directions.None;
        }
        float Dot_Up = Vector2.Dot(Vector2.up, Input.GetTouch(0).deltaPosition.normalized);
        float Dot_Down = Vector2.Dot(Vector2.down, Input.GetTouch(0).deltaPosition.normalized);
        float Dot_Right = Vector2.Dot(Vector2.right, Input.GetTouch(0).deltaPosition.normalized);
        float Dot_Left = Vector2.Dot(Vector2.left, Input.GetTouch(0).deltaPosition.normalized);
        
        if (Dot_Up >= 0.5)
        {
            return Swipe_Directions.Up;
        }
        else if (Dot_Down >= 0.5)
        {
            return Swipe_Directions.Down;
        }
        else if (Dot_Left >= 0.5)
        {
            return Swipe_Directions.Left;
        }
        else if (Dot_Right >= 0.5)
        {
            return Swipe_Directions.Right;
        }
        
        return Swipe_Directions.None;
        
        
    }
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        swipe_Directions = Get_Swipe_Direction();
        print (swipe_Directions);
        onSwipe();
        

    }


} 

