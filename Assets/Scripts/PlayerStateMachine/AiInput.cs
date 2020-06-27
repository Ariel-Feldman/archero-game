using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiInput : MonoBehaviour
{

    // Reference PlayerStateManager in the inspector
    public PlayerStateManager PlayerStateManager;
    float MovementSpeed;

    private void Update() 
    {
        // Incase Level is paused, fast out;
        if (GameManager.Instance.InPauseMode)
            return;
        // Switch between player state ( move | fire ) according to input change
        if (TimeToMove(MovementSpeed))
        {
            PlayerStateManager.SetState(PlayerState.MovingState);
            // Debug.Log("Moving State----------");
        }
        else
        {
            PlayerStateManager.SetState(PlayerState.ShotingState);
            // Debug.Log("||||||||||Shoting State");
        }
    }

    private bool TimeToMove(float movementSpeed)
    {
        // TODO - Movement For enemy here
        return false;
    }
}
