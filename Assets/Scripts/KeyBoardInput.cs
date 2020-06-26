using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyBoardInput : MonoBehaviour, IMovementInput
{
    // Fastetst Input impact for this type of game I can think of
    public float NewHorizontal {get; private set;}
    public float NewVertical {get; private set;}

    
    public float OldHorizontal {get; private set;}
    public float OldeVertical {get; private set;}


    private void Update() 
    {
        NewHorizontal = Input.GetAxis("Horizontal");
        NewVertical = Input.GetAxis("Vertical");

        // Switch between player state ( move | fire ) according to input change
        if ((OldHorizontal != NewHorizontal || OldHorizontal == default) 
        && (OldeVertical != NewVertical || OldeVertical == default))
        {
            PlayerStateManager.Instance.SetState(PlayerState.MovingState);
        }
        else
        {
            PlayerStateManager.Instance.SetState(PlayerState.ShotingState);
        }

    }
}
