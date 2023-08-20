using Assets.__Game.Scripts.Animation;
using Assets.__Game.Scripts.Character.Player;
using UnityEngine;

namespace Assets.__Game.Scripts.Item
{
  public class Gates : MonoBehaviour
  {
    [Header("Animation")]
    [SerializeField] private DoorsAnimationSO doorsAnimationSO;
    [SerializeField] private float crossfadeDuration = 0.25f;

    private Animator _animator;

    private void Awake()
    {
      _animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
      if (other.GetComponent<PlayerCollider>())
        OpenAnimtion();
    }

    private void OnTriggerExit(Collider other)
    {
      if (other.GetComponent<PlayerCollider>())
        CloseAnimation();
    }

    private void OpenAnimtion()
    {
      _animator.StopPlayback();
      _animator.CrossFadeInFixedTime(doorsAnimationSO.Open.name, crossfadeDuration);
    }

    private void CloseAnimation()
    {
      _animator.StopPlayback();
      _animator.CrossFadeInFixedTime(doorsAnimationSO.Close.name, crossfadeDuration);
    }
  }
}