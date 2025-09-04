using BCommands;
using UnityEngine;

public class Portal : Trap
{
    protected override void Awake()
    {
        base.Awake();   
        ActionEvent.RegisterCommand(CommandFactory.GenericCommand(this,nameof(RegisterAction)));
    }

    protected override void Activate()
    {
        base.Activate();

        if (DetectPlayer(1, Vector3.up))
        {
            PlayerMovement.Instance.ChangeGravity();
        }
    }
}
