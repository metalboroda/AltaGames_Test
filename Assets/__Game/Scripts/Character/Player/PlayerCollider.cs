using Assets.__Game.Scripts.Character.Player.States;
using Assets.__Game.Scripts.Item;
using UnityEngine;

namespace Assets.__Game.Scripts.Character.Player
{
  public class PlayerCollider : MonoBehaviour
  {
    [field: SerializeField] public SphereCollider Collider { get; private set; }

    public PlayerController PlayerController { get; private set; }

    private void OnTriggerEnter(Collider other)
    {
      if (other.GetComponent<Finish>())
        PlayerController.StateMachineController.ChangeState(new PlayerIdleState(PlayerController));
    }

    public void Init(PlayerController playerController)
    {
      PlayerController = playerController;
    }
  }
}