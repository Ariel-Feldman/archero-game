using UnityEngine;

public class BulletController : MonoBehaviour
{
    // Scriptable object here
    public BulletSettings BulletSettings;
    //
    [HideInInspector]
    public float Damage;
    //
    private float _force;
    private float _distance;
    private bool _isJumpy;
    private Rigidbody _rb;
    private BulletsPool _bulletspool;

    private void Awake() 
    {
        //
        Damage = BulletSettings.Damage;
        _force = BulletSettings.Force;
        //
        _rb = GetComponent<Rigidbody>();
        _bulletspool = GetComponentInParent<BulletsPool>();
    }

    public void Fire(Vector3 direction)
    {
        // Normalized direct;
        direction = direction.normalized;

        // _rb.AddForce(direction * _force);
        // _rb.AddForce(transform.forward * _force);

        _rb.AddForce(direction * _force, ForceMode.Impulse);
    }

    private void OnTriggerEnter(Collider other) 
    {
        // If we encounter bullet -> fast out
        if(other.tag == "Bullet")
            return;
        // Make Explostion Effect Here
        //
        // Return To pool
        _bulletspool.AddToPool(gameObject);    
    }
    
    void OnDrawGizmosSelected()
    {
        // Draws a 5 unit long red line in front of the object
        Gizmos.color = Color.red;
        Vector3 direction = transform.TransformDirection(Vector3.forward) * 5;
        Gizmos.DrawRay(transform.position, direction);
    }
}
