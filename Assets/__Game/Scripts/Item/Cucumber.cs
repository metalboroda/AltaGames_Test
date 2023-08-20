
using Assets.__Game.Scripts.Interfaces;
using Lean.Pool;
using System.Collections;
using UnityEngine;

namespace Assets.__Game.Scripts.Item
{
  public class Cucumber : MonoBehaviour, IDamageable, IColorable
  {
    [SerializeField] private Collider coll;
    [SerializeField] private Collider trig;

    [Header("Color param's")]
    [SerializeField] private Renderer rend;

    [Header("Random size param's")]
    [SerializeField] private GameObject model;
    [SerializeField] private float randomSizeMinMult = 0.15f;
    [SerializeField] private float randomSizeMaxMult = 0.75f;

    [Header("")]
    [SerializeField] private GameObject destroyVfx;

    private float _destroyTime = 3f;

    private void Start()
    {
      SetRandomSize();
    }

    private void SetRandomSize()
    {
      var randSizeMult = Random.Range(randomSizeMinMult, randomSizeMaxMult);
      var modelSize = model.transform.localScale;

      model.transform.localScale = new Vector3(modelSize.x + randSizeMult, modelSize.y + randSizeMult, modelSize.z + randSizeMult);
    }

    public void Damage(float damage)
    {
      coll.enabled = false;
      trig.enabled = false;

      StartCoroutine(DestroyObjectRoutine());
    }

    public void Colorize(Color color)
    {
      rend.material.color = color;
    }

    private IEnumerator DestroyObjectRoutine()
    {
      yield return new WaitForSeconds(_destroyTime);

      DestroyVfx();
      Destroy(gameObject);
    }

    private void DestroyVfx()
    {
      var spawnedVfx = LeanPool.Spawn(destroyVfx, transform.position, Quaternion.identity);

      spawnedVfx.transform.localScale = model.transform.lossyScale;
    }
  }
}