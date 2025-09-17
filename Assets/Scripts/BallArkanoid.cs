using UnityEngine;

public class BallArkanoid : MonoBehaviour
{
    public float launchForceX = 200f; // força horizontal inicial
    public float launchForceY = 250f; // força vertical inicial

    Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        // espera 1s e lança
        Invoke(nameof(Launch), 1.0f);
    }

    void Launch()
    {
        float dirX = Random.value < 0.5f ? -1f : 1f;
        rb.AddForce(new Vector2(dirX * launchForceX, launchForceY));
    }

    public void ResetBall()
    {
        rb.linearVelocity = Vector2.zero;
        transform.position = Vector2.zero;
    }

    public void restartBall()
    {
        ResetBall();
        Invoke(nameof(Launch), 1.0f);
    }

    private void OnCollisionEnter2D(Collision2D coll)
    {
        // Rebate com "efeito" na raquete
        if (coll.gameObject.CompareTag("Paddle"))
        {
            Vector2 v = rb.linearVelocity;
            float paddleVy = coll.collider.attachedRigidbody ?
                coll.collider.attachedRigidbody.linearVelocity.y : 0f;

            // garante que, ao tocar na raquete, a bola suba
            v.y = Mathf.Abs(v.y);

            // adiciona parte da vel. da raquete para dar controle ao jogador
            v.y += paddleVy * 0.3f;

            rb.linearVelocity = v;
        }

        // Se bater num bloco, destrói
        if (coll.collider.CompareTag("Brick"))
        {
            Destroy(coll.collider.gameObject);
            GameManagerArkanoid.AddScore(10);
        }
    }
}
