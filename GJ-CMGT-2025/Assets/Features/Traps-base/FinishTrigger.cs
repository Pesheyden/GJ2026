using BCommands;
using UnityEngine;

public class FinishTrigger : Trap
{
    protected override void Start()
    {
        base.Start();
        ActionEvent.RegisterCommand(CommandFactory.GenericCommand(this,nameof(RegisterAction)));
    }

    protected override void Activate()
    {
        base.Activate();

        if (DetectPlayer(1, Vector3.up) &&  GameManager.Instance.HasKey)
        {
            GameManager.Instance.GameWin();
        }
    }
}
