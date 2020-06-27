using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    
    public List<GameObject> LevelPrefabs;

    //
    private GameObject player;
    private int _currentLevel;
    private int _nextLevel;
    private GameObject _currentLevelGO;
    private GameObject _nextLevelGO;

    public void Startlevel(int levelNumber)
    {
        // Destroy Old Loaded Levels, if any
        foreach(Transform child in transform)
        {
            Destroy (child.gameObject);
        }
        
        // Resting player        
        // Instantiating new level
        // Do Some FX here
        // Updating Canvas
        _currentLevelGO = Instantiate(LevelPrefabs[levelNumber -1]);
        
    }

}
