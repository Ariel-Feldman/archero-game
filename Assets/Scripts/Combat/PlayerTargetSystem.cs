using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlayerTargetSystem : MonoBehaviour, ITargetSystem
{
    public Transform _levelEnemies;
    private List<Transform> _enemies;

    private void Awake() 
    {
        // Unity do not support constructors
        _enemies = new List<Transform>(); 
        //
        foreach (Transform child in _levelEnemies)
        {
            _enemies.Add(child);
        }
    }

    private void Start() 
    {
        SortByRange();     
    }

    private void SortByRange()
    {
        // _enemies = _enemies.OrderBy(enemy => Vector2.Distance(this.transform.position, enemy.transform.position)).ToList();;
        _enemies.OrderBy(enemy => Vector2.Distance(this.transform.position, enemy.transform.position));
    }


    // Update is called once per frame
    void Update()
    {
        SortByRange();
    }

    public Vector3 GetTargetPosition()
    {
        if (_enemies.Count > 0)
            return _enemies[0].position;
        else
        {
            Debug.Log("No Enemy found");
            // Return Vector3.negativeInfinity for now
            return Vector3.negativeInfinity;
        }
    }

}

