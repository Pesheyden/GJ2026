using UnityEngine;

public class BackgroundMusicTrigger : MonoBehaviour
{
    [SerializeField] private GameDataSo _gameData;
    private AudioSource _audioSource;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
        _audioSource.clip = _gameData.BackgroundMusicSound;
        _audioSource.loop = true;
        _audioSource.volume = _gameData.BackgroundMusicVolume;
    }
}
