using UnityEngine;

public class ShotState : MonoBehaviour, IPlayerState
{
    private WeaponSystem _weaponSystem;

    private void Awake() 
    {
        _weaponSystem = transform.parent.GetComponentInChildren<WeaponSystem>();
    }
    public void Execute()
    {
        _weaponSystem.EngageCombat();
    }
}
