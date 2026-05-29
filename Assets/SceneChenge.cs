using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public void GoToTitle()
    {
        SceneManager.LoadScene("TitleScene");
    }
    public void Retry()
    {
        SceneManager.LoadScene("MainScene");
    }
}
