using UnityEngine;

[CreateAssetMenu(fileName = "UIDataSo", menuName = "Scriptable Objects/UIDataSo")]
public class GameDataSo : ScriptableObject
{
    public AudioClip ButtonClickSound;
    public float ButtonClickMusicVolume;
    public AudioClip BackgroundMusicSound;
    public float BackgroundMusicVolume;
    
    public AudioClip LaserSound;
    public float  LaserVolume;
}
