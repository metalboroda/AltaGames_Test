using Assets.__Game.Scripts.StateMachine;
using UnityEngine;

namespace Assets.__Game.Scripts.Character.Player.States
{
  public class PlayerMovementState : State
  {
    public PlayerMovementState(PlayerController playerController)
    {
      _playerController = playerController;
    }

    private readonly PlayerController _playerController;
    private PlayerMovement _playerMovement;
    private PlayerShoot _playerShoot;

    public override void Enter()
    {
      Init();

      _playerMovement.transform.rotation = Quaternion.identity;
    }

    public override void Update()
    {
      _playerMovement.Movement();
      _playerShoot.MovementDeflate();
    }

    private void Init()
    {
      _playerMovement = _playerController.PlayerMovement;
      _playerShoot = _playerController.PlayerShoot;
    }
  }
}