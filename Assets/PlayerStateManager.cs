using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateManager : MonoBehaviour // Sineglton
{

    private IPlayerState state;
    private static PlayerStateManager _instance;
    
    public static PlayerStateManager Instance
    {
        get { return _instance; }
    }

    private PlayerMoveState playerMoveState;
    private PlayerShotState playerShotState;

    private void Awake()
    {
        // Unity Simple Singleton Implementation - do nt try this with multithreading
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        } 
        else 
        {
            _instance = this;
        }

        playerMoveState = new PlayerMoveState();
        playerShotState = new PlayerShotState();
    }



    // SetState is called direct from the input system getting the desired sate of the player ( Move or Shot or now... :)
    public void SetState(PlayerState playerState)
    {
        switch (playerState)
        {

            case PlayerState.MovingState:
                state = playerMoveState;
                break;
                
            case PlayerState.ShotingState:
                state = playerShotState;
                break;

            // We will probably going to need some freeze state
            // case PlayerState.FreezState:
                // state = playerFreeztate;
                // break;

            default:
                // TODO - this place will probebly need attaion for fail casses
                // And if we going to have more playere state
                break;
        }

        state.Execute();
    }


}

