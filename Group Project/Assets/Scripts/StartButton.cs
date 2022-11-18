using UnityEngine;
using UnityEngine.SceneManagement;
public class StartButton : MonoBehaviour
{
   public void PlayGame () {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex  + 1);
   }
}
