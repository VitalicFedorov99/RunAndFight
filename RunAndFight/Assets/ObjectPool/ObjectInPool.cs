using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RunAndFight.ObjectPools
{
    public class ObjectInPool : MonoBehaviour
    {
        [SerializeField] private TypeObject _typeObj;
        private ObjectPool _objectPool;
        public TypeObject GetTypeObject() 
        {
            return _typeObj;
        }

        public void SetObjectPool(ObjectPool objectPool) 
        {
            _objectPool = objectPool;
        }
    }
}