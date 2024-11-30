using UnityEngine;

public class HealthCollection : MonoBehaviour
{
      [SerializeField]  private float HealthValue;
        [SerializeField] private AudioClip pickupSound;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.tag == "Player")
        {
            SoundManager.instance.PlaySound(pickupSound);
            collision.GetComponent<Health>().AddHealth(HealthValue);
            gameObject.SetActive(false);
        }
    }

}

