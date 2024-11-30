using UnityEngine;

public class PlayerRespawn : MonoBehaviour
{
    [SerializeField] private AudioClip CheckpointSound;
    private Transform currentCheckpoint;
    private Health playerHealth;

    private UIManager uiManager;

    private void Awake()
    {
        playerHealth = GetComponent<Health>();
        uiManager = FindAnyObjectByType<UIManager>();
    }

    public void CheckRespawn()
    {
        //Check if check point available
        if (currentCheckpoint == null)
        {
            //Show game over screen
            uiManager.GameOver();
            return;
        }
        
        playerHealth.Respawn();//Restore player Health and reset animation
        transform.position = currentCheckpoint.position;

        //Move camera to checkpoint room
        Camera.main.GetComponent<CameraController>().MoveToNewRoom(currentCheckpoint.parent);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.transform.tag == "Checkpoint")
        {
            currentCheckpoint = collision.transform;
            SoundManager.instance.PlaySound(CheckpointSound);
            collision.GetComponent<Collider2D>().enabled = false;
            collision.GetComponent<Animator>().SetTrigger("appear");
        }
    }
}
