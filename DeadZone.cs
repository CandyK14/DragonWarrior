using UnityEngine;

public class DeadZone : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Kiểm tra nếu đối tượng va chạm là Player
        if (collision.CompareTag("Player"))
        {
            // Gọi phương thức TakeDamage với lượng sát thương đủ lớn để giết Player ngay lập tức
            Health playerHealth = collision.GetComponent<Health>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(playerHealth.currentHealth);
            }
        }
    }
}
