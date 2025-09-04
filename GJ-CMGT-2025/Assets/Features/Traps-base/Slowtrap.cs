using BCommands;
using UnityEngine;

public class Slowtrap : Trap
{
    private bool _wasTriggered = false;
    protected override void Start()
    {
        base.Start();
        ActionEvent.RegisterCommand(CommandFactory.GenericCommand(this,nameof(RegisterAction)));
    }
    
    protected override void Activate()
    {
        base.Activate();

        if (DetectPlayer(1, Vector3.up) && !_wasTriggered)
        {
            _wasTriggered = true;
            ActionEvent.Raise();
            return;
        }

        _wasTriggered = false;
    }
}
