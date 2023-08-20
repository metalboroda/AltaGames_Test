using System;

namespace Assets.__Game.Scripts.StateMachine
{
  public class StateMachineController
  {
    public event Action<State> OnStateUpdated;

    public State CurrentState { get; private set; }
    public State PreviousState { get; private set; }

    public void Initialize(State startState)
    {
      CurrentState = startState;
      CurrentState.Enter();
    }

    public void ChangeState(State newState)
    {
      PreviousState = CurrentState;
      CurrentState.Exit();
      CurrentState = newState;
      CurrentState.Enter();

      OnStateUpdated?.Invoke(newState);
    }
  }
}