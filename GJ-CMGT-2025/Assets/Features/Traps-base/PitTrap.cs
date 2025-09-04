using BCommands;
using UnityEngine;

public class PitTrap : Trap
{
    [SerializeField] private SpriteRenderer _pitTrapSpriteRenderer;
    [SerializeField] private Sprite _closeSprite;
    [SerializeField] private Sprite _openSprite;
    [SerializeField] private float _closeTime;
    
    
    [SerializeField]
    protected override void Start()
    {
        base.Start();   
        ActionEvent.RegisterCommand(CommandFactory.GenericCommand(this,nameof(RegisterAction)));
    }

    protected override void Activate()
    {
        base.Activate();

        _pitTrapSpriteRenderer.sprite = _openSprite;
        
        if(DetectPlayer(1, Vector3.up))
            GameManager.Instance.GameEnd();

        Invoke(nameof(CloseTrap),_closeTime);
    }

    private void CloseTrap()
    {
        _pitTrapSpriteRenderer.sprite = _closeSprite;
    }
}
