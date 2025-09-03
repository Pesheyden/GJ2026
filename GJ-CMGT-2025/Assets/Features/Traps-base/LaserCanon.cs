
using System.Collections.Generic;
using BCommands;
using UnityEngine;

public class LaserCanon : Trap
{
    [SerializeField] private GameObject _laserPrefab;
    [SerializeField] private int _range;
    [SerializeField] private Vector3 _direction;
    [SerializeField] private Vector3 _laserBeamRotation;
    [SerializeField] private float _laserProjectilesLifeTime;

    private List<GameObject> _laserProjectiles = new List<GameObject>();

    protected override void Awake()
    {
        base.Awake();   
        ActionEvent.RegisterCommand(CommandFactory.GenericCommand(this,nameof(RegisterAction)));
    }

    protected override void Activate()
    {
        base.Activate();
        var pos = transform.position;
        for (int i = 0; i < _range; i++)
        {
            pos += _direction * BlockSize;
            _laserProjectiles.Add(Instantiate(_laserPrefab, pos, Quaternion.Euler(_laserBeamRotation), transform));
        }

        if (DetectPlayer(_range * BlockSize, _direction))
        {
            GameManager.Instance.GameEnd();
        }
        
        Invoke(nameof(DestroyProjectiles),_laserProjectilesLifeTime);
    }

    private void DestroyProjectiles()
    {
        foreach (var projectile in _laserProjectiles)
        {
            Destroy(projectile);
        }
        _laserProjectiles.Clear();
    }
}
