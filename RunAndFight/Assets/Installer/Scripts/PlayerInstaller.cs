using UnityEngine;
using Zenject;
using RunAndFight.Player;
namespace RunAndFight.Install
{
    public class PlayerInstaller : MonoInstaller
    {

        [SerializeField] private Movement _player;
        [SerializeField] private Transform _playerSpawnPoint;
        public override void InstallBindings()
        {
            var playerInstance = Container.InstantiatePrefabForComponent<Movement>(_player,_playerSpawnPoint.position,Quaternion.identity,null);

            Container.Bind<Movement>().FromInstance(playerInstance).AsSingle().NonLazy();
        }


    }
}