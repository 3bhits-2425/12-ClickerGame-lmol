using UnityEngine;
using UnityEngine.UI;

public class ParrotJumpAndScore : MonoBehaviour
{
    public float jumpForce = 10f;
    public Text scoreText;

    private Rigidbody2D rb;
    private bool canJump = true;
    private float highestY = 0f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Score aktualisieren
        if (transform.position.y > highestY)
        {
            highestY = transform.position.y;
            if (scoreText != null)
                scoreText.text = "Score: " + Mathf.FloorToInt(highestY).ToString();
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Platform") && canJump)
        {
            Plattform p = col.gameObject.GetComponent<Plattform>();
            if (p != null && p.WillBreak())
            {
                Debug.Log("Abgestürzt!");
                Destroy(gameObject);
            }
            else
            {
                // Automatischer Sprung, falls gewünscht
                rb.velocity = Vector2.up * jumpForce;
            }
        }
    }

    // Diese Methode ziehst du auf den Button im Inspector!
    public void Jump()
    {
        if (canJump)
        {
            rb.velocity = Vector2.up * jumpForce;
        }
    }
}
