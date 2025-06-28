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
    private Swipe_Directions swipe_Directions;
    private float treshold = 0.05f;
    private Swipe_Directions Get_Swipe_Direction()
    {
        if (Input.touchCount == 0)
        {
            return Swipe_Directions.None;
        }
        if (Input.GetTouch(0).deltaPosition.normalized.sqrMagnitude > treshold)
        {
            return Swipe_Directions.None;
        }
        return Swipe_Directions.None;

        
   }
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
