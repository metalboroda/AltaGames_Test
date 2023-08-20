using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.__Game.Scripts.Controller
{
  public class SceneController : MonoBehaviour
  {
    public void ResetCurrentScene()
    {
      SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
  }
}