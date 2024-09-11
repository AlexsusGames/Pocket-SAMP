using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundController : MonoBehaviour
{
    [SerializeField] private Slider musicSlider;
    [SerializeField] private Slider soundSlider;
    private AudioPlayer[] audioVolumes => FindObjectsOfType<AudioPlayer>();
    private event Action OnValueChange;
    private SoundDataLoader soundData = new();

    private void OnEnable()
    {
        for (int i = 0; i < audioVolumes.Length; i++)
        {
            OnValueChange += audioVolumes[i].UpdateVolume;
        }
    }
    private void OnDisable()
    {
        for (int i = 0; i < audioVolumes.Length; i++)
        {
            OnValueChange -= audioVolumes[i].UpdateVolume;
        }
    }
    private void Start()
    {
        musicSlider.value = soundData.GetSoundData().MusicValue;
        soundSlider.value = soundData.GetSoundData().SoundValue;
        musicSlider.onValueChanged.AddListener(ChangeMusic);
        soundSlider.onValueChanged.AddListener(ChangeSound);
    }
    private void ChangeMusic(float value)
    {
        soundData.ChangeSoundSettings(value, soundData.GetSoundData().SoundValue);
        OnValueChange?.Invoke();
    }
    private void ChangeSound(float value)
    {
        soundData.ChangeSoundSettings(soundData.GetSoundData().MusicValue, value);
        OnValueChange?.Invoke();
    }
}
