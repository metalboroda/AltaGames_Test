using Assets.__Game.Scripts.StateMachine;

namespace Assets.__Game.Scripts.Character.Player.States
{
  public class PlayerIdleState : State
  {
    public PlayerIdleState(PlayerController playerController)
    {
      _playerController = playerController;
    }

    private readonly PlayerController _playerController;
  }
}