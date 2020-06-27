using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : Singleton<GameManager>
{

    [HideInInspector]
    public bool InPauseMode;
    //
    public PlayerTargetSystem PlayerTargetSystem;
    public HealthSystem PlayerHealthSystem;
    public Transform PlayerStartPosition;
    public Transform LevelParent;
    public List<GameObject> LevelPrefabs;
    public CanvasManager canvasManager;
    //
    private int _currentLevelNumber;
    private GameObject _currentLevelGO;
    private GameObject _player;


    private void Awake() 
    {
        InPauseMode = true;
        _player = GameObject.FindWithTag("Player");
    }

    public void StartLevel(int levelNumber) 
    {
        // Validate Game Is In Pause - just double safety
        InPauseMode = true;
        // Destroy Old Loaded Levels, if any
        foreach(Transform child in LevelParent)
        {
            // TODo change it from DestroyImmediate - hot Fix
            DestroyImmediate(child.gameObject);
        }
        _currentLevelGO = Instantiate(LevelPrefabs[levelNumber], LevelParent);
        // Init player Target System
        PlayerTargetSystem.InitTargetSystem();
        // Init player health System
        PlayerHealthSystem.RestartHealtSystem();
        // Reset Player Position
        _player.transform.position = PlayerStartPosition.position;
        //
        _currentLevelNumber = levelNumber;
        InPauseMode = false;
    }

    public void EndLevel(int LevelNumber) 
    {
        InPauseMode = true;
        // Level End FX
        canvasManager.LevelEndFlow();
    }

    public void EntityDie(GameObject entityDie)
    {
        if (entityDie.tag == "Player")
        {
            Debug.Log("Player Died");
            StartGameEndSequence();
        }

        if (entityDie.tag == "Enemy")
        {
            entityDie.GetComponentInChildren<NPController>().killMe();
            // Check if any enemy left
            if (GameObject.FindGameObjectsWithTag("Enemy").Length <=0)
            {
                Debug.Log("Level Over");
                EndLevel(_currentLevelNumber);    
            }
        }
    }
    private void StartGameEndSequence()
    {
        InPauseMode = true;
        canvasManager.GameOverFlow();
    }

}
