using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    //[Header("MainMenu")]
    //[SerializeField] private GameObject mainMenu;
    [Header("GameOver")]
    [SerializeField] private GameObject gameOverScreen;
    [SerializeField] private AudioClip gameOverSound;

    [Header("PauseGame")]
    [SerializeField] private GameObject pauseScreen;

    [Header("Winn")]
    [SerializeField] private GameObject winScreen;



    private void Awake()
    {
        //mainMenu.SetActive(true);
        gameOverScreen.SetActive(false);
        pauseScreen.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (pauseScreen.activeInHierarchy)
            {
                PauseGame(false);
            }
            else
                PauseGame(true);
        }
    }

    public void Playagain()
    {
        SceneManager.LoadScene(2);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }
    //public void Startgame()
    //{
    //    SceneManager.LoadScene(PlayerPrefs.GetInt("level", 1));
    //}

    #region Game Over
    public void GameOver()
    {
        gameOverScreen.SetActive(true);
        SoundManager.instance.PlaySound(gameOverSound);
    }

    public void Restart()
    {
        
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void Quit()
    {
        Application.Quit();
    }
    #endregion

    #region Pause

    public bool IsPauseScreenActive()
    {
        return pauseScreen.activeInHierarchy;
    }
    public void PauseGame(bool status)
    {
        pauseScreen.SetActive(status);
        Time.timeScale = status ? 0 : 1;
    }

    public void AdjustSoundVolume(int change)
    {
        SoundManager.instance.ChangeSoundVolume(change);
    }

    public void AdjustMusicVolume(int change)
    {
        SoundManager.instance.ChangeMusicVolume(change);
    }

    #endregion
}
