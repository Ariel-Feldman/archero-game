using UnityEngine;

[RequireComponent(typeof(ITargetSystem))]
public class WeaponSystem : MonoBehaviour
{
    // bind By Inspector
    public float ShotFrequency;
    public float RotationSpeed;
    public Transform BarrelPosition;
    public ITargetSystem TargetSystem;
    public BulletsPool BulletPool; 
    //
    private Transform playertransform; 
    private float nextTimeToShot;

    private void Awake() 
    {
        TargetSystem = GetComponent<ITargetSystem>();
        playertransform = transform.parent.transform;
    }

    public void EngageCombat()
    {
        Vector3 targetPosition = TargetSystem.GetClosestTargetPosition();
        Vector3 targetDirection = (targetPosition - playertransform.position).normalized;

        // Check if we facing to enemy - if yes, start to shoot
        float dotProd = Vector3.Dot(targetDirection, playertransform.forward); 
        // When Facing game objecu the dor product of their direction is close to 1;
        if (dotProd > 0.9999f) 
        {
            // Shot bullet in local forward direction
            ShootBullet(transform.TransformDirection(Vector3.forward));
            return;
        }
         
        // The step size is equal to speed times frame time.
        float singleStep = RotationSpeed * Time.deltaTime;

        // Rotate the forward vector towards the target direction by one step
        Vector3 newDirection = Vector3.RotateTowards(transform.forward, targetDirection, singleStep, 0.1f);
        
        // Calculate a rotation a step closer to the target and applies rotation to this object
        playertransform.rotation = Quaternion.LookRotation(newDirection);
        // Rotate To first enemy and the shot
    }

    public void ShootBullet (Vector3 direction)
    {
        // Check if we in fire rate conditions
        if (Time.time > nextTimeToShot)
        {
            nextTimeToShot = Time.time + ShotFrequency;
            // Get bullet from the pool
            GameObject bullet = BulletPool.GetFromPool();
            // Put it in its start position
            // bullet.transform.position = BarrelPosition.position;
            bullet.transform.SetPositionAndRotation(BarrelPosition.position,BarrelPosition.rotation);
            // Fire Bullet
            bullet.GetComponentInChildren<BulletController>().Fire(direction);
        }
    }
}
