using UnityEngine;

public class KeyBoardInput : MonoBehaviour, IMovementInput
{

    // Reference PlayerStateManager in the inspector
    public PlayerStateManager PlayerStateManager;
    // Fastest Input impact for this type of game I can think of
    public float NewHorizontal {get; private set;}
    public float NewVertical {get; private set;}

    
    public float OldHorizontal {get; private set;}
    public float OldeVertical {get; private set;}

    private void Update() 
    {
        // Incase Level is paused, fast out;
        if (GameManager.Instance.InPauseMode)
            return;
        NewHorizontal = Input.GetAxis("Horizontal");
        NewVertical = Input.GetAxis("Vertical");

        // Switch between player state ( move | fire ) according to input change
        if ((OldHorizontal != NewHorizontal) || (OldeVertical != NewVertical))
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
}
