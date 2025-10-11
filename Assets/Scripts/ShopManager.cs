using TMPro;
using UnityEngine;

public class ShopManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI Count_Text;
    [SerializeField] private ProgressSaver saver;
    void Start()
    {
        
    }
    void Update()
    {
         Count_Text.text = saver.data.CoinCount.ToString();
    }
}
