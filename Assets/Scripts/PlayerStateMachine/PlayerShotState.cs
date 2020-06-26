using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShotState : MonoBehaviour, IPlayerState
{
    public void Execute()
    {
        throw new System.NotImplementedException();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Execute(); // ???????? YES!
        
    }
}
