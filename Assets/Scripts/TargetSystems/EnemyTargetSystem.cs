using UnityEngine;

public class EnemyTargetSystem : MonoBehaviour, ITargetSystem
{
    private Transform Player;

    public Vector3 GetClosestTargetPosition()
    {
        // lazy Init
        if (Player == null)
        {
            InitTargetSystem();
        }
        return Player.position;
    }

    public void InitTargetSystem()
    {
        Player = GameObject.FindGameObjectWithTag("Player").transform;
    }
}
