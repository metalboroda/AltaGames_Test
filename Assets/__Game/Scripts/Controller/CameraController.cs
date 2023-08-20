using Assets.__Game.Scripts.Character.Player;
using Assets.__Game.Scripts.Character.Player.States;
using Assets.__Game.Scripts.StateMachine;
using Cinemachine;
using UnityEngine;
using Zenject;

namespace Assets.__Game.Scripts.Controller
{
  public class CameraController : MonoBehaviour
  {
    [SerializeField] private CinemachineVirtualCamera playerCombatCamera;
    [SerializeField] private CinemachineVirtualCamera playerMovementCamera;

    private CinemachineVirtualCamera[] _cameras;

    [Inject] private readonly PlayerController _playerController;

    private void Awake()
    {
      _cameras = new CinemachineVirtualCamera[] { playerCombatCamera, playerMovementCamera };
    }

    private void Start()
    {
      SetupCameras();

      _playerController.StateMachineController.OnStateUpdated += SwitchCanvasOnState;
    }

    private void OnDestroy()
    {
      _playerController.StateMachineController.OnStateUpdated -= SwitchCanvasOnState;
    }

    private void SetupCameras()
    {
      foreach (var camera in _cameras)
      {
        camera.Follow = _playerController.transform;
        camera.LookAt = _playerController.transform;
      }
    }

    public void SwitchCanvasOnState(State state)
    {
      foreach (CinemachineVirtualCamera camera in _cameras)
      {
        camera.gameObject.SetActive(false);
      }

      if (state is PlayerCombatState)
      {
        playerCombatCamera.gameObject.SetActive(true);
      }
      else if (state is PlayerMovementState)
      {
        playerMovementCamera.gameObject.SetActive(true);
      }
    }
  }
}