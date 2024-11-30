using UnityEngine;

public class Teleport : MonoBehaviour
{
    [SerializeField] private bool goNextLevel;
    [SerializeField] private string levelName;
    [SerializeField] private AudioClip teleportSound;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {

            SoundManager.instance.PlaySound(teleportSound);
            if (goNextLevel)
            {
                SceneController.instance.NextLevel();
                
            }
            else
            {
                SceneController.instance.LoadScene(levelName);
                
            }

            
        }
    }


}
