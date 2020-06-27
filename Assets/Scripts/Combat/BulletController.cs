using UnityEngine;

public class BulletController : MonoBehaviour
{

    //
    private float _damage;
    private float _force;
    private float _distance;
    private bool _isJumpy;
    private Rigidbody _rb;

    public BulletSettings BulletSettings;

        private void Awake() 
        {
            _damage = BulletSettings.Damage;
            _force = BulletSettings.Force;
            //
            _rb = GetComponent<Rigidbody>();
        }

        public void Fire(Vector3 direction)
        {
            // Normalized direct;
            direction = direction.normalized;
            _rb.AddForce(direction * _force);
        }
}
