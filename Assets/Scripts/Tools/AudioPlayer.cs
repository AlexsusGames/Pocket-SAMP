using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AudioPlayer : MonoBehaviour
{
    [SerializeField] private KindOfAudio kindOfAudio;
    private SoundDataLoader soundData = new();
    private AudioSource audioSource => GetComponent<AudioSource>();


    private void Awake() => UpdateVolume();
    public void UpdateVolume()
    {
        if (kindOfAudio == KindOfAudio.Music) audioSource.volume = soundData.GetSoundData().MusicValue;
        if (kindOfAudio == KindOfAudio.Sound) audioSource.volume = soundData.GetSoundData().SoundValue;
    }
    public void Play()
    {
        audioSource.PlayOneShot(audioSource.clip);
    }
}
public enum KindOfAudio
{
    Music,
    Sound
}
