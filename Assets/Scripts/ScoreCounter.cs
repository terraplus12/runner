using TMPro;
using Unity.Android.Gradle.Manifest;
using UnityEngine;

public class ScoreCounter : MonoBehaviour
{
    [SerializeField] private float interval = 1f;
    private float timer = 0f;
    [SerializeField] private ProgressSaver score;
    [SerializeField] private TextMeshProUGUI ScoreCount;

    void Update()
    {
        
        timer += Time.deltaTime;
        if (timer >= interval)
        {
            score.data.ScoreCount++;
            ScoreCount.text = score.data.ScoreCount.ToString();
            timer -= interval; 
        }
    }
}
