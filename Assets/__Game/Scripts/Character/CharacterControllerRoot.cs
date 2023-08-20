using Assets.__Game.Scripts.StateMachine;
using UnityEngine;

namespace Assets.__Game.Scripts.Character
{
  public abstract class CharacterControllerRoot : MonoBehaviour
  {
    // Properties
    public StateMachineController StateMachineController { get; private set; }

    protected virtual void Awake()
    {
      StateMachineController = new StateMachineController();
    }

    protected virtual void Update()
    {
      StateMachineController.CurrentState.Update();
    }

    protected virtual void FixedUpdate()
    {
      StateMachineController.CurrentState.FixedUpdate();
    }
  }
}