using Assets.__Game.Scripts.StateMachine;

namespace Assets.__Game.Scripts.Controller.GameStates
{
  public class GameVictoryState : State
  {
    public GameVictoryState(GameController gameController)
    {
      _gameController = gameController;
    }

    private GameController _gameController;
  }
}