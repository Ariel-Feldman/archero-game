using UnityEngine;

public class PlayerShotState : MonoBehaviour, IPlayerState
{
    public WeaponSystem _weaponSystem;
    public void Execute()
    {
        _weaponSystem.EngageCombat();
    }
}
