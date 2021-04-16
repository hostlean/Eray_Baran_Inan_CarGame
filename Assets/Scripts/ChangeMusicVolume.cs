using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeMusicVolume : MonoBehaviour
{
    [SerializeField] private Slider slider;

    private void OnEnable()
    {
 
        slider.onValueChanged.AddListener((float arg0) => MusicManager.Instance.ChangeVolume(slider.value));
        slider.value = MusicManager.Instance.audioSource.volume;
    }
}
