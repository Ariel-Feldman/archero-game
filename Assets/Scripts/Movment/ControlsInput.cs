using UnityEngine;

public class ControlsInput : MonoBehaviour
{
    // A readonly values set by the input keys
    public float NewHorizontal {get; private set;}
    public float NewVertical {get; private set;}
    
    // We will alaways compare movement inputs 
    // To know which state we need to be
    private float _currentHorizontal;
    private float _currentVertical;
    //
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

        // We need fast super state system that listen on movement input
        // Incase we stop we change our state to combat mode

// Listen to keyboard when playing in editor
#if UNITY_EDITOR
        NewHorizontal = Input.GetAxis("Horizontal");
        NewVertical = Input.GetAxis("Vertical");
#endif
// Listen to joystick when playing in editor
#if !UNITY_EDITOR
        NewHorizontal = Joystick.Horizontal;
        NewVertical = Joystick.Vertical;
#endif

        // Switch between player state ( move | combat ) according to input change
        if ((_currentHorizontal != NewHorizontal) || (_currentVertical != NewVertical))
        {
            _currentHorizontal = NewHorizontal;
            _currentVertical = NewVertical;
            PlayerStateManager.SetState(PlayerState.MovingState);
        }
        else
        {
            PlayerStateManager.SetState(PlayerState.ShotingState);
        }
    }
}
