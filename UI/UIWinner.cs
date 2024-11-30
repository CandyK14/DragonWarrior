using UnityEngine;
using UnityEngine.SceneManagement;

public class UIWinner : MonoBehaviour
{
    public void Playagain()
    {
        SceneManager.LoadScene(2);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }
    public void Quit()
    {
        Application.Quit();
    }
}
