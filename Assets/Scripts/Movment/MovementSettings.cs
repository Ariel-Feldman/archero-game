using UnityEngine;

[CreateAssetMenu(menuName = "ArchHeroSettings/New Movenment", fileName = "NewMovementSettings")]
public class MovementSettings : ScriptableObject
{
    [SerializeField] private float _turnSpeed = 10f;
    [SerializeField] private float _moveSpeed = 10f;
    
    public float TurnSpeed { get {return _turnSpeed; }}
    public float MoveSpeed { get {return _moveSpeed;}}
}
