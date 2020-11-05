using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGM : MonoBehaviour
{
    private AudioSource _audioSource;
    private static GameObject instance;
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        if (instance == null)
        {
            instance = gameObject;
        }
        else
        {
            Destroy(gameObject);
        }

        _audioSource = GetComponent<AudioSource>();
    }

    public void PlayMusic()
    {
        _audioSource.volume = 0.25f;
        if (_audioSource.isPlaying) return;
        _audioSource.Play();
    }

    public void PauseMusic()
    {
        _audioSource.volume = 0f;
        _audioSource.Pause();
    }
}
