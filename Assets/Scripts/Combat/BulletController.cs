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
            _force = BulletSettings.Speed;
            _distance = BulletSettings.Distance;
            //
            _rb = GetComponent<Rigidbody>();
        }

        public void ShotByDirection(Vector3 targetDirection)
        {
            _rb.AddForce(this.transform.forward * _force);
        }

        // TODO - still in WIP --> but it can be very useful for curved bullets! 
        public void ShotByPosition(Vector3 targetPosition)
        {
            Vector3 targetDirection = (targetPosition - this.transform.position);
        }



}
