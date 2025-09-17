using UnityEngine;

public class PaddleController : MonoBehaviour
{

    public KeyCode moveLeft = KeyCode.A;
    public KeyCode moveRight = KeyCode.D;
    public float speed = 10f;
    public float boundX = 4.5f;

    Rigidbody2D rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    
    void Update()
    {
        // 1) Entrada (A/D ou setas se trocar as teclas)
        float dir = 0f;
        if (Input.GetKey(moveLeft)) dir = -1f;
        else if (Input.GetKey(moveRight)) dir = 1f;

        // 2) Velocidade só no X (Arkanoid não move Y)
        var v = rb.linearVelocity;
        v.x = dir * speed;
        v.y = 0f;
        rb.linearVelocity = v;

        // 3) Limite horizontal (evita sair da tela)
        var p = transform.position;
        p.x = Mathf.Clamp(p.x, -boundX, boundX);
        transform.position = p;
    }
}
