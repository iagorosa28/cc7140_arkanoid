using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BottomKillZone : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Ball"))
        {
            GameManagerArkanoid.LoseLife();

            // reinicia a bola se ainda houver vidas
            var ball = other.GetComponent<BallArkanoid>();
            if(ball != null && GameManagerArkanoid.Lives > 0)
            {
                ball.RestartBall();
            }
        }
    }

}
