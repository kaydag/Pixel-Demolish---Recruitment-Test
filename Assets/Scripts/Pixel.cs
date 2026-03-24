using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pixel : MonoBehaviour
{
    [SerializeField] private float health = 10f;
    [SerializeField] private Rigidbody2D rb;

    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private Color color;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0.5f;

        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
            Die();
        }
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
    }

    private void Die()
    {
        color = Color.gray;
        spriteRenderer.color = color;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Gear") && health <= 0)
        {
            Destroy(gameObject);
            GameManager.instance.SpawnCoin(transform.position);
        }
    }
}
