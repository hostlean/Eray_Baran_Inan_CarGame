using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DefaultExecutionOrder(-1)]
public class MusicManager : MonoBehaviour
{
    #region Singleton

    private static MusicManager _instance;

    public static MusicManager Instance
    {
        get
        {
            if(_instance == null)
                Debug.LogError("Music Manager is Null");
            return _instance;
        }
    }

    #endregion
    
    private void Awake()
    {
        if (_instance != null)
            Destroy(gameObject);
        else
            _instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public AudioSource audioSource;

    public void ChangeVolume(float volume)
    {
        audioSource.volume = volume;
    }

}
