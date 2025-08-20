using UnityEngine;

public class Show_Menu : Button_Anim
{
    [SerializeField] private GameObject Panel; 
   protected override void OnButtonClicked()
    {
       Panel.SetActive(true);
      
    }
    
}
