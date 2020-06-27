using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlayerTargetSystem : MonoBehaviour, ITargetSystem
{
    private Transform _levelEnemies;
    private List<Transform> _enemies = new List<Transform>();

    public void InitTargetSystem() 
    {  
        // Bindings
        _levelEnemies = GameObject.FindGameObjectWithTag("Enemies").transform;
        // Clear Enemies List
        _enemies.Clear();
        // Load Enemies list
        foreach (Transform child in _levelEnemies)
        {
            _enemies.Add(child);
        }
    }

    private void SortByRange()
    {
        _enemies = _enemies.OrderBy(enemy => Vector3.Distance(transform.parent.transform.position, enemy.transform.position)).ToList();
    }

    public Vector3 GetClosestTargetPosition()
    {
        if (_enemies.Count > 0)
        {
            SortByRange();
            return _enemies[0].position;
        }
        else
        {
            Debug.Log("No Enemy found");
            // Return Vector3.negativeInfinity for now
            return Vector3.negativeInfinity;
        }
    }

}

