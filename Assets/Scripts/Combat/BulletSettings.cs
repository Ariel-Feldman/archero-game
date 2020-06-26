using UnityEngine;

[CreateAssetMenu(menuName = "BulletSettings/Settings", fileName = "NewBulletSettings")]
public class BulletSettings : ScriptableObject
{
    [SerializeField] private float Damage = 10f;
    [SerializeField] private float Speed = 10f;
    [SerializeField] private float Distance = 10f;

    [SerializeField] private bool JumpOrbitat;

    
}
