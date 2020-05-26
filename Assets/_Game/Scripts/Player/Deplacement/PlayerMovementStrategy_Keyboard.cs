using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "New PlayerMovementStrategy_Keyboard", menuName = "Player Movement Strategy/Keyboard", order = 150)]
public class PlayerMovementStrategy_Keyboard : PlayerMovementStrategy
{
    public override bool CanUseStrat(PlayerMovement _player)
    {
        Vector3 direction = new Vector3
            (
                InputController.Instance.GetAxisHorizontal(),
                0,
                InputController.Instance.GetAxisVertical()
            );
        
        return direction != Vector3.zero;
    }

    public override void OnBeginUseStrat(PlayerMovement _player)
    {
        
    }

    public override void OnEndUseStrat(PlayerMovement _player)
    {
        
    }

    public override void UpdateMovement(PlayerMovement _player, float _deltaTime)
    {
        _player.GetOnMove.Invoke(new MovementInfo { });
    }
}
