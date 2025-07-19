using UnityEngine;

public abstract class Moving_Staff : MonoBehaviour
{
    [SerializeField] protected Vector3 vector;
    [SerializeField] protected float speed;
    [SerializeField] public bool IsFree { get; protected set; } = true;
    protected abstract void Move();
    public void Teleport(Vector3 pos)
    {
        if (IsFree == false)
        {
            Debug.LogError("Error: Object is busy");
            return;
        }
        transform.position = pos;
        IsFree = false;

    }
    
    void Start()
    {
        
    }

    
    void Update()
    {
        if (IsFree == false)
        {
            Move();
        }
        
    }
}
