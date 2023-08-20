using Assets.__Game.Scripts.Character.Player.States;
using Lean.Pool;
using UnityEngine;

namespace Assets.__Game.Scripts.Character.Player
{
  public class Player : MonoBehaviour
  {
    [SerializeField] private float health = 100f;
    [SerializeField] private float minimuHealth = 20f;
    [field: SerializeField] public GameObject ModelPivot { get; private set; }

    [Header("VFX")]
    [SerializeField] private GameObject deathVfx;

    [field: Header("")]
    [field: SerializeField] public Renderer Rend { get; private set; }

    private Vector3 initialLocalScale;

    private PlayerController _playerController;

    private void Start()
    {
      initialLocalScale = ModelPivot.transform.localScale;
    }

    private void Update()
    {
      CalculateHealthToScale();
      CheckHealth();
    }

    public void Init(PlayerController playerController)
    {
      _playerController = playerController;
    }

    private void CalculateHealthToScale()
    {
      float scaleRatio = ModelPivot.transform.localScale.y / initialLocalScale.y;

      health = 100f * scaleRatio;

      health = Mathf.Clamp(health, 0f, 100f);
    }

    private void CheckHealth()
    {
      if (health <= minimuHealth)
      {
        Death();
      }
    }

    public void Death()
    {
      DeathVfx();
      Destroy(gameObject);

      _playerController.StateMachineController.ChangeState(new PlayerDeathState(_playerController));
    }

    private void DeathVfx()
    {
      var spawnedVfx = LeanPool.Spawn(deathVfx, transform.position, Quaternion.identity);

      spawnedVfx.transform.localScale = ModelPivot.transform.lossyScale;
    }
  }
}
