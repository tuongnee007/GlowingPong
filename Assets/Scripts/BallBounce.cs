using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneTemplate;
using UnityEngine;

public class BallBounce : MonoBehaviour
{
    public GameObject hitSFX;

    public BallMovement ballMovement;
    public ScoreManager scoreManager;
    private void Bounce(Collision2D collision)
    {
        Vector3 ballPositon = transform.position;
        Vector3 racketPositon =  collision.transform.position;
        float racketHeight = collision.collider.bounds.size.y;

        float positionX;
        if(collision.gameObject.name == "Vertical")
        {
            positionX = 1;
        }
        else
        {
            positionX = -1;
        }

        float positionY = (ballPositon.y - racketPositon.y) / racketHeight;
        ballMovement.IncreaseHitCounter();//Hướng di chuyển bóng. Tăng số lần va chạm
        ballMovement.MoveBall(new Vector2 (positionX, positionY));
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.name == "Player1" || collision.gameObject.name == "Player2")
        {
            Bounce(collision);
        }
        else if(collision.gameObject.name == "Right Border")
        {
            scoreManager.Player1Goal();
            ballMovement.player1Start = false;
            StartCoroutine(ballMovement.Launch());
        }
        else if (collision.gameObject.name == "Left Border")
        {
            scoreManager.Player2Goal();
            ballMovement.player1Start = true;
            StartCoroutine(ballMovement.Launch());
        }
        Instantiate(hitSFX, transform.position, transform.rotation); //Tạo bản sao hitSFX và dặt nó tjai vị trí game Object
    } 
}
