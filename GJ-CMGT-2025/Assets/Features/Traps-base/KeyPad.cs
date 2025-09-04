using BCommands;
using UnityEngine;
using UnityEngine.Events;

public class KeyPad : Trap
{
    private static bool _wasOnThePad;
    private static int _padsActivated;
    [SerializeField] private int _padsAmount;
    [SerializeField] private UnityEvent _onAllPadsActivated;
    
    protected override void Start()
    {
        base.Start();
        ActionEvent.RegisterCommand(CommandFactory.GenericCommand(this,nameof(RegisterAction)));
    }
    
    protected override void Activate()
    {
        base.Activate();
        

        if (DetectPlayer(1, Vector3.up))
        {
            if (_wasOnThePad)
                _padsActivated++;
            else
            {
            }
            
            if(_padsActivated == _padsAmount)
                _onAllPadsActivated.Invoke();
            
            return;
        }

        _wasOnThePad = false;
    }
}
