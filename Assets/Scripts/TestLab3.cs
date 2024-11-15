using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestLab3 : MonoBehaviour
{
    // Start is called before the first frame update
     public float moveSpeed = 5f;
     public GameObject winCanva;
        private Vector2 move;
        private Vector3 startPos;

        void Start()
        {
            
            startPos = transform.position;
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

            
            if (other.gameObject.CompareTag("enemy"))
            {
                // Đưa nhân vật trở lại vị trí hợp lệ
                transform.position = startPos;
            }
            if (other.gameObject.CompareTag("win"))
            {
                // Đưa nhân vật trở lại vị trí hợp lệ
               winCanva.SetActive(true);
            }

           
        }
}
