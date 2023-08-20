using Assets.__Game.Scripts.Controller;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Assets.__Game.Scripts.UI
{
  public class VictoryCanvas : CanvasRoot
  {
    [SerializeField] private Button playAgainButton;

    [Inject] private SceneController _sceneController;

    private void Start()
    {
      playAgainButton.onClick.AddListener(_sceneController.ResetCurrentScene);
    }
  }
}