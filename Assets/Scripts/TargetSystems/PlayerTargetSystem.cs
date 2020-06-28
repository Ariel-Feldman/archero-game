using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlayerTargetSystem : MonoBehaviour, ITargetSystem
{
    // we need this class to hold updated list on enemies 
    // Arranged by distance order
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
            if(child.gameObject.activeSelf)
                _enemies.Add(child);
        }
    }

    // This will be called from Weapon system
    public Vector3 GetClosestTargetPosition()
    {
        if (_enemies.Count > 0)
        {
            SortByRange();
            return _enemies[0].position;
        }
        else
        {
            // TODO - make better fail safe here
            Debug.Log("No Enemies found");
            return Vector3.negativeInfinity;
        }
    }

    private void SortByRange()
    {
        // Fastest by using LINQ
        _enemies = _enemies.OrderBy(enemy => Vector3.Distance(transform.parent.transform.position, enemy.transform.position)).ToList();
    }

}

