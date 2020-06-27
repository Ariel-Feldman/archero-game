using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPController : MonoBehaviour
{
    private BulletsPool _bulletPool; 
    private void Awake() 
    {
        _bulletPool = GetComponentInChildren<BulletsPool>();
    }

    public void killMe()
    {
        if (_bulletPool.gameObject)
            Destroy(_bulletPool.gameObject);
        this.gameObject.SetActive(false);
    }

}
