using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesTargetSystem : MonoBehaviour, ITargetSystem
{
    public Transform Player;

    public Vector3 GetTargetPosition()
    {
        return Player.position;
    }
}
