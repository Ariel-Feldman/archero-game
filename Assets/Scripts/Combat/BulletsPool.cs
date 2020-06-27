using System.Collections.Generic;
using UnityEngine;

public class BulletsPool : MonoBehaviour
{
        public GameObject PoolPrefab;
        public Transform PoolTransform;
        public int PoolSize;
        
        private Queue<GameObject> _poolQueue = new Queue<GameObject>();

        void Awake()
        {
            ConstructPool();
        }

        public void ConstructPool()
        {
            for (int i = 0; i < PoolSize; i ++)
            {
                GameObject instant = Instantiate(PoolPrefab, PoolTransform);
                instant.SetActive(false);
                _poolQueue.Enqueue(instant);
            }
        }

        public GameObject GetFromPool()
        {
            if (_poolQueue.Count == 0)
            {
                Debug.Log("Pool Is Empty, Adding More Objects");
                ConstructPool();
            }

            GameObject instant = _poolQueue.Dequeue();

            instant.SetActive(true);
            return instant;
        }

        public void AddToPool(GameObject instant)
        {
            instant.SetActive(false);
            _poolQueue.Enqueue(instant);
        }

        public void DeActivePool()
        {
            foreach (GameObject instant in _poolQueue)
            {
                instant.gameObject.SetActive(false);
            }
        }
}


