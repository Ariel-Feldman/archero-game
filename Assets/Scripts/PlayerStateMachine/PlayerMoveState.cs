using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveState : MonoBehaviour, IPlayerState
{
    public MovementSystem _movementSystem;
    public void Execute()
    {
        _movementSystem.MovePlayer();
    }
}
