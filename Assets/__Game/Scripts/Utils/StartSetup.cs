using UnityEngine;

namespace Assets.__Game.Scripts.Utils
{
  public class StartSetup : MonoBehaviour
  {
    private void Awake()
    {
      QualitySettings.vSyncCount = 1;
      Application.targetFrameRate = 60;
    }
  }
}