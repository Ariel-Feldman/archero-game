using UnityEngine;

public class ControlsInput : MonoBehaviour
{
    // A readonly values set by the input keys
    public float Horizontal {get; private set;}
    public float Vertical {get; private set;}
    
    // Ref Joystic here
    public Joystick Joystick;

    // We need the StateManager set by our input
    private StateManager PlayerStateManager;

    private void Awake() 
    {
        // Binds
        PlayerStateManager = GetComponentInChildren<StateManager>();     
    }

    private void Update() 
    {
        // Incase Level is paused, fast out;
        if (GameManager.Instance.InPauseMode)
            return;

        // We need fast state system that listen on movement input
        // Incase we stop we change our state to combat mode

// Listen to keyboard when playing in editor
#if UNITY_EDITOR
        Horizontal = Input.GetAxis("Horizontal");
        Vertical = Input.GetAxis("Vertical");
#endif
// Listen to joystick when playing in editor
#if !UNITY_EDITOR
        Horizontal = Joystick.Horizontal;
        Vertical = Joystick.Vertical;
#endif

        // Switch between player state ( move | combat ) according to input change
        if ((Horizontal != 0) || (Vertical != 0 ))
        {
            PlayerStateManager.SetState(PlayerState.MovingState);
        }
        else
        {
            PlayerStateManager.SetState(PlayerState.ShotingState);
        }
    }
}
