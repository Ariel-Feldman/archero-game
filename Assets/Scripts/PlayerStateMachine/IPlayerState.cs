using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public interface IPlayerState 
{
    void Execute();
    
}

public enum PlayerState
{
    MovingState,
    ShotingState

    // We will probably going to need some freeze state
    // FreezeSatet
}    
