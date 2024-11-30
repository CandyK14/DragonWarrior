using UnityEngine;

public class Room : MonoBehaviour
{
    [SerializeField] private GameObject[] enemies;
    private Vector3[] initialPosition;

    private void Awake()
    {
        // Lưu vị trí ban đầu của các đối tượng (enemy)
        initialPosition = new Vector3[enemies.Length];
        for (int i = 0; i < enemies.Length; i++)
        {
            if (enemies[i] != null)
            {
                initialPosition[i] = enemies[i].transform.position;
                // Tắt tất cả các đối tượng lúc đầu
                enemies[i].SetActive(false);
            }
        }
    }

    public void ActivateRoom(bool _status)
    {
        // Kích hoạt hoặc vô hiệu hóa các đối tượng (enemy)
        for (int i = 0; i < enemies.Length; i++)
        {
            if (enemies[i] != null)
            {
                enemies[i].SetActive(_status);
                if (_status)
                {
                    // Đặt lại vị trí ban đầu khi kích hoạt
                    enemies[i].transform.position = initialPosition[i];
                }
            }
        }
    }
}
