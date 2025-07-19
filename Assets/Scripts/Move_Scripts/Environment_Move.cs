using UnityEngine;

public class Environment_Move : Moving_Staff
{
    protected override void Move()
    {
        transform.position += vector * speed * Time.deltaTime;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag("Stop_Object"))
        {
            IsFree = true;
        }

    }
}
