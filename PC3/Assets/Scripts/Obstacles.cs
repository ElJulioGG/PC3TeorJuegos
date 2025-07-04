using UnityEngine;

public class Obstacles : MonoBehaviour
{
    public float moveSpeed = 3f;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.linearVelocity = Vector2.left * moveSpeed;
        Destroy(gameObject, 5f);
    }
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            GameManager.instance.playerHealth--;
            Destroy(gameObject);
        }
    }
}
