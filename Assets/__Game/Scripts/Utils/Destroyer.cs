using Lean.Pool;
using UnityEngine;

namespace Assets.__Game.Scripts.Utils
{
  public class Destroyer : MonoBehaviour
  {
    [SerializeField] private float destroyTime = 1f;
    [SerializeField] private bool isPoollable;

    private Vector3 _defaultScale;

    private void Awake()
    {
      _defaultScale = transform.lossyScale;
    }

    private void Start()
    {
      DestroyObject();
    }

    private void DestroyObject()
    {
      if (isPoollable)
        LeanPool.Despawn(gameObject, destroyTime);
      else
        Destroy(gameObject, destroyTime);
    }
  }
}