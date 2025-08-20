using UnityEngine;

public class Wall : Moving_Staff
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
}
    

 
