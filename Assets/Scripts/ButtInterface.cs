using TMPro;
using UnityEngine;

public class ButtInterface : MonoBehaviour
{
   [SerializeField] private GameObject Button;
    [SerializeField] private TextMeshProUGUI ButtonText;
    void Start()
    {
        Transform child = Button.transform.GetChild(0);
        ButtonText = child.GetComponent<TextMeshProUGUI>();
    }
    void Update()
    {
        
    }
    public void EnableButton(string Price)
    {
        Button.SetActive(true);
        ButtonText.text = Price;
    }
    public void DisableButton()
    {
        Button.SetActive(false);
    }
}
