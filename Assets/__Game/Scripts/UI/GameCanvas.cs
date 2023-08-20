using Assets.__Game.Scripts.Character.Player;
using Assets.__Game.Scripts.Character.Player.States;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Assets.__Game.Scripts.UI
{
  public class GameCanvas : CanvasRoot
  {
    [field: SerializeField] public Button LetsGoButton { get; private set; }

    [Inject] private PlayerController _playerController;

    private void Awake()
    {
      LetsGoButton.onClick.AddListener(LetsGoButtonLogic);
    }

    private void OnDestroy()
    {
      LetsGoButton.onClick?.RemoveListener(LetsGoButtonLogic);
    }

    private void LetsGoButtonLogic()
    {
      _playerController.StateMachineController.ChangeState(new PlayerMovementState(_playerController));

      LetsGoButton.gameObject.SetActive(false);
    }
  }
}