using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
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

    // We share this semaphore Ionorder to stop update loops when not in play mode (old trick:)
    // No need to show in inspector
    [HideInInspector]
    public bool InPauseMode;

    private void Awake() 
    {
        // Binds
        _player = GameObject.FindWithTag("Player");
    }
    
    private void Start() 
    {  
        InPauseMode = true;
    }

    public void StartLevel(int levelNumber) 
    {
        // Validate Game Is In Pause - just double safety
        InPauseMode = true;
        // Destroy Old Loaded Levels, if any
        foreach(Transform child in LevelParent)
        {
            // HOTFIX
            // TODO change it from DestroyImmediate - 
            DestroyImmediate(child.gameObject);
        }
        _currentLevelGO = Instantiate(LevelPrefabs[levelNumber], LevelParent);
        // Init player Target System
        PlayerTargetSystem.InitTargetSystem();
        // Init player health System
        PlayerHealthSystem.RestartHealtSystem();
        // Reset Player Position
        _player.transform.position = PlayerStartPosition.position;
        _currentLevelNumber = levelNumber;
        // Release the kraken!!
        InPauseMode = false;
    }

    public void EndLevel(int LevelNumber) 
    {
        InPauseMode = true;
        // TODO Level end FX here
        canvasManager.LevelEndFlow();
    }

    // TODO - this should be an event system
    // All the Health systems in game is calling Gamemanager.EntityDie
    public void EntityDie(GameObject entityDie)
    {   
        // If it was player - game over
        if (entityDie.tag == "Player")
        {
            StartGameEndSequence();
        }

        if (entityDie.tag == "Enemy")
        {
            entityDie.GetComponentInChildren<NPCController>().killMe();
            // Check if any enemy left-> level complete
            if (GameObject.FindGameObjectsWithTag("Enemy").Length <=0)
            {
                EndLevel(_currentLevelNumber);    
            }

            // HOTFIX
            PlayerTargetSystem.InitTargetSystem();
        }
    }
    private void StartGameEndSequence()
    {
        InPauseMode = true;
        canvasManager.GameOverFlow();
    }

}
