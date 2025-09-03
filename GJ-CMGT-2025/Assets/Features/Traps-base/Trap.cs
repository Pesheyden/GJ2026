using System;
using BCommands;
using BSOAP.Events;
using NaughtyAttributes;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Trap : MonoBehaviour
{
    [SerializeField] protected CommandEventSo ActionEvent;
    [SerializeField] private TextMeshProUGUI _timerText;
    [SerializeField] protected int TriggerTime;
    [ShowNonSerializedField] private int _timer;
    
    [SerializeField] protected float BlockSize;
    [SerializeField] private GameDataSo _gameDataSo;
    private AudioSource _audioSource;
    [SerializeField] private AudioClip _audioClip;
    

    protected virtual void Awake()
    {
        _audioSource = GetComponent<AudioSource>();

        _timer = TriggerTime;
        if(_timerText)
            _timerText.text = _timer.ToString();
        
    }

    protected void RegisterAction()
    {
        _timer--;
        if(_timerText)
            _timerText.text = _timer.ToString();
        if (_timer == 0)
        {
            _timer = TriggerTime;
            if(_timerText)
                _timerText.text = _timer.ToString();
            Activate();
        }
    }

    protected virtual void Activate()
    {
        _audioSource.PlayOneShot(_audioClip);
    }

    protected bool DetectPlayer(float maxDistance, Vector3 direction)
    {
        if (Physics.Raycast(transform.position, direction, out var hit, maxDistance))
        {
            Debug.Log(this + " " + hit);
            if (hit.collider.CompareTag("Player"))
                return true;

        }
        Debug.DrawRay(transform.position, direction, Color.coral, 2);
        return false;
    }
}
