using UnityEngine;

public class GameManager : Singleton<GameManager>
{

    public LevelManager levelManager;
    public PlayerTargetSystem PlayerTargetSystem;
    public Transform PlayerStartPosition;
    public bool InPauseMode;

    private GameObject player;
    private void Awake() 
    {
        InPauseMode = true;
        player = GameObject.FindWithTag("Player");
    }

    public void StartLevel(int LevelNumber) 
    {
        // Validate Game Is In Pause - just double safety
        InPauseMode = true;
        // Load Level
        levelManager.Startlevel(LevelNumber);
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
