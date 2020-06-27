using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{

    [HideInInspector]
    public bool InPauseMode;
    //
    public PlayerTargetSystem PlayerTargetSystem;
    public Transform PlayerStartPosition;
    public Transform LevelParent;
    //
    public List<GameObject> LevelPrefabs;
    //
    private int _currentLevel;
    private int _nextLevel;
    private GameObject _currentLevelGO;
    private GameObject _nextLevelGO;
    //
    private GameObject player;

    //
    private void Awake() 
    {
        InPauseMode = true;
        player = GameObject.FindWithTag("Player");
    }

    public void StartLevel(int levelNumber) 
    {
        // Validate Game Is In Pause - just double safety
        InPauseMode = true;
        // Destroy Old Loaded Levels, if any
        foreach(Transform child in LevelParent)
        {
            Destroy (child.gameObject);
        }

        _currentLevelGO = Instantiate(LevelPrefabs[levelNumber -1], LevelParent);
        // InitTargetSystems
        PlayerTargetSystem.InitTargetSystem();

        player.transform.position = PlayerStartPosition.position;
        player.gameObject.SetActive(true); 
        InPauseMode = false;
    }

    public void EndLevel(int LevelNumber) 
    {
        InPauseMode = true;
        // Level End FX
        PlayerTargetSystem.InitTargetSystem();
        player.gameObject.SetActive(false);
    }

}
