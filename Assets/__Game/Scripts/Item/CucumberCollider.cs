using Assets.__Game.Scripts.Character.Player;
using UnityEngine;

namespace Assets.__Game.Scripts.Item
{
  public class CucumberCollider : MonoBehaviour
  {
    private void OnTriggerEnter(Collider other)
    {

      if (other.TryGetComponent(out PlayerCollider playerCollider))
      {
        playerCollider.PlayerController.Player.Death();
      }
    }
  }
}