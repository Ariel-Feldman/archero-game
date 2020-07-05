using UnityEngine;

public class PlayerMovementSystem : MonoBehaviour, IMovementSystem
{
    // MovementSettings is a scriptable objects,
    // Use it to create lots of different Speed Movements for Players
    public MovementSettings MovementSettings; 
    //
    private CharacterController _controller;
    private ControlsInput _movementInput;
    private float _horizontal;
    private float _vertical;
    private Vector3 _direction;

    // For smootheDump
    private float turnSmoothVelocity;

    private void Awake() 
    {
        // Bindings
        _controller = GetComponentInParent<CharacterController>();

        // Just add what Input Component we choose ( KeyBoard / Joystic...)
        _movementInput = GetComponentInParent<ControlsInput>();
       
    }

    // MovePlayer will be called in its parent ShotState class each update() when in state
    public void MovePlayer() 
    {
        _horizontal = _movementInput.Horizontal;
        _vertical = _movementInput.Vertical;
        _direction = new Vector3(_horizontal, 0f, _vertical).normalized;

        // Check if we have real input, use sqrMagnitude for better performance
        if (_direction.sqrMagnitude > 0.02f)
        {
            // Smooth the movement and rotion by this cool calculus 
            float targetAngle = Mathf.Atan2(_direction.x, _direction.z) * Mathf.Rad2Deg;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, 1 / MovementSettings.TurnSpeed);
            
            // Rotate player to face the right direction
            transform.parent.rotation = Quaternion.Euler(0f, angle, 0f);
            // Move it in this direction
            _controller.Move(_direction * MovementSettings.MoveSpeed * Time.deltaTime);
        }
       
    }

}
