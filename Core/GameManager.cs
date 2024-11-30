using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public float playerHealth;

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // Không phá hủy khi chuyển scene
        }
    }
}
