using UnityEngine;

public class Close_Menu : Button_Anim
{
    [SerializeField] private GameObject Panel;
    protected override void OnButtonClicked()
    {
        Panel.SetActive(false);
        
    }
}
