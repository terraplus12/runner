using UnityEngine;

public class Environment_Move : Moving_Staff
{
    protected override void Move()
    {
        transform.position += vector * speed * Time.deltaTime * GameSettings.speed;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag("Stop_Object"))
        {
            IsFree = true;
        }
        
    }
    public override void Teleport(Vector3 pos, int RoadIndex)
    {
        if (IsFree == false)
        {
            Debug.LogError("Error: Object is busy");
            return;
        }
        transform.position = new Vector3(pos.x, transform.position.y, pos.z) + Offset;
        IsFree = false;
        if (RoadIndex == 0)
        {
            Vector3 rotate = transform.eulerAngles;
            rotate.y = 180;
            transform.eulerAngles = rotate;
        }
        else
        {
            Vector3 rotate = transform.eulerAngles;
            rotate.y = 0;
            transform.eulerAngles = rotate;
        }
        
    }
}
