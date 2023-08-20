using UnityEngine;

namespace Assets.__Game.Scripts.Controller
{
  public class InputController : MonoBehaviour
  {
    [field: SerializeField] public Joystick Joystick { get; private set; }
  }
}