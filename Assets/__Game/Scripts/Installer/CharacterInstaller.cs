using Assets.__Game.Scripts.Character.Player;
using UnityEngine;
using Zenject;

namespace Assets.__Game.Scripts.Installer
{
  public class CharacterInstaller : MonoInstaller
  {
    [SerializeField] private PlayerController playerController;

    public override void InstallBindings()
    {
      Container.Bind<PlayerController>().FromInstance(playerController).AsSingle().NonLazy();
    }
  }
}