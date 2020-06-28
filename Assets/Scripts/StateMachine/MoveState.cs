using UnityEngine;

public class MoveState : MonoBehaviour, IPlayerState
{
    private IMovementSystem _movementSystem;

    private void Awake() 
    {
        _movementSystem = transform.parent.GetComponentInChildren<IMovementSystem>();
    }
    public void Execute()
    {
        _movementSystem.MovePlayer();
    }
}
