using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManger : MonoBehaviour {
    public static SoundManger Instance = null;

    public AudioClip GoalBloop;
    public AudioClip HitPaddleBloop;
    public AudioClip LossBuzz;
    public AudioClip WinSound;
    public AudioClip WallBloop;

    private AudioSource SoundEffectAudio;

    // Use this for initialization
    void Start () {
        if (Instance == null)
        {
            Instance = this;
        }else if (Instance != this)
        {
            Destroy(gameObject);
        }
        AudioSource[] sources = GetComponents<AudioSource>();
       
        foreach(AudioSource source in sources)
        {
            if (source.clip == null)
            {
                SoundEffectAudio = source;
            }
        }
	}
	
	public void PlayOneShot(AudioClip clip)
    {
        SoundEffectAudio.PlayOneShot(clip);
    }
}
