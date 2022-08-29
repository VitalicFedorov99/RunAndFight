using UnityEngine;
using Zenject;
using RunAndFight.ObjectPools;
namespace RunAndFight.Install
{
    public class LocationInstaller : MonoInstaller
    {
        [SerializeField] private ObjectInPool _objectPool; 
        public override void InstallBindings()
        {
            
        }
    }
}