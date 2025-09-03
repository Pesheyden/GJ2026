using System;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class UIButtonHelper : MonoBehaviour
{
    [SerializeField] private GameDataSo _gameData;
    private AudioSource _audioSource;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    public void TriggerClickSound()
    {
        _audioSource.PlayOneShot(_gameData.ButtonClickSound,_gameData.ButtonClickMusicVolume);
    }
}
