using Assets.__Game.Scripts.StateMachine;

namespace Assets.__Game.Scripts.Character.Player.States
{
  public class PlayerCombatState : State
  {
    public PlayerCombatState(PlayerController playerController)
    {
      _playerController = playerController;
    }

    private readonly PlayerController _playerController;
    private PlayerShoot _playerAim;

    public override void Enter()
    {
      Init();
    }

    public override void Update()
    {
      _playerAim.Touch();
    }

    private void Init()
    {
      _playerAim = _playerController.PlayerShoot;
    }
  }
}