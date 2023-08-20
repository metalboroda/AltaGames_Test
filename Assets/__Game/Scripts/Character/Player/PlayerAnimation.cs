using Assets.__Game.Scripts.Character.Player.States;
using Assets.__Game.Scripts.StateMachine;
using DG.Tweening;
using UnityEngine;
using Zenject;

namespace Assets.__Game.Scripts.Character.Player
{
  public class PlayerAnimation : MonoBehaviour
  {
    [SerializeField] private float jumpHeight;
    [SerializeField] private float duration;

    [Inject] private PlayerController _playerController;

    private Transform _model;
    private float _defaultYPosition;

    private void Start()
    {
      _model = _playerController.Player.ModelPivot.transform;

      _defaultYPosition = _model.localPosition.y;

      _playerController.StateMachineController.OnStateUpdated += JumpAnimation;
    }

    private void JumpAnimation(State state)
    {
      Sequence seq = DOTween.Sequence();

      if (state is PlayerMovementState)
      {
        seq.SetLoops(-1);
        seq.Append(_model.DOLocalMoveY(jumpHeight, duration)).SetEase(Ease.OutSine);
        seq.Append(_model.DOLocalMoveY(_defaultYPosition, duration)).SetEase(Ease.InSine);
      }
      else if (state is PlayerIdleState)
        seq.Append(_model.DOLocalMoveY(_defaultYPosition, duration)).SetEase(Ease.InSine);
    }
  }
}