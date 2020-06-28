using UnityEngine;

public class NPCController : MonoBehaviour
{

    [Range(0.2f, 2.5f)]
    public float stopDistance = 0.5f;
    public MovementSettings EnemyMovement;
    //
    private WeaponSystem _weaponSystem;
    private float _currentSpeed;
    private Rigidbody _rb;
    private Transform _player;
    private float _distanceFromPlayer;
    private BulletsPool _bulletPool; 
    private void Awake() 
    {
        _rb = GetComponent<Rigidbody>();
        _bulletPool = GetComponentInChildren<BulletsPool>();
        _weaponSystem = GetComponentInChildren<WeaponSystem>();
        _player = GameObject.FindWithTag("Player").transform;
    }

    private void Update() 
    {
        _distanceFromPlayer = Vector3.Distance(_player.position, transform.position);
        if (_distanceFromPlayer < stopDistance)
            //stop movement
            _currentSpeed = 0;
        else
            _currentSpeed = EnemyMovement.MoveSpeed;  

        _weaponSystem.EngageCombat(); 
    }

    private void FixedUpdate()
    {
        Vector3 desiredPostion = transform.position + (transform.forward * _currentSpeed * Time.deltaTime);
        _rb.MovePosition(desiredPostion);
    }

    public void killMe()
    {
        if (_bulletPool.gameObject)
            Destroy(_bulletPool.gameObject);
        this.gameObject.SetActive(false);
    }

    void OnDrawGizmosSelected()
    {
        // Draw a yellow sphere at the transform's position
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, stopDistance);
    }

}
