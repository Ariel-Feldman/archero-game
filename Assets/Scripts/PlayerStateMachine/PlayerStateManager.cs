﻿using UnityEngine;

public class PlayerStateManager : MonoBehaviour
{
    //
    private IPlayerState _state;
    private PlayerMoveState _playerMoveState;
    private PlayerShotState _playerShotState;

    private void Awake()
    {
        _playerMoveState = GetComponent<PlayerMoveState>();
        _playerShotState = GetComponent<PlayerShotState>();
    }

    
    private void Update() 
    {
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

