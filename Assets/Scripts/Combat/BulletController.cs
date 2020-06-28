using UnityEngine;

public class BulletController : MonoBehaviour
{
    // BulletSettings is scriptable object
    public BulletSettings BulletSettings;

    //
    [HideInInspector]
    public float Damage;
    //
    private float _force;
    private Rigidbody _rb;
    private BulletsPool _bulletspool;
    private bool _isBulletInPool; // HotFix

    private void Awake() 
    {
        // Binds from 
        _rb = GetComponent<Rigidbody>();
        _bulletspool = GetComponentInParent<BulletsPool>();
        //
        Damage = BulletSettings.Damage;
        _force = BulletSettings.Force;
        //
        _isBulletInPool = true; 
    }

    public void Fire(Vector3 direction)
    {
        // Bullet left the pool
        _isBulletInPool = false;
        // Normalize direction;
        direction = direction.normalized;
        // Reset its velocity
        _rb.velocity = Vector3.zero;
        // Fire by impulse
        _rb.AddForce(direction * _force, ForceMode.Impulse);

        // if its bouncing bullet add force from below
        if(BulletSettings.JumpOrbital)
        {
            _rb.AddForce(Vector3.up * _force, ForceMode.Impulse);            
        }
        // Self distract after 5 second (if trigger didn't enter anyting)
        Invoke("SelfDestruct", 5);
    }

    private void OnTriggerEnter(Collider other) 
    {
        // If we encounter bullet keep going
        if(other.tag == "Bullet")
            return;
        // Make Explostion Effect Here
        //
        // Return To pool
        _bulletspool.AddToPool(gameObject);
        _isBulletInPool = true;    
    }
    
    private void SelfDestruct()
    {
        if (!_isBulletInPool)
        {
            _bulletspool.AddToPool(gameObject);
            _isBulletInPool = true; 
        }
    }
    
    void OnDrawGizmosSelected()
    {
        // Draws a 5 unit long red line in front of the object
        Gizmos.color = Color.red;
        Vector3 direction = transform.TransformDirection(Vector3.forward) * 5;
        Gizmos.DrawRay(transform.position, direction);
    }
}
