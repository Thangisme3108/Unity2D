using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionTest : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject coin;           // GameObject của đồng xu
    public GameObject tagPrefab;      // Prefab của tag (biểu tượng hoặc thông báo)
    public Transform tagPosition;     // Vị trí hiển thị tag trên màn hình
    public float tagDisplayTime = 2f; // Thời gian hiển thị tag (giây)

    private void OnTriggerEnter(Collider other)
    {
        // Kiểm tra nếu nhân vật va chạm với đồng xu
        if (other.CompareTag("Player"))
        {
            // Hiển thị tag
            ShowTag();

            // Vô hiệu hóa đồng xu sau khi đã ăn
            coin.SetActive(false);
        }
    }

    private void ShowTag()
    {
        // Instantiate tagPrefab tại vị trí chỉ định (hoặc vị trí màn hình)
        GameObject tagInstance = Instantiate(tagPrefab, tagPosition.position, Quaternion.identity);

        // Nếu là UI, bạn có thể điều chỉnh vị trí của tag để nó phù hợp với Canvas
        tagInstance.transform.SetParent(tagPosition, false);

        // Hủy tag sau một khoảng thời gian
        Destroy(tagInstance, tagDisplayTime);
    }
}
