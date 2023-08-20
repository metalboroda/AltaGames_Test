using Assets.__Game.Scripts.Character.Player;
using Assets.__Game.Scripts.Controller;
using Assets.__Game.Scripts.Controller.GameStates;
using UnityEngine;
using Zenject;

namespace Assets.__Game.Scripts.Item
{
  public class Finish : MonoBehaviour
  {
    [Inject] private GameController _gameController;

    private void OnTriggerEnter(Collider other)
    {
      if (other.GetComponent<PlayerCollider>())
      {
        _gameController.StateMachineController.ChangeState(new GameVictoryState(_gameController));
      }
    }
  }
}