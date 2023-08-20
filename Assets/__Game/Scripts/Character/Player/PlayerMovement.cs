using Assets.__Game.Scripts.Controller;
using UnityEngine;
using Zenject;

namespace Assets.__Game.Scripts.Character.Player
{
  public class PlayerMovement : MonoBehaviour
  {
    [SerializeField] private float forwardMovementSpeed = 4f;
    [SerializeField] private float sideMovementSpeed = 4f;

    [Inject] private InputController _inputController;

    public void Movement()
    {
      // Auto forward movement
      transform.Translate(forwardMovementSpeed * Time.deltaTime * Vector3.forward);

      // Horizontal movement
      float horizontalInput = _inputController.Joystick.Horizontal;

      Vector3 movementDirection = new(horizontalInput * sideMovementSpeed, 0f, 0f);

      transform.Translate(movementDirection * Time.deltaTime);
    }
  }
}