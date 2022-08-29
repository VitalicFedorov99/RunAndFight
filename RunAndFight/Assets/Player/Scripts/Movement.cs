using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RunAndFight.Player
{
    public class Movement : MonoBehaviour
    {
        [SerializeField] private float _speed;
        [SerializeField] private Vector3 _diraction;


        public void SetupDiraction(Vector3 dir) 
        {
            _diraction = dir;
        }
        private void Start()
        {
            SetupDiraction(Vector3.forward);
        }

        private void FixedUpdate()
        {
            transform.Translate(_diraction * _speed * Time.fixedDeltaTime);  
        }



    }
}
