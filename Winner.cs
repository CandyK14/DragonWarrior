using UnityEngine;
using UnityEngine.SceneManagement;

public class Winner : MonoBehaviour
{
    [SerializeField] private AudioClip pickupSound;


    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.tag == "Player")
        {
            SoundManager.instance.PlaySound(pickupSound);
            SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);
            gameObject.SetActive(false);
        }
    }
}
