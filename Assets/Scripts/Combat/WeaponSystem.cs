using UnityEngine;

[RequireComponent(typeof(ITargetSystem))]
public class WeaponSystem : MonoBehaviour
{
    // Set WeaponSystem additional configuration here
    public float ShotFrequency;
    public float RotationSpeed;

    // Bind By Inspector
    public Transform BarrelPosition;
    public ITargetSystem TargetSystem;
    public BulletsPool BulletPool; 
    //
    private Transform _playerTransform; 
    private float nextTimeToShot;

    private void Awake() 
    {
        // Binds
        TargetSystem = GetComponent<ITargetSystem>();

        // The player is our parent
        _playerTransform = transform.parent.transform; 

        // We detach the bulletpool so it will not effect bullets positions  
        BulletPool.transform.parent = GameObject.Find("/BulletsPools").transform; 
        // HotFix - for some reason the bullet pool changing its transform
        BulletPool.transform.SetPositionAndRotation(Vector3.zero,Quaternion.identity);
    }

    // EngageCombat will be called in its parent ShotState class each update() when in state
    public void EngageCombat()
    {
        // Fast out if we not in game mode
        if(GameManager.Instance.InPauseMode)
            return;
        
        // Get Closeset Target Direction
        Vector3 targetPosition = TargetSystem.GetClosestTargetPosition();
        Vector3 targetDirection = (targetPosition - _playerTransform.position).normalized;

        // Check if we facing to enemy by dot product of the direction and my face 
        // If it is close to 1, the face eachother
        float dotProd = Vector3.Dot(targetDirection, _playerTransform.forward);

        // Check if its time to shoot
        if ((dotProd > 0.9999f) && (Time.time > nextTimeToShot))
        {   
            // Shot bullet in forward direction
            ShootBullet(targetDirection);
            // update By Fire Frequency
            nextTimeToShot = Time.time + ShotFrequency;
            return;
        }
         
        // If Not Facing closest enemy - Rotate towards it
        Vector3 newDirection = Vector3.RotateTowards(transform.forward, targetDirection, RotationSpeed * Time.deltaTime, 0.1f);
        
        // Calculate a rotation a step closer to the target and applies rotation to this object
        _playerTransform.rotation = Quaternion.LookRotation(newDirection);
    }

    private void ShootBullet(Vector3 direction)
    {
        // Get bullet from the pool
        GameObject bullet = BulletPool.GetFromPool();
        // Reset its position according to the barrel position
        bullet.transform.SetPositionAndRotation(BarrelPosition.position, Quaternion.identity);
        // This to help debug the wired bug in bullet movement
        Debug.DrawRay(bullet.transform.position, direction, Color.cyan, 0.1f);
        // Fire Bullet
        bullet.GetComponentInChildren<BulletController>().Fire(direction);
    }
}
