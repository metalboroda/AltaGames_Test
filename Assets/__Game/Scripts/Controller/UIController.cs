using Assets.__Game.Scripts.Character.Player;
using Assets.__Game.Scripts.Character.Player.States;
using Assets.__Game.Scripts.Controller.GameStates;
using Assets.__Game.Scripts.StateMachine;
using Assets.__Game.Scripts.UI;
using UnityEngine;
using Zenject;

namespace Assets.__Game.Scripts.Controller
{
  public class UIController : MonoBehaviour
  {
    [SerializeField] private GameCanvas gameCanvas;
    [SerializeField] private VictoryCanvas victoryCanvas;
    [SerializeField] private LoseCanvas loseCanvas;
    [SerializeField] private GameObject inputCanvas;

    private CanvasRoot[] _canvasArray;

    [Inject] private GameController _gameController;
    [Inject] private PlayerController _playerController;

    private void Awake()
    {
      _canvasArray = new CanvasRoot[] { gameCanvas, victoryCanvas, loseCanvas };
    }

    private void Start()
    {
      _gameController.StateMachineController.OnStateUpdated += SwitchCanvasOnState;
      _playerController.StateMachineController.OnStateUpdated += SwitchInputCanvas;
    }

    private void OnDestroy()
    {
      _gameController.StateMachineController.OnStateUpdated -= SwitchCanvasOnState;
      _playerController.StateMachineController.OnStateUpdated -= SwitchInputCanvas;
    }

    public void SwitchCanvasOnState(State state)
    {
      foreach (CanvasRoot canvas in _canvasArray)
      {
        canvas.gameObject.SetActive(false);
      }

      if (state is GameVictoryState)
      {
        victoryCanvas.gameObject.SetActive(true);
      }
      else if (state is GameLoseState)
      {
        loseCanvas.gameObject.SetActive(true);
      }
      else if (state is GamePlayState)
      {
        gameCanvas.gameObject.SetActive(true);
      }
    }

    private void SwitchInputCanvas(State state)
    {
      if (state is PlayerMovementState)
        inputCanvas.SetActive(true);
      else
      {
        if (inputCanvas.activeSelf)
          inputCanvas.SetActive(false);
      }
    }
  }
}