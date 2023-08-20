using Assets.__Game.Scripts.StateMachine;

namespace Assets.__Game.Scripts.Character.Player.States
{
  public class PlayerDeathState : State
  {
    public PlayerDeathState(PlayerController playerController)
    {
      _playerController = playerController;
    }

    private PlayerController _playerController;
  }
}