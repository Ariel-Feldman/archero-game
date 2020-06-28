using UnityEngine;

public class NPCMovementSystem : MonoBehaviour, IMovementSystem
{
    // MovementSettings is a scriptable objects,
    // Use it to create lots of different Speed Movements for NPC
    public MovementSettings MovementSettings; 
    //
    private Transform _player;
    private Vector3 _direction;
    private float _speed;

    private void Awake() 
    {
        _player = GameObject.FindWithTag("Player").transform;
    }

    private void Start() 
    {
        _speed = MovementSettings.MoveSpeed;
    }

    // This is super simple movement by direction
    // MovePlayer will be called in its parent ShotState class each update() when in state
    public void MovePlayer() 
    {
        _direction = (_player.position - transform.parent.position).normalized;
        transform.parent.position += (_direction * _speed * Time.deltaTime); 
    }

}
