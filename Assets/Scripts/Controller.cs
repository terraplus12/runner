using UnityEngine;
using DG.Tweening;
public class Controller : MonoBehaviour
{
    [SerializeField] private Swipe_System swipe_system;
    [SerializeField] private float Move_Distance_y = 10;
    [SerializeField] private float Move_Distance_z = 3;
    [SerializeField] private float Move_Distance_Minus_z = -3;
    [SerializeField] private float Animation_Time = 3;
    private bool Is_Moving;

    void Start()
    {
        swipe_system.up_event += Move_Up;
        swipe_system.down_event += Move_Down;
        swipe_system.right_event += Move_Right;
        swipe_system.left_event += Move_Left;
    }
    private void Move_Up()
    {
        if (Is_Moving)
        {
            return;
        }
        Is_Moving = true;
        Vector3 pos = transform.position;
        transform.DOJump(pos, Move_Distance_y, 1, Animation_Time).SetEase(Ease.InOutFlash).OnComplete(() => Is_Moving = false);

    }
    private void Move_Down()
    {
        if (Is_Moving)
        {
            return;
        }
        Is_Moving = true;
        transform.DOScaleY(0.5f, Animation_Time / 2.0f).OnComplete(() => transform.DOScaleY(1, Animation_Time / 2.0f).OnComplete(() => Is_Moving = false));

    }
    private void Move_Right()
    {
        if (Is_Moving)
        {
            return;
        }
        Is_Moving = true;
        Vector3 targetPos = transform.position + new Vector3(0, 0, Move_Distance_z);
        transform.DOMoveZ(targetPos.z, Animation_Time).SetEase(Ease.InOutFlash).OnComplete(() => Is_Moving = false);
    
}
    private void Move_Left()
    {
        if (Is_Moving)
        {
            return;
        }
        Is_Moving = true;
        Vector3 targetPos = transform.position + new Vector3(0, 0, Move_Distance_Minus_z);
        transform.DOMoveZ(targetPos.z, Animation_Time).SetEase(Ease.InOutFlash).OnComplete(() => Is_Moving = false);
    

}


    void Update()
    {
        
        
        
       
    }
}
