using UnityEngine;

public class MusicManager : MonoBehaviour
{
    [SerializeField] private AudioClip CoinAudio;
    [SerializeField] private AudioClip WallAudio;
    [SerializeField] private AudioClip[] AllMusic;
    [SerializeField] private AudioSource CoinSourceAudio;
    [SerializeField] private AudioSource WallSourceAudio;
    [SerializeField] private AudioSource MusicSourceAudio;
    [SerializeField] private int NowMusic = -1;

    public void PlayCoinAudio()
    {
        CoinSourceAudio.Play();
    }
    public void PlayObstacleAudio()
    {
        WallSourceAudio.Play();
    }
    private void PlayMusic()
    {
        if (MusicSourceAudio.isPlaying)
        {
            return;
        }
        if (NowMusic + 1 < AllMusic.Length)
        {
            NowMusic++;
        }
        else
        {
            NowMusic = 0;
        }
        MusicSourceAudio.clip = AllMusic[NowMusic];
        MusicSourceAudio.Play();
    }
    void Start()
    {
        CoinSourceAudio.clip = CoinAudio;
        WallSourceAudio.clip = WallAudio;
    }
    void Update()
    {
        PlayMusic();
    }
}
