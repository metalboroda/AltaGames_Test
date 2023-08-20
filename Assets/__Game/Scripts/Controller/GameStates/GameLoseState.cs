using Assets.__Game.Scripts.StateMachine;

namespace Assets.__Game.Scripts.Controller.GameStates
{
  public class GameLoseState : State
  {
    public GameLoseState(GameController gameController)
    {
      _gameController = gameController;
    }

    private GameController _gameController;
  }
}