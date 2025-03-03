using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour
{
    public float startSpeed;//Tốc độ bắt đầu
    public float extraSpeed;//Tốc độ bổ sung, có thể hiểu là tốc độ được tăng sau khi vợt chạm bóng
    public float maxExtraSpeed;//Tối đa của tốc độ bổ sung

    private int hitCounter = 0;//Đếm số lần chạm bóng

    public bool player1Start = true;

    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        StartCoroutine(Launch());//Bắt đầu thực thi
    }

    public void RestartBall()
    {
        rb.velocity = new Vector2(0, 0);//Đặt lại vận tốc và vị trí bóng
        transform.position = new Vector2(0, 0);
    }
    public IEnumerator Launch()
    {
        RestartBall();
        hitCounter = 0;
        yield return new WaitForSeconds(1);

        if(player1Start == true)
        {
            MoveBall(new Vector2(-1, 0));
        }
        else
        {
            MoveBall(new Vector2(1, 0));
        }
        MoveBall(new Vector2(-1, 0));
    }
    public void MoveBall(Vector2 direction)
    {
        //Normalized là giữ nguyên hướng của Vector nhưng đặt độ dài về 1
        direction = direction.normalized;//Chuẩn hóa đúng hướng di chuyển của quả bóng
        //Tốc độ bóng = Tốc độ bắt đầu + số lần chạm bóng + tốc độ bổ sung(5)
        float ballSpeed = startSpeed + hitCounter + extraSpeed;
        rb.velocity = direction * ballSpeed;//Vận tốc = định hướng di chuyển bóng nhân với tốc độ bóng
        //Direction là định hướng di chuyển của quá bóng
    }

    public void IncreaseHitCounter()
    {
        //Nếu số lần chạm bóng nhân với tốc độ bổ sung bé hơn giới hạn tốc độ bổ sung tối đa thì số lần chạm bóng đc cộng 1 , đồng nghĩa với tăng tốc độ bóng đến dưới ngưỡng đó
        if(hitCounter * extraSpeed < maxExtraSpeed)
        {
            hitCounter++;
        }
    }
}
