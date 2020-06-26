using System;
using System.Collections.Generic;
using UnityEngine;

public class TargetSystem : Singleton<TargetSystem>
{
    private ITargetSystem _system;

    private PlayerTargetSystem _playerTargetSystem;
    private EnemiesTargetSystem _enemyTargetSystem;

    private void Awake() 
    {
        _playerTargetSystem = FindObjectOfType<PlayerTargetSystem>();
        if (_playerTargetSystem)
            Debug.Log("Cannot Find player Target system"); 

        _enemyTargetSystem = FindObjectOfType<EnemiesTargetSystem>();
        if (_enemyTargetSystem)
            Debug.Log("Cannot Find player Target system"); 
    }

}
