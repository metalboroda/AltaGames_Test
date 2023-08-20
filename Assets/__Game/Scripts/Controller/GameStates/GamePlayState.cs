using Assets.__Game.Scripts.StateMachine;

namespace Assets.__Game.Scripts.Controller.GameStates
{
  public class GamePlayState : State
  {
    public GamePlayState(GameController gameController)
    {
      _gameController = gameController;
    }

    private GameController _gameController;
  }
}