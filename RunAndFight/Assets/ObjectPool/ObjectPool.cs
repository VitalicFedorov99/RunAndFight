using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RunAndFight.ObjectPools
{
    public class ObjectPool : MonoBehaviour
    {
        public Queue<GameObject> FullBlocks;
        public Queue<GameObject> Stairs;
        public int CountIncreasePool;



        [SerializeField] private GameObject _prefabFullBlock;
        [SerializeField] private GameObject _prefabStairs;

        private GameObject currentGameobject;
        private ObjectInPool currentPrefab;
        private Queue<GameObject> currentQueue;
        


        private ObjectInPool objectInPoolFullBlock;
        private ObjectInPool objectInPoolStair;


        public void Setup()
        {
            FullBlocks = new Queue<GameObject>();
            Stairs = new Queue<GameObject>();
            objectInPoolFullBlock = _prefabFullBlock.GetComponent<ObjectInPool>();
            objectInPoolStair = _prefabStairs.GetComponent<ObjectInPool>();
            IncreasePool(FullBlocks, CountIncreasePool, objectInPoolFullBlock);
            IncreasePool(Stairs, CountIncreasePool, objectInPoolStair);
        }


        public GameObject GetPooledObject(TypeObject type)
        {
            if (type == TypeObject.FullBlock)
            {
                currentGameobject = SearchObjectInQueue(FullBlocks, type);
            }
            if(type == TypeObject.Stair) 
            {
                currentGameobject = SearchObjectInQueue(Stairs, type);
            }

            return currentGameobject;
        }

       

        public void SetPooledObject(ObjectInPool obj)
        {
            currentQueue = SearchQueue(obj.GetTypeObject());
            currentQueue.Enqueue(obj.gameObject);

        }

        public GameObject SearchObjectInQueue(Queue<GameObject> queue, TypeObject type)
        {
            if (queue.Count == 0)
            {
                IncreasePool(queue, CountIncreasePool, SearchPrefab(type));
            }
            return queue.Dequeue();
        }

        public void IncreasePool(Queue<GameObject> queue, int count, ObjectInPool objectInPool)
        {
            for (int i = 0; i < count; i++)
            {
                currentGameobject = Instantiate(objectInPool.gameObject, gameObject.transform);
                queue.Enqueue(currentGameobject);
            }
        }

        private ObjectInPool SearchPrefab(TypeObject type)
        {
            if (type == TypeObject.FullBlock)
            {
                currentPrefab = objectInPoolFullBlock;
            }
            if (type == TypeObject.Stair)
            {
                currentPrefab = objectInPoolStair;
            }
            return currentPrefab;
        }

        private Queue<GameObject> SearchQueue(TypeObject type)
        {
            if (type == TypeObject.FullBlock)
            {
                currentQueue = FullBlocks;
            }
            if (type == TypeObject.Stair)
            {
                currentQueue = Stairs;
            }
            return currentQueue;
        }

        
    }
}