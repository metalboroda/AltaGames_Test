using Assets.__Game.Scripts.Controller;
using UnityEngine;
using Zenject;

namespace Assets.__Game.Scripts.Installer
{
  public class ControllerInstaller : MonoInstaller
  {
    [SerializeField] private GameController gameController;
    [SerializeField] private UIController uIController;
    [SerializeField] private InputController inputController;
    [SerializeField] private CameraController cameraController;
    [SerializeField] private SceneController sceneController;

    public override void InstallBindings()
    {
      Container.Bind<GameController>().FromInstance(gameController).AsSingle().NonLazy();
      Container.Bind<UIController>().FromInstance(uIController).AsSingle();
      Container.Bind<InputController>().FromInstance(inputController).AsSingle();
      Container.Bind<CameraController>().FromInstance(cameraController).AsSingle();
      Container.Bind<SceneController>().FromInstance(sceneController).AsSingle();
    }
  }
}