using Assets.__Game.Scripts.Interfaces;
using DG.Tweening;
using Lean.Pool;
using UnityEngine;

namespace Assets.__Game.Scripts.Item
{
  public class Projectile : MonoBehaviour
  {
    [field: SerializeField] public Rigidbody RB { get; private set; }
    [SerializeField] private Collider coll;
    [SerializeField] private Renderer rend;

    [Header("Explosion param's")]
    [SerializeField] private float explosionSizeMult = 1.5f;
    [SerializeField] private float explosionSpeed = 0.15f;
    [SerializeField] private GameObject explosionVfx;

    [Header("Animation param's")]
    [SerializeField] private float startAnimDuration = 0.075f;

    private Vector3 _defaultScale;
    private bool _isCanInflate;
    private Color _materialColor;
    private int _vfxCounter;

    private void Awake()
    {
      _defaultScale = transform.localScale;
      _materialColor = rend.material.color;
    }

    private void OnEnable()
    {
      ResetOnEnable();

      transform.DOScale(_defaultScale, startAnimDuration).OnComplete(() =>
      {
        _isCanInflate = true;
      });
    }

    private void OnCollisionEnter(Collision collision)
    {
      if (collision.gameObject.TryGetComponent(out IDamageable damageable))
      {
        damageable.Damage(1);

        Explode();
      }

      if (collision.gameObject.TryGetComponent(out IColorable colorable))
        colorable.Colorize(_materialColor);
    }

    private void ResetOnEnable()
    {
      RB.isKinematic = false;
      coll.enabled = true;
      rend.enabled = true;
      transform.localScale = Vector3.zero;
      _vfxCounter = 0;
    }

    public void SetColor(Color color)
    {
      rend.material.color = color;
    }

    public void Inflate(float value)
    {
      if (_isCanInflate)
        transform.localScale = new Vector3(transform.localScale.x + value, transform.localScale.y + value, transform.localScale.z + value);
    }

    private void Explode()
    {
      RB.velocity = Vector3.zero;
      rend.enabled = false;

      var currentScale = transform.localScale;

      transform.DOScale(new Vector3(currentScale.x + explosionSizeMult, currentScale.y + explosionSizeMult,
        currentScale.z + explosionSizeMult), explosionSpeed).OnComplete(() =>
        {
          DestroyObject(0);
        });

      ExplosionVfx();
    }

    public void DestroyObject(float destroyTime)
    {
      Destroy(gameObject, destroyTime);
    }

    private void ExplosionVfx()
    {
      _vfxCounter++;

      if (_vfxCounter == 1)
      {
        var spawnedVfx = LeanPool.Spawn(explosionVfx, transform.position, Quaternion.identity);

        spawnedVfx.transform.localScale = transform.lossyScale;
      }
    }
  }
}