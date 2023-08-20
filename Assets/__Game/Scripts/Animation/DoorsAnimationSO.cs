using UnityEngine;

namespace Assets.__Game.Scripts.Animation
{
  [CreateAssetMenu(menuName = "Animation/DoorsSO")]
  public class DoorsAnimationSO : ScriptableObject
  {
    [field: SerializeField] public AnimationClip Open { get; private set; }
    [field: SerializeField] public AnimationClip Close { get; private set; }
  }
}