using UnityEngine;

public class CharacterView : MonoBehaviour
{
    private float Sensitivity = 10;
    private Vector3 rotation;  
    void Start()
    {
        
    }
    void Update()
    {
       float Yrot = Input.mousePositionDelta.x * Time.deltaTime * Sensitivity;
        rotation.y += Yrot;
        transform.rotation = Quaternion.Euler(transform.rotation.x, rotation.y, 0);

    }
}
