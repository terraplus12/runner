using UnityEngine;

public abstract class Moving_Staff : MonoBehaviour
{
    [SerializeField] protected Vector3 vector;
    [SerializeField] protected float speed;
    [SerializeField] protected Vector3 Offset;
    [SerializeField] public bool IsFree { get; protected set; } = true;
    protected abstract void Move();
    public virtual void Teleport(Vector3 pos, int RoadIndex)
    {
        if (IsFree == false)
        {
            Debug.LogError("Error: Object is busy");
            return;
        }
        transform.position = new Vector3(pos.x, transform.position.y, pos.z) + Offset;
        IsFree = false;

    }
    public void ForceTeleport(Vector3 pos)
    {
        transform.position = new Vector3(pos.x, transform.position.y, pos.z) + Offset;
      

    }
    
    void Update()
    {
        if (IsFree == false)
        {
            Move();
        }
        
    }
}
