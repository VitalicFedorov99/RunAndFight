using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RunAndFight.ObjectPools;

namespace RunAndFight.Location
{
    public class GenerationLocation : MonoBehaviour
    {


        [SerializeField] private ObjectPools.ObjectPool _objectPool;
        [SerializeField] private GameObject _testObject;
        [SerializeField] private float distanceX;
        [SerializeField] private float distanceZ;
        [SerializeField] private Transform _startPoint; 

        private Vector3 _currentPosition;
        private GameObject _currentObject;
        private FullBlock _currentFullBlock;
        private GenerationDirection _generdirection;

        private void Start()
        {
            _generdirection = GetComponent<GenerationDirection>();
            _objectPool.Setup();
            _generdirection.CreateListDirection();
            //_generdirection.CreateForwardRoute();
            Create(_generdirection.ListDirections);
        }

        public void Create(List<Direction> directions) 
        {
            Direction currentdirection;
            _currentPosition = _startPoint.position;
            for(int i = 0; i < directions.Count; i++) 
            {
                currentdirection = directions[i];
                _currentObject = _objectPool.GetPooledObject(TypeObject.FullBlock);
                _currentFullBlock = _currentObject.GetComponent<FullBlock>();
                _currentFullBlock.Setup();
                switch (currentdirection)
                {
                    
                    case Direction.Forward:
                        {
                            _currentPosition.z += distanceZ;
                            _currentFullBlock.VerticalRoute();
                            break;
                        }
                    case Direction.Left:
                        {
                            _currentPosition.x += distanceX;
                            _currentFullBlock.HorizontalRoute();
                            break;
                        }
                    case Direction.Right:
                        {
                            _currentPosition.x -= distanceX;
                            _currentFullBlock.HorizontalRoute();
                            break;
                        }
                    case Direction.Forward_Left: 
                        {
                            _currentPosition.z += distanceZ;
                            _currentFullBlock.LeftTurn();
                            break;
                        }
                    case Direction.Forward_Right:
                        {
                            _currentPosition.z += distanceZ;
                            _currentFullBlock.RightTurn();
                            break;
                        }
                    case Direction.Left_Forward: 
                        {
                            _currentPosition.x += distanceX;
                            _currentFullBlock.VerticalTurnLeft();
                            break;
                        }
                    case Direction.Right_Forward:
                        {
                            _currentPosition.x -= distanceX;
                            _currentFullBlock.VerticalTurnRight();
                            break;
                        }
                }
                _currentObject.transform.position = _currentPosition;
                

            }
        }

       
        public void CreateFullBlock()
        {
            _currentObject = _objectPool.GetPooledObject(TypeObject.FullBlock);
            _currentFullBlock = _currentObject.GetComponent<FullBlock>();
        }




    }
}