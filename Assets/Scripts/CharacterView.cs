using UnityEngine;

public class CharacterView : MonoBehaviour
{
    private float Sensitivity = 1000;
    private float Smoothness = 1;
    private Vector3 rotation;  
    void Start()
    {
        rotation = transform.eulerAngles;
    }
    void Update()
    {
       float Yrot = Input.mousePositionDelta.x * Time.deltaTime * Sensitivity;
        rotation.y += Yrot;
        Quaternion target = Quaternion.Euler(transform.rotation.x, rotation.y, 0);
        transform.rotation = Quaternion.Slerp(transform.rotation, target, Smoothness*Time.deltaTime);

    }
}
