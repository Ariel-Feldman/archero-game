using UnityEngine;

public class MovementSystem : MonoBehaviour
{
    public MovementSettings MovementSettings; 
    //
    private CharacterController _controller;
    private IMovementInput _movementInput;
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
        _movementInput = GetComponentInParent<IMovementInput>();
       
    }

    public void MovePlayer() 
    {
        _horizontal = _movementInput.NewHorizontal;
        _vertical = _movementInput.NewVertical;
        _direction = new Vector3(_horizontal, 0f, _vertical).normalized;

        // check if we have real input, use sqrMagnitude for better performance
        if (_direction.sqrMagnitude > 0.02f)
        {
            float targetAngle = Mathf.Atan2(_direction.x, _direction.z) * Mathf.Rad2Deg;
            
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, 1 / MovementSettings.TurnSpeed);
            
            transform.parent.rotation = Quaternion.Euler(0f, angle, 0f);

            _controller.Move(_direction * MovementSettings.MoveSpeed * Time.deltaTime);
        }
       
    }

}
