using UnityEngine;
using UnityEngine.SceneManagement;

public class Back_To_Menu_Anim : Button_Anim
{
    protected override void OnButtonClicked()
    {
        SceneManager.LoadScene("Main_Menu");
    }
    void Update()
    {
        
    }
}
