using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestLab3 : MonoBehaviour
{
    // Start is called before the first frame update
     public float moveSpeed = 5f;
     public GameObject winCanva;
        private Vector2 move;

        void Start()
        {
            winCanva.SetActive(false);
        }
    
        void Update()
        {
            // Lấy đầu vào từ bàn phím
            float moveX = Input.GetAxis("Horizontal"); // Trái và Phải
            float moveY = Input.GetAxis("Vertical");   // Lên và Xuống
    
            // Tạo vector di chuyển
            move = new Vector2(moveX, moveY);
    
            // Di chuyển nhân vật trực tiếp qua vị trí Transform
            transform.position += (Vector3)(move * moveSpeed * Time.deltaTime);
        }
    
        void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Border"))
            {
                // Đưa nhân vật trở lại vị trí hợp lệ
                transform.position = new Vector2(
                    Mathf.Clamp(transform.position.x, -8f, 8f),
                    Mathf.Clamp(transform.position.y, -4f, 4f)
                ); // Thay đổi giá trị theo kích thước bản đồ
            }

            if (other.CompareTag("End"))
            {
                winCanva.SetActive(true); 
            }
        }
}
