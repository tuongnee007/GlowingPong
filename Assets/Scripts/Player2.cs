using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2 : MonoBehaviour
{
    public float racketSpeed;//Tốc độ thanh điều khiển chắn bóng

    private Rigidbody2D rb;
    private Vector2 racketDirection;//Hướng di chuyển của thanh chắn 

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();//Lấy thành phần Rigibody2d gắn cho rb
    }

    private void Update()
    {
        float directionY = Input.GetAxisRaw("Vertical2");//Lấy giá trị Input trong unity

        racketDirection = new Vector2(0, directionY).normalized;//Norma trả về Vector có độ dài chuẩn k bị ảnh hưởng
    }

    //cập nhật cố định đồng bộ với dụng cụ vl và dùng cho j lq đến Rigibody
    private void FixedUpdate()
    {
        // Vận tốc đối tượng = hướng di chuyển lên xuống của thanh chắn nhân cho tốc độ thanh điều khiển chắn bóng
        rb.velocity = racketDirection * racketSpeed;
    }
}
