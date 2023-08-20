using Assets.__Game.Scripts.Character.Player;
using Assets.__Game.Scripts.Character.Player.States;
using Assets.__Game.Scripts.Controller.GameStates;
using Assets.__Game.Scripts.StateMachine;
using UnityEngine;
using Zenject;

namespace Assets.__Game.Scripts.Controller
{
  public class GameController : MonoBehaviour
  {
    public StateMachineController StateMachineController { get; private set; }

    [Inject] private PlayerController _playerController;

    private void Awake()
    {
      StateMachineController = new();
      StateMachineController.Initialize(new GameInitState(this));
    }

    private void Start()
    {
      StateMachineController.ChangeState(new GamePlayState(this));

      _playerController.StateMachineController.OnStateUpdated += GameLose;
    }

    private void OnDestroy()
    {
      _playerController.StateMachineController.OnStateUpdated -= GameLose;
    }

    private void GameLose(State state)
    {
      if (state is PlayerDeathState)
        StateMachineController.ChangeState(new GameLoseState(this));
    }
  }
}