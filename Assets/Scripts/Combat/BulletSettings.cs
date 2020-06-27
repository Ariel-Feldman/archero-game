using UnityEngine;

[CreateAssetMenu(menuName = "ArchHeroSettings/New Bullet", fileName = "NewBulletSettings")]
public class BulletSettings : ScriptableObject
{
    public float Damage = 10f;
    public float Force = 10f;

    public bool JumpOrbital;

    [SerializeField] private Texture BulletImage;
    [SerializeField] private AudioClip BulletSound;
    
}
