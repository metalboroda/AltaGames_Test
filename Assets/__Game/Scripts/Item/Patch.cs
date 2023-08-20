using Assets.__Game.Scripts.Character.Player;
using UnityEngine;
using Zenject;

namespace Assets.__Game.Scripts.Item
{
  public class Patch : MonoBehaviour
  {
    [SerializeField] private float playerYOffset = 0.001f;
    [SerializeField] private float playerZOffset = 0.5f;
    [SerializeField] private float startWidthMultiplier = 1.5f;
    [SerializeField] private float endWidthMultiplier = 1.5f;

    [Header("")]
    [SerializeField] private GameObject finish;

    private Vector3 _playerPos;
    private float _playerWidth;

    private LineRenderer _lineRenderer;

    [Inject] private readonly PlayerController _playerController;

    private void Awake()
    {
      _lineRenderer = GetComponent<LineRenderer>();
    }

    private void Update()
    {
      SetPatch();
    }

    private void SetPatch()
    {
      var finishPos = finish.transform.position;
      var finishWidth = transform.localScale.x;

      if (_playerController != null)
      {
        _playerPos = _playerController.Player.ModelPivot.transform.position;
        _playerWidth = _playerController.PlayerShoot.ModelPivot.transform.localScale.x;
      }

      var newFinishPos = new Vector3(finishPos.x, finishPos.y + playerYOffset, finishPos.z);
      var newPlayerPos = new Vector3(_playerPos.x, _playerPos.y + playerYOffset, _playerPos.z + playerZOffset);

      _lineRenderer.SetPosition(0, newFinishPos);
      _lineRenderer.SetPosition(1, newPlayerPos);

      _lineRenderer.startWidth = finishWidth * startWidthMultiplier;
      _lineRenderer.endWidth = _playerWidth * endWidthMultiplier;
    }
  }
}