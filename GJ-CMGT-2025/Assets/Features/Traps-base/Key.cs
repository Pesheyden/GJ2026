using BCommands;
using UnityEngine;

public class Key : Trap
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
            GameManager.Instance.HasKey = true;
            gameObject.SetActive(false);
        }

    }
}
