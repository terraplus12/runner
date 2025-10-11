using Mono.Cecil;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
public enum SkinStatus
{
    Unbought,
    Bought,
    Selected
}
[System.Serializable]
public class SkinInfo
{
    public SkinStatus Skin;
    public int Price;
    
}
public class Skin : MonoBehaviour
{
    [SerializeField] private SkinInfo SkinInf;
    [SerializeField] private Transform PosPoint;
    [SerializeField] private string ModelName;
    private Color[] AllColors = new Color[3] { Color.red, Color.green, Color.yellow };
    private void StatusChanger(SkinStatus status)
    {
        SkinInf.Skin = status;
        Image color = transform.GetChild(0).GetComponent<Image>();
        color.color = AllColors[(int)SkinInf.Skin ];
    }
    private void StatusChanger()
    {
        Image color = transform.GetChild(0).GetComponent<Image>();
        color.color = AllColors[(int)SkinInf.Skin];
    }
    public void Show()
    {
        for (int i = 0; i < PosPoint.childCount; i++)
        {

            GameObject Child = PosPoint.GetChild(i).gameObject;
            Destroy(Child);
        }
        GameObject SpawnObj = Resources.Load<GameObject>(ModelName);
        if (SpawnObj != null)
        {
             GameObject Spawned = Instantiate(SpawnObj, PosPoint.position, Quaternion.identity);
            Spawned.transform.SetParent(PosPoint);
            Spawned.transform.localRotation = Quaternion.identity;
            Spawned.transform.AddComponent<CharacterView>();
        }
    }
    void Start()
    {
        StatusChanger();
    }
    void Update()
    {
        
    }
}
