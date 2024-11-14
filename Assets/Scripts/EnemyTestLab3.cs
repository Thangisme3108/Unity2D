using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTestLab3 : MonoBehaviour
{
    // Start is called before the first frame update
    public float moveSpeed = 1f; // Tốc độ di chuyển
    public float changeInterval = 1f; // Thời gian thay đổi hướng
    private Vector3 targetDirection;

    void Start()
    {
        // Đặt hướng di chuyển ngẫu nhiên ngay từ đầu
        SetRandomDirection();
        InvokeRepeating("SetRandomDirection", changeInterval, changeInterval);
    }

    void Update()
    {
        // Di chuyển nhân vật theo hướng đã chọn
        transform.position += targetDirection * moveSpeed * Time.deltaTime;
    }

    void SetRandomDirection()
    {
        // Tạo hướng ngẫu nhiên
        targetDirection = new Vector3(Random.Range(-1f, 1f), 0, Random.Range(-1f, 1f)).normalized;
    }
}
