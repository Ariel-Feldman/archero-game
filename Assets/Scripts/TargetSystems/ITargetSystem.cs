using System.Collections.Generic;
using UnityEngine;

public interface ITargetSystem
{
    void InitTargetSystem();
    Vector3 GetClosestTargetPosition();
}