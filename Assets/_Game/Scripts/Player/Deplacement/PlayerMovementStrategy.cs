using UnityEngine;

public abstract class PlayerMovementStrategy : ScriptableObject
{
    public abstract bool CanUseStrat(PlayerMovement _player);

    public abstract void UpdateMovement(PlayerMovement _player, float _deltaTime);

    public abstract void OnBeginUseStrat(PlayerMovement _player);

    public abstract void OnEndUseStrat(PlayerMovement _player);
}