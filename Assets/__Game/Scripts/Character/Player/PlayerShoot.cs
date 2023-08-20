using Assets.__Game.Scripts.Item;
using Lean.Pool;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Assets.__Game.Scripts.Character.Player
{
  public class PlayerShoot : MonoBehaviour
  {
    [field: SerializeField] public GameObject ModelPivot { get; private set; }
    [SerializeField] private float scalingMultiplier = 0.01f;
    [SerializeField] private float movementScalingMultiplier = 0.005f;
    [SerializeField] private float scalingDivision = 10f;

    [Header("Shooting")]
    [SerializeField] private Transform projectilePoint;
    [SerializeField] private GameObject projectilePrefab;
    [SerializeField] private float shootPower = 75f;
    [SerializeField] private float maxInflationTime = 0.003f;

    private float _tick;

    private Projectile _projectile;

    private PlayerController _playerController;

    public void Init(PlayerController playerController)
    {
      _playerController = playerController;
    }

    public void Touch()
    {
      if (Input.touchCount > 0)
      {
        Touch touch = Input.GetTouch(0);

        if (!EventSystem.current.IsPointerOverGameObject(touch.fingerId))
        {
          Aim(touch);
          SetProjectile();
          Deflate();
        }
      }
      else if (Input.touchCount == 0)
      {
        Shoot();
      }
    }

    private void Aim(Touch touch)
    {
      Ray ray = Camera.main.ScreenPointToRay(touch.position);

      if (Physics.Raycast(ray, out RaycastHit hit))
      {
        Vector3 targetPoint = hit.point;
        Vector3 directionToTarget = targetPoint - transform.position;

        directionToTarget.y = 0;

        Quaternion targetRotation = Quaternion.LookRotation(directionToTarget);

        transform.rotation = targetRotation;
      }
    }

    private void SetProjectile()
    {
      if (_projectile == null)
        _projectile = LeanPool.Spawn(projectilePrefab, projectilePoint.position, projectilePoint.rotation, projectilePoint).GetComponent<Projectile>();

      _tick += Time.deltaTime * scalingMultiplier;

      if (_tick < maxInflationTime)
        _projectile.Inflate(_tick);

      _projectile.SetColor(_playerController.Player.Rend.material.color);

      _projectile.RB.velocity = Vector3.zero;
      _projectile.transform.position = new Vector3(projectilePoint.position.x,
        _projectile.transform.position.y, projectilePoint.position.z);
    }

    private void Shoot()
    {
      if (_projectile != null)
      {
        _projectile.DestroyObject(3);

        _projectile.RB.AddForce(transform.forward * shootPower, ForceMode.Impulse);

        _projectile.transform.parent = null;
        _projectile = null;

        _tick = 0f;
      }
    }

    private void Deflate()
    {
      if (_tick >= maxInflationTime) return;

      var scale = ModelPivot.transform.localScale;
      var devidedTick = _tick / scalingDivision;

      ModelPivot.transform.localScale = new Vector3(scale.x - devidedTick,
        scale.y - devidedTick, scale.z - devidedTick);
    }

    public void MovementDeflate()
    {
      _tick += Time.deltaTime * movementScalingMultiplier;

      var scale = ModelPivot.transform.localScale;
      var devidedTick = _tick / scalingDivision;

      ModelPivot.transform.localScale = new Vector3(scale.x - devidedTick,
        scale.y - devidedTick, scale.z - devidedTick);
    }
  }
}