using UnityEngine;

public class MovmentSystem : MonoBehaviour
{
    public MovementSettings MovementSettings; 
    //
    private IMovementInput _movmentInput;
    //
    private CharacterController _controller;
    //
    private float _horizontal;
    private float _vertical;
    private Vector3 _direction;

    private Transform _playerParent;

    // For smootheDump
    private float turnSmoothVelocity;

    private void Awake() 
    {
        // Bindings
        _controller = GetComponentInParent<CharacterController>();

        // Just add what Input Component we chhose ( KeyBoard / Joystic...)
        _movmentInput = GetComponent<IMovementInput>();

        _playerParent = transform.parent;
        
    }

    private void Update() 
    {
        _horizontal = _movmentInput.Horizontal;
        _vertical = _movmentInput.Vertical;
        _direction = new Vector3(_horizontal, 0f, _vertical).normalized;

        // check if we have real input, use sqrMagnitude for better perforence
        if (_direction.sqrMagnitude > 0.01f)
        {
            float targetAnlge = Mathf.Atan2(_direction.x, _direction.z) * Mathf.Rad2Deg;
            
            float angle = Mathf.SmoothDampAngle(_playerParent.eulerAngles.y, targetAnlge, ref turnSmoothVelocity, 1 / MovementSettings.TurnSpeed);
            
            _playerParent.rotation = Quaternion.Euler(0f, angle, 0f);
            // _playerParent.rotation = Quaternion.Euler(0f, targetAnlge, 0f);

            _controller.Move(_direction * MovementSettings.MoveSpeed * Time.deltaTime);
        }
       
    }

}
