using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;
using System.IO;
using System.Threading;
using System.Collections;
public class ProgressSaver : MonoBehaviour
{
    private string Filename = "SaveFile";
    private string FileWay;
    public GameData data = new GameData();
    

    private void Load()
    {
        data.Load(FileWay);
    }
    private void Save()
    {
        string json = data.Save(FileWay);
        Debug.Log(FileWay);
        File.WriteAllText(FileWay, json);
    }
    private IEnumerator timer()
    {
        while (true)
        {
            Save();
            yield return new WaitForSeconds(2);
        }

                
    }
    void Awake()
    {
        FileWay = Application.persistentDataPath + "/" + Filename;
        Load();
        Save();
        StartCoroutine(timer());
    }
    void Update()
    {
        
    }
}
