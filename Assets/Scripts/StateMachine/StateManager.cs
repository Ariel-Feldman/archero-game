using UnityEngine;

public class StateManager : MonoBehaviour
{
    // We using Interface the get fast switch system
    private IPlayerState _state;
    private MoveState _playerMoveState;
    private ShotState _playerShotState;

    private void Awake()
    {
        _playerMoveState = GetComponent<MoveState>();
        _playerShotState = GetComponent<ShotState>();
    }

    private void Update() 
    {
        // If we in Pause mode - fast out
        if(GameManager.Instance.InPauseMode)
            return;

        if(_state != null)
            _state.Execute();
    }

    // SetState is called direct from the input system getting the desired sate of the player ( Move or Shot or now... :)
    public void SetState(PlayerState playerState)
    {
        switch (playerState)
        {

            case PlayerState.MovingState:
                _state = _playerMoveState;
                break;
                
            case PlayerState.ShotingState:
                _state = _playerShotState;
                break;

            // We will probably going to need some freeze state
            // case PlayerState.FreezeState:
                // state = playerFreezable;
                // break;

            default:
                // TODO - this place will probably need attention for fail cases
                // And if we going to have more playere state
                break;
        }
    }
}

