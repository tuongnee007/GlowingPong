using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1 : MonoBehaviour
{
    public float racketSpeed;

    private Rigidbody2D rb;
    private Vector2 racketDirection;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        float directionY = Input.GetAxisRaw("Vertical");

        racketDirection = new Vector2 (0, directionY).normalized;
    }

    //cập nhật cố định đồng bộ với dụng cụ vl và dùng cho j lq đến Rigibody
    private void FixedUpdate()
    {
        rb.velocity = racketDirection * racketSpeed;
    }
}
