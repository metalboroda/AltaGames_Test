using Assets.__Game.Scripts.StateMachine;

namespace Assets.__Game.Scripts.Controller.GameStates
{
  public class GameInitState : State
  {
    public GameInitState(GameController gameController)
    {
      _gameController = gameController;
    }

    private GameController _gameController;
  }
}